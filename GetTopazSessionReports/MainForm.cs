﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using lcpi.data.oledb;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace GetTopazSessionReports
{
    public partial class MainForm : Form
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        internal static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool FreeLibrary(IntPtr hModule);

        internal delegate int PointerToMethodInvoker();

        bool CanClose = false;
        bool IsOkPressed = false;

        #if DEBUG
            string outputDirectory = "TopazReportsTest";
        #else
            string outputDirectory = "TopazReports";
        #endif

        public MainForm()
        {
            Program.logger.Trace("Запуск!");

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!CheckIBProvider())
            {
                CanClose = true;
                Close();
                return;
            }

            AppSettings.LoadSettings();

            if (!AppSettings.CheckSettings() || AppSettings.isCreated)
            {
                notifyIcon.ShowBalloonTip(3000, "Получение отчетов Топаз", "Проверьте заполнение настроек!", ToolTipIcon.Error);
            }
            else
            {
                Hide();
                ShowInTaskbar = false;

                GetSessionReports();

                timer.Enabled = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CanClose && e.CloseReason != CloseReason.WindowsShutDown)
            {
                e.Cancel = true;
                Hide();
                ShowInTaskbar = false;
                timer.Enabled = true;

                if (IsOkPressed)
                    GetSessionReports();
            } else
            {
                Program.logger.Trace("Завершение!");
            }

            IsOkPressed = false;
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            ShowInTaskbar = true;
            timer.Enabled = false;

            UpdateControls();
        }

        private void menuItemGetReportByNum_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;

            SessionNumberInputForm inputForm = new SessionNumberInputForm();
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                UploadSessionReport(inputForm.sessionNum);
            }

            timer.Enabled = true;
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            CanClose = true;

            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            int lastSession = 0;
            if (!int.TryParse(LastSession.Text, out lastSession))
            {
                MessageBox.Show("Номер смены должен быть числом!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (StartDate.Value != StartDateLocal.Value && lastSession == 0)
            {
                MessageBox.Show("Если начальные даты различаются, то необходимо указать начальный номер выгружаемой смены!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AppSettings.settings.FirebirdServerName = FirebirdServerName.Text;
            AppSettings.settings.FirebirdUserName = FirebirdUserName.Text;
            AppSettings.settings.FirebirdPassword = FirebirdPassword.Text;
            AppSettings.settings.FirebirdDatabaseFile = FirebirdDatabaseFile.Text;
            AppSettings.settings.FtpHost = FtpHost.Text;
            AppSettings.settings.FtpLogin = FtpLogin.Text;
            AppSettings.settings.FtpPassword = FtpPassword.Text;
            AppSettings.settings.FtpPath = FtpPath.Text;
            AppSettings.settings.StartDate = StartDate.Value;
            AppSettings.settings.StartDateLocal = StartDateLocal.Value;
            AppSettings.settings.LastSession = lastSession;
            AppSettings.settings.ExtendedLogs = ExtendedLogs.Checked;

            AppSettings.SaveSettings();

            AppSettings.isCreated = false;

            IsOkPressed = true;

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            GetSessionReports();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            UpdateControls();
        }

        void UpdateControls()
        {
            FirebirdServerName.Text = AppSettings.settings.FirebirdServerName;
            FirebirdUserName.Text = AppSettings.settings.FirebirdUserName;
            FirebirdPassword.Text = AppSettings.settings.FirebirdPassword;
            FirebirdDatabaseFile.Text = AppSettings.settings.FirebirdDatabaseFile;
            FtpHost.Text = AppSettings.settings.FtpHost;
            FtpLogin.Text = AppSettings.settings.FtpLogin;
            FtpPassword.Text = AppSettings.settings.FtpPassword;
            FtpPath.Text = AppSettings.settings.FtpPath;
            StartDate.Value = AppSettings.settings.StartDate;
            StartDateLocal.Value = AppSettings.settings.StartDateLocal;
            LastSession.Text = AppSettings.settings.LastSession.ToString();
            ExtendedLogs.Checked = AppSettings.settings.ExtendedLogs;
        }

        void GetSessionReports()
        {
            if (AppSettings.settings.ExtendedLogs)
                Program.logger.Trace($"Запуск процесса получения сменных отчетов");

            try
            {
                List<long> sessions = GetSessionsForUpload();
                if (sessions.Count == 0)
                    return;

                CheckCreateFtpDirectory();

                foreach (long id in sessions)
                {
                    UploadSessionReport(id);
                }

                AppSettings.settings.LastSession = sessions[sessions.Count - 1];
                AppSettings.SaveSettings();

                timer.Interval = 1800000;
            }
            catch (Exception e)
            {
                Program.logger.Error(e);

                if (timer.Interval > 600000)
                {
                    timer.Interval -= 600000;
                } else
                {
                    notifyIcon.ShowBalloonTip(3000, "Получение отчетов Топаз", e.Message, ToolTipIcon.Error);
                }
                
            }
        }

        private void UploadSessionReport(long id)
        {
            if (AppSettings.settings.ExtendedLogs)
                Program.logger.Trace($"Начало выгрузки смены {id}");

            string sessionReportFileName = CreateSessionReport(id);
            UploadSessionReportToFtp(sessionReportFileName);
            File.Delete(sessionReportFileName);
        }

        private List<long> GetSessionsForUpload()
        {
            if (AppSettings.settings.ExtendedLogs)
                Program.logger.Trace($"Получение номеров смен для выгрузки");

            List<long> result = new List<long>();

            using (var connection = new OleDbConnection(AppSettings.connectionString))
            {
                    connection.Open();

                    string sql =
                        @"SELECT ""SessionID"" FROM ""sysSessions""
                          WHERE ""StartDateTime"" >= @StartDateTime
                            AND ""EndDateTime"" IS NOT NULL
                            AND ""SessionID"" > @LastSession
                          ORDER BY ""SessionID""";

                    var query = new OleDbCommand(sql, connection);
                    query["StartDateTime"].Value = AppSettings.settings.StartDateLocal;
                    query["LastSession"].Value = AppSettings.settings.LastSession;

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader.GetInt64(0));
                        }
                    }
                }

                return result;
        }

        private string CreateSessionReport(long id)
        {
            if (AppSettings.settings.ExtendedLogs)
                Program.logger.Trace($"Создание файла по смене {id}");

            string fileName = Path.GetTempFileName();

            string azsCode = "", sessionDateTime = "";

            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;
            xmlSettings.Encoding = Encoding.GetEncoding(1251);

            using (StreamWriter streamWriter = new StreamWriter(new FileStream(fileName, FileMode.Create), Encoding.GetEncoding(1251)))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(streamWriter, xmlSettings))
                {
                    xmlWriter.WriteStartDocument();

                    using (var connection = new OleDbConnection(AppSettings.connectionString))
                    {
                        connection.Open();

                        WriteSessionInfo(xmlWriter, connection, id, out azsCode, out sessionDateTime);
                        WriteTanksInfo(xmlWriter, connection, id);
                        WriteHosesInfo(xmlWriter, connection, id);
                        WriteOrders(xmlWriter, connection, id);
                    }

                    xmlWriter.WriteEndDocument();
                }
            }

            string xmlFileName = Path.Combine(Path.GetTempPath(), $"SessionReport-{sessionDateTime}-AZS{azsCode.PadLeft(3, '0')}-N{id.ToString().PadLeft(4, '0')}.xml");
            File.Delete(xmlFileName);
            File.Move(fileName, xmlFileName);

            return xmlFileName;
        }

        private void WriteSessionInfo(XmlWriter writer, OleDbConnection connection, long id, out string azsCode, out string sessionDateTime)
        {
            if (AppSettings.settings.ExtendedLogs)
                Program.logger.Trace($"Запись файла id = {id}: информация по смене");

            string sql =
                @"SELECT ""sysSessions"".""SessionNum"", ""sysSessions"".""UserName"", 
                         ""sysSessions"".""StartDateTime"", ""sysSessions"".""EndDateTime"",
                         ""ProgConfig_AZSCode"".""IntegerValue"" AS ""AZSCode"",
                         ""ProgConfig_AZSName"".""StringValue"" AS ""AZSName""
                  FROM ""sysSessions""
                  LEFT JOIN ""ProgConfig"" ""ProgConfig_AZSCode"" ON ""Name"" = 'AZSCode'
                  LEFT JOIN ""ProgConfig"" ""ProgConfig_AZSName"" ON ""Name"" = 'AZSName'
                  WHERE ""sysSessions"".""SessionID"" = @id";

            var query = new OleDbCommand(sql, connection);
            query["id"].Value = id;

            azsCode = "";
            sessionDateTime = null;

            using (var reader = query.ExecuteReader()) {
                if (!reader.HasRows || !reader.Read())
                    throw new Exception($"Отсутствует информация по смене с ID = {id}!");

                azsCode = reader.GetValue(4).ToString();

                DateTime startDateTimeLocal = (DateTime)(reader.GetValue(2));
                DateTime startDateTime = startDateTimeLocal + (AppSettings.settings.StartDate - AppSettings.settings.StartDateLocal);
                DateTime endDateTimeLocal = DateTime.MinValue, endDateTime = DateTime.MinValue;
                bool isOpenSession = reader.IsDBNull(3);
                if (!isOpenSession)
                {
                    endDateTimeLocal = (DateTime)(reader.GetValue(3));
                    endDateTime = endDateTimeLocal + (AppSettings.settings.StartDate - AppSettings.settings.StartDateLocal);
                }
                sessionDateTime = startDateTime.ToString("yyyy-MM-dd");

                writer.WriteStartElement("DataPaket");
                writer.WriteAttributeString("AZSCode", azsCode);
                writer.WriteAttributeString("AZSName", reader.GetValue(5).ToString());

                writer.WriteStartElement("Sessions");

                writer.WriteStartElement("Session");
                writer.WriteAttributeString("UserName", reader.GetValue(1).ToString());
                writer.WriteAttributeString("StartDateTime", startDateTime.ToString("dd.MM.yyyy HH:mm:ss"));
                writer.WriteAttributeString("StartDateTimeLocal", startDateTimeLocal.ToString("dd.MM.yyyy HH:mm:ss"));
                if (!isOpenSession)
                {
                    writer.WriteAttributeString("EndDateTime", endDateTime.ToString("dd.MM.yyyy HH:mm:ss"));
                    writer.WriteAttributeString("EndDateTimeLocal", endDateTimeLocal.ToString("dd.MM.yyyy HH:mm:ss"));
                }
                writer.WriteAttributeString("SessionNum", reader.GetValue(0).ToString());
            }
        }

        private void WriteTanksInfo(XmlWriter writer, OleDbConnection connection, long id)
        {
            if (AppSettings.settings.ExtendedLogs)
                Program.logger.Trace($"Запись файла id = {id}: информация по емкостям");

            string sql =
                @"SELECT ""flSesTanks"".""TankNum"", ""flSesTanks"".""FuelName"", 
                         ""flSesTanks"".""StartFuelVolume"", ""flSesTanks"".""ReceptVolume"",
                         ""flSesTanks"".""PumpVolume""
                  FROM ""flSesTanks""
                  WHERE ""SessionID"" = @id";

            var query = new OleDbCommand(sql, connection);
            query["id"].Value = id;

            using (var reader = query.ExecuteReader())
            {
                writer.WriteStartElement("Tanks");

                while (reader.Read())
                {
                    writer.WriteStartElement("Tank");
                    writer.WriteAttributeString("TankNum", reader.GetValue(0).ToString());
                    writer.WriteAttributeString("FuelName", reader.GetValue(1).ToString());
                    writer.WriteAttributeString("StartFuelVolume", reader.GetValue(2).ToString());
                    writer.WriteAttributeString("ReceptVolume", reader.GetValue(3).ToString());
                    writer.WriteAttributeString("PumpVolume", reader.GetValue(4).ToString());
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }
        }

        private void WriteHosesInfo(XmlWriter writer, OleDbConnection connection, long id)
        {
            if (AppSettings.settings.ExtendedLogs)
                Program.logger.Trace($"Запись файла id = {id}: информация по рукавам");

            string sql =
                @"SELECT '1' AS ""HoseType"", ""FuelName"", ""dcHoses"".""Num"" AS ""HoseNum"",
                         ""flSesHoses"".""PumpNum"", ""flSesHoses"".""NumInPump"",  
                         ""StartAdder"", ""EndAdder""
                  FROM ""flSesHoses""
                  LEFT JOIN ""dcHoses"" ON ""dcHoses"".""HoseID"" = ""flSesHoses"".""HoseID""
                  WHERE ""flSesHoses"".""SessionID"" = @id
                  ORDER BY ""TankNum"", ""flSesHoses"".""PumpNum"", ""flSesHoses"".""NumInPump""";

            var query = new OleDbCommand(sql, connection);
            query["id"].Value = id;

            using (var reader = query.ExecuteReader())
            {
                writer.WriteStartElement("Hoses");

                while (reader.Read())
                {
                    writer.WriteStartElement("Hose");
                    writer.WriteAttributeString("HoseType", reader.GetValue(0).ToString());
                    writer.WriteAttributeString("FuelName", reader.GetValue(1).ToString());
                    writer.WriteAttributeString("HoseNum", reader.GetValue(2).ToString());
                    writer.WriteAttributeString("PumpNum", reader.GetValue(3).ToString());
                    writer.WriteAttributeString("NumInPump", reader.GetValue(4).ToString());
                    writer.WriteAttributeString("StartCounter", reader.GetValue(5).ToString());
                    writer.WriteAttributeString("EndCounter", reader.GetValue(6).ToString());
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }
        }

        private void WriteOrders(XmlWriter writer, OleDbConnection connection, long id)
        {
            if (AppSettings.settings.ExtendedLogs)
                Program.logger.Trace($"Запись файла id = {id}: продажи");

            string sql =
                @"SELECT ""flOrders"".""DateTime"", 
                         ""dcTanks"".""Num"" AS ""TankNum"", 
                         ""dcHoses"".""Num"" AS ""HoseName"",
                         ""dcFuels"".""Name"" AS ""FuelName"",
                         ""dcPaymentModes"".""Name"" AS ""PaymentModeName"",
                         ""dcPartners"".""Name"" AS ""PartnerName"",
                         ""dcAgents"".""Name"" AS ""AgentName"",
                         ""dcAgents"".""CarNumber"" AS ""AgentCarName"",
                         ""flOrders"".""Volume"",
                         ""flOrders"".""Amount""
                  FROM ""flOrders""
                  LEFT JOIN ""dcTanks"" ON ""dcTanks"".""TankID"" = ""flOrders"".""TankID""
                  LEFT JOIN ""dcHoses"" ON ""dcHoses"".""HoseID"" = ""flOrders"".""HoseID""
                  LEFT JOIN ""dcFuels"" ON ""dcFuels"".""FuelID"" = ""flOrders"".""FuelID""
                  LEFT JOIN ""dcPaymentModes"" ON ""dcPaymentModes"".""PaymentModeID"" = ""flOrders"".""PaymentModeID""
                  LEFT JOIN ""rgLimits"" ON ""rgLimits"".""DocID"" = ""flOrders"".""OrderID""
                  LEFT JOIN ""dcPartners"" ON ""dcPartners"".""PartnerID"" = ""rgLimits"".""PartnerID""
                  LEFT JOIN ""dcAgents"" ON ""dcAgents"".""AgentID"" = ""rgLimits"".""AgentID""
                  WHERE ""flOrders"".""SessionID"" = @id AND ""flOrders"".""Volume"" <> 0";

            var query = new OleDbCommand(sql, connection);
            query["id"].Value = id;

            using (var reader = query.ExecuteReader())
            {
                writer.WriteStartElement("OutcomesByRetail");

                while (reader.Read())
                {
                    writer.WriteStartElement("OutcomeByRetail");
                    writer.WriteAttributeString("DateTime", ((DateTime)(reader.GetValue(0))).ToString("dd.MM.yyyy HH:mm:ss"));
                    writer.WriteAttributeString("TankNum", reader.GetValue(1).ToString());
                    writer.WriteAttributeString("HoseName", reader.GetValue(2).ToString());
                    writer.WriteAttributeString("FuelName", reader.GetValue(3).ToString());
                    writer.WriteAttributeString("PaymentModeName", reader.GetValue(4).ToString());
                    writer.WriteAttributeString("PartnerName", reader.GetValue(5).ToString());
                    writer.WriteAttributeString("AgentName", reader.GetValue(6).ToString());
                    writer.WriteAttributeString("AgentCarName", reader.GetValue(7).ToString());
                    writer.WriteAttributeString("Volume", reader.GetValue(8).ToString());
                    writer.WriteAttributeString("Amount", reader.GetValue(9).ToString());
                    
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }
        }

        private void UploadSessionReportToFtp(string sessionReportFileName)
        {
            string ftpPath = $"ftp://{AppSettings.settings.FtpHost}{AppSettings.settings.FtpPath}{outputDirectory}/{Path.GetFileName(sessionReportFileName)}";

            if (AppSettings.settings.ExtendedLogs)
                Program.logger.Trace($"Выгрузка файла {sessionReportFileName} -> {ftpPath}");

            FtpWebRequest ftp = (FtpWebRequest)WebRequest.Create(ftpPath);
            ftp.Credentials = new NetworkCredential(AppSettings.settings.FtpLogin, AppSettings.settings.FtpPassword);
            ftp.Method = WebRequestMethods.Ftp.UploadFile;

            using (FileStream sourceStream = new FileStream(sessionReportFileName, FileMode.Open))
            {
                if (AppSettings.settings.ExtendedLogs)
                    Program.logger.Trace("    -> чтение локального файла");

                using (Stream requestStream = ftp.GetRequestStream())
                {
                    if (AppSettings.settings.ExtendedLogs)
                        Program.logger.Trace("    -> получение потока для записи на ftp");

                    byte[] buffer = new byte[10240];
                    int read;

                    while ((read = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        if (AppSettings.settings.ExtendedLogs)
                            Program.logger.Trace("    -> запись части файла на ftp");

                        requestStream.Write(buffer, 0, read);
                    }
                }
            }

            if (AppSettings.settings.ExtendedLogs)
                Program.logger.Trace($"Выгрузка файла {sessionReportFileName} завершена");
        }

        private void CheckCreateFtpDirectory()
        {
            string ftpPath = $"ftp://{AppSettings.settings.FtpHost}{AppSettings.settings.FtpPath}";
            string ftpDir;

            if (AppSettings.settings.ExtendedLogs)
                Program.logger.Trace($"Проверка/создание каталога {ftpPath}{outputDirectory}");

            FtpWebRequest ftp = (FtpWebRequest)WebRequest.Create(ftpPath);
            ftp.Credentials = new NetworkCredential(AppSettings.settings.FtpLogin, AppSettings.settings.FtpPassword);
            ftp.Method = WebRequestMethods.Ftp.ListDirectory;

            bool ftpPathExists = false;

            using (FtpWebResponse response = (FtpWebResponse)ftp.GetResponse())
            {
                if (AppSettings.settings.ExtendedLogs)
                    Program.logger.Trace($"    -> чтение каталога {AppSettings.settings.FtpPath}");

                using (Stream stream = response.GetResponseStream())
                {
                    if (AppSettings.settings.ExtendedLogs)
                        Program.logger.Trace("    -> получение ответного потока");

                    using (StreamReader reader = new StreamReader(stream, true))
                    {
                        if (AppSettings.settings.ExtendedLogs)
                            Program.logger.Trace("    -> получение объекта чтения ответного потока");

                        while (!reader.EndOfStream)
                        {
                            ftpDir = reader.ReadLine().ToUpper();

                            if (AppSettings.settings.ExtendedLogs)
                                Program.logger.Trace($"    -> прочитан каталог/файл {ftpDir}");

                            if (ftpDir == outputDirectory.ToUpper())
                            {
                                ftpPathExists = true;
                                break;
                            }
                        }
                    }
                }
            }

            if (ftpPathExists)
                return;

            if (AppSettings.settings.ExtendedLogs)
                Program.logger.Trace($"    -> каталог не найден, попытка создания");

            ftp = (FtpWebRequest)WebRequest.Create($"{ftpPath}{outputDirectory}");
            ftp.Credentials = new NetworkCredential(AppSettings.settings.FtpLogin, AppSettings.settings.FtpPassword);
            ftp.Method = WebRequestMethods.Ftp.MakeDirectory;
            ftp.GetResponse();

            if (AppSettings.settings.ExtendedLogs)
                Program.logger.Trace($"    -> создание каталога завершено");
        }

        public bool CheckIBProvider()
        {
            if (AppSettings.settings.ExtendedLogs)
                Program.logger.Trace($"Проверка наличия библиотеки lcpi.ibprovider_v3_vc12xp_w32_free_i.dll");

            if (Type.GetTypeFromProgID("LCPI.IBProvider.3.Free") == null)
            {
                string dllPath = Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "lcpi.ibprovider_v3_vc12xp_w32_free_i.dll");
                if (!File.Exists(dllPath))
                {
                    MessageBox.Show("Отсутствует библиотека lcpi.ibprovider_v3_vc12xp_w32_free_i.dll!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                try
                {
                    IntPtr hLib = LoadLibrary(dllPath);
                    if (hLib == IntPtr.Zero)
                        throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());

                    IntPtr dllEntryPoint = GetProcAddress(hLib, "DllRegisterServer");
                    if (dllEntryPoint == IntPtr.Zero)
                        throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());

                    PointerToMethodInvoker dllRegisterDelegate =
                            (PointerToMethodInvoker)Marshal.GetDelegateForFunctionPointer(dllEntryPoint, typeof(PointerToMethodInvoker));
                    dllRegisterDelegate();

                    FreeLibrary(hLib);

                    if (Type.GetTypeFromProgID("LCPI.IBProvider.3.Free") == null)
                        throw new Exception("Не удалось зарегистрировать библиотеку lcpi.ibprovider_v3_vc12xp_w32_free_i.dll!");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Ошибка регистрации библиотеки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }
    }
}
