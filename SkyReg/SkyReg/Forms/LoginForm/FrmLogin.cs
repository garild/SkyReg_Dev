using ComponentFactory.Krypton.Toolkit;
using SkyReg.BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer.Utils;
using DataLayer;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using SkyReg.Extensions;
using SkyReg.Utils;
using SkyReg.Common.FluentValidator;
using FluentValidation.Results;
using System.Xml;
using SkyReg.Forms.DatabaseConfiguration;
using DataLayer.Result.Repository;

namespace SkyReg.MainForm
{
    public partial class FrmLogin : KryptonForm
    {
        private ErrorProvider validateControl = new ErrorProvider();
        private ValidationResult _validator = null;
        private  bool IsDbExists = false;
        public FrmLogin()
        {
            SkyRegUser.GlobalPathFile = Environment.GetFolderPath((Environment.SpecialFolder.LocalApplicationData)) + @"\SkyReg";
            SkyRegUser.DatabaseConfigFile = string.Format("{0}\\DatabaseConfig.xml", SkyRegUser.GlobalPathFile);
            SkyRegUser.UserConfigFile = string.Format("{0}\\UserConfig.xml", SkyRegUser.GlobalPathFile);
            SkyRegUser.LocalMachineName = Environment.MachineName;

            InitializeComponent();
            LoadSettings();
        }

        private bool ValidateControls()
        {
            bool result = true;
            validateControl.Clear();
            validateControl.BlinkRate = 250;
            if (!IsDbExists)
            {
                KryptonMessageBox.Show("Nie znaleziono pliku kofiguracyjnego do bazy danych. Proszę skofigurować base SQL!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Information);
                result = false;
            }
            if (string.IsNullOrEmpty(Txt_Login.Text))
            {
                validateControl.SetError(Txt_Login, "!");
                result = false;
            }
            if (string.IsNullOrEmpty(Txt_Pasword.Text))
            {
                validateControl.SetError(Txt_Pasword, "!");
                result = false;
            }
           
            return result;
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

                if (File.Exists(SkyRegUser.UserConfigFile))
                {
                    using (StreamReader tr2 = new StreamReader(SkyRegUser.UserConfigFile, Encoding.GetEncoding("windows-1250")))
                    {
                        XmlSerializer deserializerUser = new XmlSerializer(typeof(BaseModel));
                        var userData = (BaseModel)deserializerUser.Deserialize(tr2);
                        if (userData != null)
                            Txt_Login.Text = userData.Login;
                    };
                }
                
                if (!string.IsNullOrEmpty(DatabaseConfig.ConnectionString))
                {
                    FirstTimeRun.CheckAndAdd();
                }
            }

            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Cancel;
            }

        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            LogIn();
        }

        private void LogIn()
        {
            string login = Txt_Login.Text;
            string password = Txt_Pasword.Text;

            try
            {
                var us = new User();
                _validator = new UserValidator().Validate(us);

                if (ValidateControls())
                {
                    LoginRepository _loginRepository = new LoginRepository();
                    var user = _loginRepository.GetUser(login, password.EncryptString());
                    if (user != null)
                    {
                        SkyRegUser.UserLogin = user.Login;
                        SkyRegUser.UserId = user.Id;
                        SaveUserConfig(user);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        KryptonMessageBox.Show("Podany login lub hasło nie są prawidłowe", "Błąd logowania", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message.ToString(), "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void SaveUserConfig(User user)
        {
            string saveFile = SkyRegUser.GlobalPathFile + @"\UserConfig.xml";
            CreateSkyregFolder();

            var userConfig = new BaseModel();
            using (StreamWriter TW = new StreamWriter(saveFile, false, Encoding.GetEncoding("windows-1250")))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(BaseModel));
                userConfig.Login = user.Login;
                userConfig.UserId = user.Id;
                userConfig.Roles = new List<UsersRole>() { new UsersRole() { Camera = true, Id = 2, Name = "Shit", SpecialType = 1, TandemPassenger = true, TandemPilot = true, Value = 1500.00 } }; //TODO Usunąć test dodać user.Roles
                serializer.Serialize(TW, userConfig);
            }

        }

        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_Login.Text))
                Txt_Login.Focus();
            else
                Txt_Pasword.Focus();
        }

        private void Txt_Pasword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                LogIn();
        }

        private void CheckDatabaseConfig()
        {
            if (!File.Exists(SkyRegUser.DatabaseConfigFile))
            {
                IsDbExists = false;
                KryptonMessageBox.Show("Nie znaleziono pliku kofiguracyjnego do bazy danych. Proszę skofigurować base SQL!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnDatabaseCfg_Click(object sender, EventArgs e)
        {
            FrmDataBaseConfig frmDataBaseConfig = new FrmDataBaseConfig();
            frmDataBaseConfig.ShowDialog();
        }
    }
}
