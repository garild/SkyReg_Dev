using DataLayer;
using DataLayer.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace DepartureDiagram
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SkyRegUser.GlobalPathFile = Environment.GetFolderPath((Environment.SpecialFolder.LocalApplicationData)) + @"\SkyReg";
            SkyRegUser.DatabaseConfigFile = string.Format("{0}\\DatabaseConfig.xml", SkyRegUser.GlobalPathFile);
            SkyRegUser.UserConfigFile = string.Format("{0}\\UserConfig.xml", SkyRegUser.GlobalPathFile);
            SkyRegUser.LocalMachineName = Environment.MachineName;
            Version curVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            SkyRegUser.AppVer = $"wersja {curVersion}";

            LoadDatabaseSettings();

            Application.Run(new Departures());
        }

        private static void LoadDatabaseSettings()
        {
            using (TextReader tr = new StreamReader(SkyRegUser.DatabaseConfigFile))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(SkyRegUser.DatabaseConfigFile);
                XmlSerializer deserializer;

                //odczyt ustawień z nowej wersji pliku
                var ConfigSettings = new DatabaseAccess();
                deserializer = new XmlSerializer(ConfigSettings.GetType());
                ConfigSettings = ((DatabaseAccess)deserializer.Deserialize(tr));
                tr.Close();
                ConfigSettings.Password = ConfigSettings.Password.DecryptString();
                ConfigSettings.User = ConfigSettings.User.DecryptString();
                new DatabaseConfig(ConfigSettings);
            }
        }
    }
}
