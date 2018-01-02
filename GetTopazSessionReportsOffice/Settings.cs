using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace GetTopazSessionReportsOffice
{
    public class Settings
    {
        [XmlElement]
        public string FtpHost;
        [XmlElement]
        public string FtpLogin;
        [XmlElement]
        public string FtpPassword;

        [XmlElement]
        public string DownloadPath;

        public Settings()
        {
        }
    }

    public static class AppSettings
    {
        public static Settings settings = new Settings();

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
            if (String.IsNullOrEmpty(settings.FtpHost) ||
                String.IsNullOrEmpty(settings.FtpLogin) ||
                String.IsNullOrEmpty(settings.FtpPassword) ||
                !Directory.Exists(settings.DownloadPath))

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

            Settings templateSettings = new Settings
            {
                FtpHost = "files.000webhost.com",
                FtpLogin = "progasvrn",
                FtpPassword = "Tuypeor2017ihv",
                DownloadPath = Environment.CurrentDirectory
            };

            using (XmlWriter xmlWriter = XmlWriter.Create(settingsFilePath, xmlWriterSettings))
            {
                xmlSerializer.Serialize(xmlWriter, templateSettings);
            }
        }
    }

}
