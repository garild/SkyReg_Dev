using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer.Utils;
using DataLayer;
using System.IO;
using System.Xml.Serialization;
using SkyReg.Extensions;
using FluentValidation.Results;
using System.Xml;
using SkyReg.Forms.DatabaseConfiguration;
using DataLayer.Result.Repository;
using SkyReg.Common.Extensions;
using SkyRegEnums;

namespace SkyReg.MainForm
{
    public partial class FrmLogin : KryptonForm
    {
        private ErrorProvider validateControl = new ErrorProvider();
        private  bool IsDbExists = false;

        public FrmLogin()
        {
            InitializeComponent();
            LoadSettings();
        }

        private bool ValidateControls()
        {
            bool result = true;
            validateControl.Clear();
            validateControl.BlinkRate = 250;
            if (!SkyRegUser.IsDbExists)
            {
                KryptonMessageBox.Show("Nie znaleziono pliku kofiguracyjnego do bazy danych. Proszę skofigurować base SQL!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Information);
                result = false;
            }
            if (!Txt_Login.Text.HasValue())
            {
                validateControl.SetError(Txt_Login, "!");
                result = false;
            }
            if (!Txt_Pasword.Text.HasValue())
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

            catch (Exception)
            {
                KryptonMessageBox.Show("Wystąpił błąd podczas wczytywania pliku z ustawieniami", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            string login = Txt_Login.Text.ToLower();
            string password = Txt_Pasword.Text;

            try
            {
                if (ValidateControls())
                {
                    using (var _loginRepo = new SkyRegContextRepository<User>())
                    {
                        var user = _loginRepo.GetAll(Tuple.Create(nameof(Operator),"","")).Value?.Where(p => p.Login.ToLower() == login 
                        && p.Password == password.EncryptString() 
                        && p.Operator.Any(o=>o.Type == (int)OperatorTypes.Operator)).FirstOrDefault();
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
            frmDataBaseConfig = FormsOpened<FrmDataBaseConfig>.IsShowDialog(frmDataBaseConfig);
            frmDataBaseConfig.ShowDialog();
        }

        private FrmDataBaseConfig frmDataBaseConfig = null;
    }
}
