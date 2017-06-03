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

namespace SkyReg.MainForm
{
    public partial class FrmLogin : KryptonForm
    {
        private LoginRepository _loginRepository = new LoginRepository();
        private readonly string documentsPath = Environment.GetFolderPath((Environment.SpecialFolder.LocalApplicationData)) + @"\SkyReg";
        private ErrorProvider validateControl = new ErrorProvider();

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
                CommonMethods.CheckInternetConnection();

                using (var db = new DLModelContainer())
                    db.Database.Initialize(true);

                if (File.Exists(documentsPath + @"\UserConfig.xml"))
                {
                    using (StreamReader tr = new StreamReader(documentsPath + @"\UserConfig.xml", Encoding.GetEncoding("windows-1250")))
                    {
                        XmlSerializer deserializer = new XmlSerializer(typeof(BaseModel));
                        var userData = (BaseModel)deserializer.Deserialize(tr);
                        if (userData != null)
                            Txt_Login.Text = userData.Login;
                    };
                }

               
            }

            catch (Exception)
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
            this.Cursor = Cursors.WaitCursor;
            LogIn();
            this.Cursor = Cursors.Default;
        }

        private void LogIn()
        {
            string login = Txt_Login.Text;
            string password = Txt_Pasword.Text;

            try
            {

                if (ValidateControls())
                {
                    var user = _loginRepository.GetUser(login, password.EncryptString());
                    if (user != null)
                    {
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
            if (!Directory.Exists(documentsPath))
                Directory.CreateDirectory(documentsPath);

            string saveFile = documentsPath + @"\UserConfig.xml";
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
    }
}
