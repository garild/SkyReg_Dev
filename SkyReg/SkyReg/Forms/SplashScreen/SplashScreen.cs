using AC.ExtendedRenderer.Toolkit;
using DataLayer;
using DataLayer.Utils;
using MetroFramework.Forms;
using SkyReg.Utils;
using System;
using Msg = AC.ExtendedRenderer.Toolkit.KryptonMessageBox;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace SkyReg.Forms.SplashScreen
{
    public partial class SplashScreen : MetroForm
    {
        private Timer _timer = new Timer();
        private bool IsDbExists = false;

        public SplashScreen()
        {
            InitializeComponent();

            SkyRegUser.GlobalPathFile = Environment.GetFolderPath((Environment.SpecialFolder.LocalApplicationData)) + @"\SkyReg";
            SkyRegUser.DatabaseConfigFile = string.Format("{0}\\DatabaseConfig.xml", SkyRegUser.GlobalPathFile);
            SkyRegUser.UserConfigFile = string.Format("{0}\\UserConfig.xml", SkyRegUser.GlobalPathFile);
            SkyRegUser.LocalMachineName = Environment.MachineName;

            StarLoading();
        }

        private void StarLoading()
        {
            this.Opacity = 100;
            _timer.Enabled = true;
            _timer.Interval = 4000;
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }
        private void ValidateTask()
        {
            
        }
        private void _timer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void LoadSettings()
        {
            try
            {
                Version curVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                string version = curVersion.ToString();

                SkyRegUser.AppVer = version;

                CommonMethods.CheckInternetConnection();

                CreateSkyregFolder();
                CheckDatabaseConfig();

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


                if (!string.IsNullOrEmpty(DatabaseConfig.ConnectionString))
                {
                    FirstTimeRun.CheckAndAdd();
                }
            }

            catch (Exception)
            {
                this.DialogResult = DialogResult.Cancel;
            }

        }

        private void CheckDatabaseConfig()
        {
            if (!File.Exists(SkyRegUser.DatabaseConfigFile))
            {
                IsDbExists = false;
            }
            else
                IsDbExists = true;

        }
        private void CreateSkyregFolder()
        {
            if (!Directory.Exists(SkyRegUser.GlobalPathFile))
            {
                Directory.CreateDirectory(SkyRegUser.GlobalPathFile);
            }

        }
    }
}
