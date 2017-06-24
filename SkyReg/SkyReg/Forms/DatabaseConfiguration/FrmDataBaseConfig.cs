using ComponentFactory.Krypton.Toolkit;
using DataLayer;
using DataLayer.Utils;
using SkyReg.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace SkyReg.Forms.DatabaseConfiguration
{
    public partial class FrmDataBaseConfig : KryptonForm
    {
        #region Pola Prywatne

        private ErrorProvider validateControl = new ErrorProvider();
        public static DatabaseAccess ConfigSettings = new DatabaseAccess();
        private bool DbResult = false;
        private BackgroundWorker bgw;
        #endregion

        #region Konstruktor

        public FrmDataBaseConfig()
        {
            InitializeComponent();

            this.StyleManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.StyleManager.GlobalStrings.Abort = "Przerwij";
            this.StyleManager.GlobalStrings.Cancel = "Wyjdź";
            this.StyleManager.GlobalStrings.Close = "Zamknij";
            this.StyleManager.GlobalStrings.Ignore = "Ignoruj";
            this.StyleManager.GlobalStrings.No = "Nie";
            this.StyleManager.GlobalStrings.Retry = "Próbuj ponownie";
            this.StyleManager.GlobalStrings.Today = "Dzisiaj";
            this.StyleManager.GlobalStrings.Yes = "Tak";

            LoadDBSettings();
        }

        #endregion

        #region Zdarzenia

        private void btnSaveCfg_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Metody prywatne

        public void LoadDBSettings()
        {
            if (!File.Exists(SkyRegUser.DatabaseConfigFile))
            {
                Directory.CreateDirectory(SkyRegUser.GlobalPathFile);
            }
            if (File.Exists(SkyRegUser.DatabaseConfigFile))
            {
                TextReader tr = new StreamReader(SkyRegUser.DatabaseConfigFile);

                XmlDocument doc = new XmlDocument();
                doc.Load(SkyRegUser.DatabaseConfigFile);
                XmlSerializer deserializer;

                //odczyt ustawień z nowej wersji pliku
                ConfigSettings = new DatabaseAccess();
                deserializer = new XmlSerializer(ConfigSettings.GetType());
                
                ConfigSettings = ((DatabaseAccess)deserializer.Deserialize(tr));
                string password = ConfigSettings.Password.DecryptString();
                string login = ConfigSettings.User.DecryptString();
                txtDatabase.Text = ConfigSettings.DataBaseName;
                txtServer.Text = ConfigSettings.ServerName;
                txtUserName.Text = login;
                txtPassword.Text = password;
                tr.Close();

                new DatabaseConfig(ConfigSettings);
                SkyRegUser.IsDbExists = true;
            }
            else
            {
                txtServer.Text = string.Format("{0}\\SQLEXPRESS", Environment.MachineName);
            }
        }

        private bool ValidateControls()
        {

            bool result = true;
            validateControl.Clear();
            validateControl.BlinkRate = 250;
            if (string.IsNullOrEmpty(txtServer.Text))
            {
                validateControl.SetError(txtServer, "!");
                result = false;
            }
            if (string.IsNullOrEmpty(txtDatabase.Text))
            {
                validateControl.SetError(txtDatabase, "!");
                result = false;
            }
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                validateControl.SetError(txtUserName, "!");
                result = false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                validateControl.SetError(txtPassword, "!");
                result = false;
            }

            return result;
        }

        private void SaveConfig()
        {
            using (TextWriter TW = new StreamWriter(SkyRegUser.DatabaseConfigFile, false, Encoding.GetEncoding("windows-1250")))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DatabaseAccess));
                string password = txtPassword.Text;
                string login = txtUserName.Text;
                ConfigSettings.DataBaseName = txtDatabase.Text.Trim();
                ConfigSettings.ServerName = txtServer.Text.Trim();
                ConfigSettings.User = login.EncryptString();
                ConfigSettings.Password = password.EncryptString();

                new DatabaseConfig(ConfigSettings);

                serializer.Serialize(TW, ConfigSettings);
                TW.Close();

                ConfigSettings.User = login;
                ConfigSettings.Password = password;
                new DatabaseConfig(ConfigSettings);
                SkyRegUser.IsDbExists = true;
                KryptonMessageBox.Show("Plik konfiguracyjny został zapisany!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        #endregion

        #region Baza Danych SQL - Generowanie Bazy itp.

        private void btGenerateDataBase_Click(object sender, EventArgs e)
        {
            string[] queryBuilder = Resources.DLModel_edmx.Split(new string[] { "GO" }, StringSplitOptions.None);
            progresBarDB.Maximum = queryBuilder.Length;

            if (!ValidateControls()) return;
            bgw = new BackgroundWorker();
            bgw.WorkerReportsProgress = true;
            bgw.DoWork += Bgw_DoWork;
            bgw.ProgressChanged += Bgw_ProgressChanged;
            bgw.RunWorkerAsync();

        }

        private void Bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progresBarDB.Value = e.ProgressPercentage;
        }

        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            ExecuteSqlScripts();
        }

        private void ExecuteSqlScripts()
        {
            SqlConnectionStringBuilder conBuilder = new SqlConnectionStringBuilder();
            conBuilder.UserID = txtUserName.Text;
            conBuilder.Password = txtPassword.Text;
            conBuilder.InitialCatalog = "Master";
            conBuilder.DataSource = txtServer.Text;
            try
            {
                DbResult = DatabaseManager.CreateDataBase(Resources.Create_DataBase.Replace("DataBaseName", txtDatabase.Text), conBuilder.ConnectionString);
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!DbResult)
            {

                KryptonMessageBox.Show("Baza danych już istnieje !", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            conBuilder = new SqlConnectionStringBuilder();
            conBuilder.UserID = txtUserName.Text;
            conBuilder.Password = txtPassword.Text;
            conBuilder.InitialCatalog = txtDatabase.Text;
            conBuilder.DataSource = txtServer.Text;

            string[] queryBuilder = Resources.DLModel_edmx.Split(new string[] { "GO" }, StringSplitOptions.None);

            int i = 0;
            foreach (string query in queryBuilder)
            {
                DatabaseManager.GenerateDatabase(query.Replace("DataBaseName", txtDatabase.Text), conBuilder.ConnectionString);
                bgw.ReportProgress(i++);
            }

            KryptonMessageBox.Show(string.Format("Baza danych {0} została utworzona !", txtDatabase.Text), "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        #endregion


    }
}
