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
using ComponentFactory.Krypton.Toolkit;
using System.Threading.Tasks;
using System.Threading;

namespace SkyReg.Forms.SplashScreen
{
    public partial class SplashScreen : KryptonForm
    {
        private bool IsDbExists = false;
        private int blockProgerss => 25;
        private object _lock = new object();
        private BackgroundWorker bgw = new BackgroundWorker();
        string error = "";
        public SplashScreen()
        {
            InitializeComponent();

            SkyRegUser.GlobalPathFile = Environment.GetFolderPath((Environment.SpecialFolder.LocalApplicationData)) + @"\SkyReg";
            SkyRegUser.DatabaseConfigFile = string.Format("{0}\\DatabaseConfig.xml", SkyRegUser.GlobalPathFile);
            SkyRegUser.UserConfigFile = string.Format("{0}\\UserConfig.xml", SkyRegUser.GlobalPathFile);
            SkyRegUser.LocalMachineName = Environment.MachineName;
            Version curVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            labAppVersion.Text = $"wersja {curVersion}";
            SkyRegUser.AppVer = labAppVersion.Text;

            StartLoading();
        }

        private void StartLoading()
        {
            try
            {
                bgw.WorkerReportsProgress = true;
                bgw.DoWork += Bgw_DoWork;
                bgw.ProgressChanged += Bgw_ProgressChanged;
                bgw.RunWorkerCompleted += Bgw_RunWorkerCompleted;
                bgw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Msg.Show(ex.Message);
                this.DialogResult = DialogResult.Cancel;
            }
           
        }

        private void Bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            try
            {
                bgw.ReportProgress(25);

                Thread.Sleep(500);

                CreateSkyregFolder();
                bgw.ReportProgress(75);

                if (File.Exists(SkyRegUser.DatabaseConfigFile))
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
                        SkyRegUser.IsDbExists = true;
                    }

                    if (!string.IsNullOrEmpty(DatabaseConfig.ConnectionString))
                    {
                        FirstTimeRun.CheckAndAdd();
                    }
                }

                bgw.ReportProgress(100);
                Thread.Sleep(100);
            }

            catch (Exception ex)
            {
                Msg.Show(ex.Message);
                this.DialogResult = DialogResult.Cancel;
            }

        }

        private void CreateSkyregFolder()
        {
            if (!Directory.Exists(SkyRegUser.GlobalPathFile))
            {
                Directory.CreateDirectory(SkyRegUser.GlobalPathFile);

            }
           
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
