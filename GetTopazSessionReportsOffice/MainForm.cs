using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetTopazSessionReportsOffice
{
    public partial class MainForm : Form
    {
        bool CanClose = false;
        bool IsOkPressed = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
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
            if (!CanClose)
            {
                e.Cancel = true;
                Hide();
                ShowInTaskbar = false;
                timer.Enabled = true;

                if (IsOkPressed)
                    GetSessionReports();
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

        private void menuItemDownloadReports_Click(object sender, EventArgs e)
        {
            GetSessionReports();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            CanClose = true;

            Close();
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = DownloadPath.Text;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                DownloadPath.Text = folderBrowserDialog.SelectedPath;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            AppSettings.settings.FtpHost = FtpHost.Text;
            AppSettings.settings.FtpLogin = FtpLogin.Text;
            AppSettings.settings.FtpPassword = FtpPassword.Text;
            AppSettings.settings.FtpPath = FtpPath.Text;
            AppSettings.settings.DownloadPath = DownloadPath.Text;

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
            if (GetSessionReports())
            {
                timer.Interval = 1800000;
            }
            else
            {

                if (timer.Interval > 600000)
                    timer.Interval -= 600000;
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            UpdateControls();
        }

        void UpdateControls()
        {
            FtpHost.Text = AppSettings.settings.FtpHost;
            FtpLogin.Text = AppSettings.settings.FtpLogin;
            FtpPassword.Text = AppSettings.settings.FtpPassword;
            FtpPath.Text = AppSettings.settings.FtpPath;
            DownloadPath.Text = AppSettings.settings.DownloadPath;
        }

        private bool GetSessionReports()
        {
            bool result = true;

            List<string> ftpFiles;

            try
            {
                ftpFiles = ListFtpDirectory("TopazReports/")
                    .Select(s => new { fileName = s, fileNameUpper = s.ToUpper() })
                    .Where(w => w.fileNameUpper.Length > 4 && w.fileNameUpper.Substring(w.fileNameUpper.Length - 4) == ".XML")
                    .Select(s => s.fileName)
                    .ToList<string>();
            }
            catch (Exception e)
            {
                notifyIcon.ShowBalloonTip(3000, "Ошибка чтения файлов с ftp!", e.Message, ToolTipIcon.Error);
                return false;
            }

            foreach (var file in ftpFiles)
            {
                try
                {
                    DownloadFileFromFtp("TopazReports/", file, AppSettings.settings.DownloadPath);
                    DeleteFileFromFtp("TopazReports/", file);
                }
                catch (Exception e)
                {
                    notifyIcon.ShowBalloonTip(3000, $"Ошибка скачивания файла {file}!", e.Message, ToolTipIcon.Error);
                    result = false;
                }
            }

            return result;
        }

        private List<string> ListFtpDirectory(string ftpPath)
        {
            var list = new List<string>();

            StringBuilder uri = new StringBuilder();
            uri.Append("ftp://");
            uri.Append(AppSettings.settings.FtpHost);
            uri.Append(AppSettings.settings.FtpPath);
            uri.Append(String.IsNullOrWhiteSpace(AppSettings.settings.FtpPath) ? "/" : ftpPath);

            FtpWebRequest ftp = (FtpWebRequest)WebRequest.Create(uri.ToString());
            ftp.Credentials = new NetworkCredential(AppSettings.settings.FtpLogin, AppSettings.settings.FtpPassword);
            ftp.Method = WebRequestMethods.Ftp.ListDirectory;

            using (var response = (FtpWebResponse)ftp.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream, true))
                    {
                        while (!reader.EndOfStream)
                        {
                            list.Add(reader.ReadLine());
                        }
                    }
                }
            }

            return list;
        }

        private void DownloadFileFromFtp(string ftpDirectory, string ftpFileName, string filePath)
        {
            StringBuilder uri = new StringBuilder();
            uri.Append("ftp://");
            uri.Append(AppSettings.settings.FtpHost);
            uri.Append(AppSettings.settings.FtpPath);
            uri.Append(String.IsNullOrWhiteSpace(AppSettings.settings.FtpPath) ? "/" : ftpDirectory);
            uri.Append(Path.GetFileName(ftpFileName));

            FtpWebRequest ftp = (FtpWebRequest)WebRequest.Create(uri.ToString());
            ftp.Credentials = new NetworkCredential(AppSettings.settings.FtpLogin, AppSettings.settings.FtpPassword);
            ftp.Method = WebRequestMethods.Ftp.DownloadFile;

            using (FtpWebResponse response = (FtpWebResponse)ftp.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding(1251)))
                    {
                        File.WriteAllText(Path.Combine(filePath, ftpFileName), reader.ReadToEnd(), Encoding.GetEncoding(1251));
                        reader.Close();
                    }
                }
                response.Close();
            }
        }

        private static void DeleteFileFromFtp(string ftpDirectory, string ftpFileName)
        {
            StringBuilder uri = new StringBuilder();
            uri.Append("ftp://");
            uri.Append(AppSettings.settings.FtpHost);
            uri.Append(AppSettings.settings.FtpPath);
            uri.Append(String.IsNullOrWhiteSpace(AppSettings.settings.FtpPath) ? "/" : ftpDirectory);
            uri.Append(Path.GetFileName(ftpFileName));

            FtpWebRequest ftp = (FtpWebRequest)WebRequest.Create(uri.ToString());
            ftp.Credentials = new NetworkCredential(AppSettings.settings.FtpLogin, AppSettings.settings.FtpPassword);
            ftp.Method = WebRequestMethods.Ftp.DeleteFile;

            using (FtpWebResponse response = (FtpWebResponse)ftp.GetResponse())
            {
                response.Close();
            }
        }
    }
}
