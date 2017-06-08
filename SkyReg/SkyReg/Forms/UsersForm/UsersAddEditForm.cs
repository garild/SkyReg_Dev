using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer;
using DataLayer.Result.Repository;

namespace SkyReg
{
    public partial class UsersAddEditForm : KryptonForm
    {
        public Enum_FormState FormState { get; set; }
        public int? IdUser { get; set; }
        public int UserGroup { get; set; }

        public EventHandler EventHandlerAddEditUser;

        public UsersAddEditForm()
        {
            InitializeComponent();
        }

        private void UsersAddEditForm_Load(object sender, EventArgs e)
        {
            LoadAllUsersTypes();
            if (FormState == Enum_FormState.Edit)
                LoadEditedUserData();
        }

        private void LoadEditedUserData()
        {
            using(DLModelContainer model = new DLModelContainer())
            {
                User usr = model.User.Where(p => p.Id == IdUser).FirstOrDefault();
                if (usr != null)
                {
                    txtCertyfikate.Text = usr.Certificate;
                    txtCity.Text = usr.City;
                    txtEmail.Text = usr.Email;
                    txtFacebook.Text = usr.FaceBook;
                    txtFirstName.Text = usr.FirstName;
                    txtLogin.Text = usr.Login;
                    txtPassword.Text = usr.Password;
                    txtPhone.Text = usr.Phone;
                    txtStreet.Text = usr.Street;
                    txtStreetNr.Text = usr.StreetNr;
                    txtSurName.Text = usr.SurName;
                    txtZipCode.Text = usr.ZipCode;
                    dateCertDate.Value = usr.CertDate.Value;
                }
            }
        }

        private void LoadAllUsersTypes()
        {
            chkListUserTypes.Items.Clear();
            using(DLModelContainer model = new DLModelContainer())
            {
                List<UsersType> allUsrTypes = model.UsersType.ToList();
                if (FormState == Enum_FormState.Edit)
                {
                    List<UsersType> currentUsrTypes = model.User.Where(p => p.Id == IdUser).SelectMany(p => p.UsersType).ToList();
                    foreach (UsersType item in allUsrTypes)
                    {
                        if (currentUsrTypes.Any(p => p.Id == item.Id) == true)
                            chkListUserTypes.Items.Add(item.Name, true);
                        else
                            chkListUserTypes.Items.Add(item.Name, false);
                    }
                }
                else
                {
                    foreach(UsersType item in allUsrTypes)
                    {
                        chkListUserTypes.Items.Add(item.Name, false);
                    }
                }
            }
        }

        private void btnCheckLogin_Click(object sender, EventArgs e)
        {
            using(DLModelContainer model = new DLModelContainer())
            {
                bool isUser = model.User.Any(p => p.Login == txtLogin.Text);
                if (isUser == false)
                {
                    KryptonMessageBox.Show("Login wolny.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    KryptonMessageBox.Show("Ten login jest już w użyciu!", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateAddEditUser())
            {
                SaveUser();
            }
        }

        private void SaveUser()
        {
            using (DLModelContainer model = new DLModelContainer())
            {
                User usr;

                if (FormState == Enum_FormState.Add)
                {
                    usr = new User();
                }
                else
                {
                    usr = model.User.Include("UsersType").Where(p => p.Id == IdUser).FirstOrDefault();
                }

                List<UsersType> listUsersTypes = new List<UsersType>();
                foreach(var item in chkListUserTypes.CheckedItems)
                {
                    listUsersTypes.Add(model.UsersType.Where(p => p.Name == item.ToString()).FirstOrDefault());
                }

                if (txtCertyfikate.Text != string.Empty)
                    usr.CertDate = dateCertDate.Value.Date;
                else
                    usr.CertDate = DateTime.MaxValue;
                usr.Certificate = txtCertyfikate.Text;
                usr.City = txtCity.Text;
                usr.Email = txtEmail.Text;
                usr.FaceBook = txtFacebook.Text;
                usr.FirstName = txtFirstName.Text;
                usr.Group = model.Group.Where(p => p.Id == UserGroup).First();
                usr.Login = txtLogin.Text;
                usr.Password = txtPassword.Text;
                usr.Phone = txtPhone.Text;
                usr.Street = txtStreet.Text;
                usr.StreetNr = txtStreetNr.Text;
                usr.SurName = txtSurName.Text;
                usr.ZipCode = txtZipCode.Text;
                usr.UsersType = listUsersTypes;
                if (FormState == Enum_FormState.Add)
                {
                    model.User.Add(usr);
                }
                model.SaveChanges();
                EventHandlerAddEditUser.Invoke(null, null);
                var a = usr;
                this.Close();
            }
        }

        private bool ValidateAddEditUser()
        {
            bool result = true;
            errorProvider1.Clear();

            using(DLModelRepository<User> _ctxUsr = new DLModelRepository<User>())
            {
                
                if(txtFirstName.Text == string.Empty)
                {
                    errorProvider1.SetError(txtFirstName, "Pole nie może być puste!");
                    result = false;
                }
                if(txtSurName.Text == string.Empty)
                {
                    errorProvider1.SetError(txtSurName, "Pole nie może być puste!");
                    result = false;
                }
                if( _ctxUsr.GetAll().Value?.Where(p => p.FirstName == txtFirstName.Text && p.SurName == txtSurName.Text && p.Id != IdUser).FirstOrDefault() != null)
                {
                    errorProvider1.SetError(txtFirstName, "Użytkownik o tym imieniu i nazwisku już istnieje!");
                    errorProvider1.SetError(txtSurName, "Użytkownik o tym imieniu i nazwisku już istnieje!");
                    result = false;
                }
                if( _ctxUsr.GetAll().Value.Any(p=>p.Login == txtLogin.Text && p.Id != IdUser) == true)
                {
                    errorProvider1.SetError(txtLogin, "Ten login jest już w użyciu!");
                    result = false;
                }
            }

            return result;
        }
    }
}
