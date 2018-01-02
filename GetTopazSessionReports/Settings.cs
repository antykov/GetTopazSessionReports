using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace GetTopazSessionReports
{
    public class Settings
    {
        [XmlElement]
        public string FirebirdServerName;
        [XmlElement]
        public string FirebirdDatabaseFile;
        [XmlElement]
        public string FirebirdUserName;
        [XmlElement]
        public string FirebirdPassword;

        [XmlElement]
        public string FtpHost;
        [XmlElement]
        public string FtpLogin;
        [XmlElement]
        public string FtpPassword;

        [XmlElement]
        public DateTime StartDate;
        [XmlElement]
        public long LastSession;

        public Settings()
        {
        }
    }

    public static class AppSettings
    {
        public static Settings settings = new Settings();

        public static string connectionString { get {
                StringBuilder result = new StringBuilder();
                result.Append($"Provider=LCPI.IBProvider.3.Free;");
                result.Append($"User ID={AppSettings.settings.FirebirdUserName};");
                result.Append($"Password={AppSettings.settings.FirebirdPassword};");
                result.Append($"Location=\"{AppSettings.settings.FirebirdServerName}:{AppSettings.settings.FirebirdDatabaseFile}\";");
                result.Append($"dbclient_library=fbclient.dll;");
                result.Append($"auto_commit = true;");
                result.Append($"named_param_prefix='@'");

                return result.ToString();
            }
        }

        public static void LoadSettings()
        {
            string settingsFilePath = Path.Combine(Environment.CurrentDirectory, "settings.xml");
            if (!File.Exists(settingsFilePath))
            {
                CreateTemplateSettingsFile(settingsFilePath);
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Settings));
            using (TextReader textReader = new StreamReader(settingsFilePath, Encoding.GetEncoding(1251)))
            {
                settings = (Settings)xmlSerializer.Deserialize(textReader);
            }
        }

        public static void SaveSettings()
        {
            string settingsFilePath = Path.Combine(Environment.CurrentDirectory, "settings.xml");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Settings));

            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Encoding = Encoding.GetEncoding(1251);
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.IndentChars = ("\t");
            xmlWriterSettings.OmitXmlDeclaration = true;

            using (XmlWriter xmlWriter = XmlWriter.Create(settingsFilePath, xmlWriterSettings))
            {
                xmlSerializer.Serialize(xmlWriter, settings);
            }
        }

        public static bool CheckSettings()
        {
            if (String.IsNullOrEmpty(settings.FirebirdServerName) ||
                String.IsNullOrEmpty(settings.FirebirdUserName) ||
                String.IsNullOrEmpty(settings.FirebirdPassword) ||
                String.IsNullOrEmpty(settings.FirebirdDatabaseFile) ||
                String.IsNullOrEmpty(settings.FtpHost) ||
                String.IsNullOrEmpty(settings.FtpLogin) ||
                String.IsNullOrEmpty(settings.FtpPassword))

                return false;

            return true;
        }

        private static void CreateTemplateSettingsFile(string settingsFilePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Settings));

            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Encoding = Encoding.GetEncoding(1251);
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.IndentChars = ("\t");
            xmlWriterSettings.OmitXmlDeclaration = true;

            string topazFile = "";
            string topazDir = Directory.GetDirectories("C:\\Program Files\\").Where(w => w.ToUpper().Contains("TOPAZAZS-")).FirstOrDefault() ?? "";
            if (!string.IsNullOrEmpty(topazDir))
                topazFile = Directory.GetFiles(topazDir).Where(w => Path.GetFileName(w).ToUpper() == "TOPAZAZS.FDB").FirstOrDefault() ?? "";

            Settings templateSettings = new Settings
            {
                FirebirdServerName = "127.0.0.1",
                FirebirdDatabaseFile = File.Exists(topazFile) ? topazFile : "",
                FirebirdUserName = "SYSDBA",
                FirebirdPassword = "electro",
                FtpHost = "files.000webhost.com",
                FtpLogin = "progasvrn",
                FtpPassword = "Tuypeor2017ihv",
                StartDate = new DateTime(2017, 12, 1),
                LastSession = 0
            };

            using (XmlWriter xmlWriter = XmlWriter.Create(settingsFilePath, xmlWriterSettings))
            {
                xmlSerializer.Serialize(xmlWriter, templateSettings);
            }
        }
    }

}
