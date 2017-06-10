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
using SkyReg.Common.Extensions;

namespace SkyReg
{
    public partial class UsersAddEditForm : KryptonForm
    {
        public FormState FormState { get; set; }
        public int? IdUser { get; set; }
        public int UserGroup { get; set; }

        public EventHandler EventHandlerAddEditUser;

        public UsersAddEditForm()
        {
            InitializeComponent();
            dateCertDate.MaxDate = DateTime.Now.AddYears(2);
        }

        private void UsersAddEditForm_Load(object sender, EventArgs e)
        {
            LoadAllUsersTypes();
            if (FormState == FormState.Edit)
                LoadEditedUserData();
        }

        private void LoadEditedUserData()
        {
            using(var model =  new DLModelRepository<User>())
            {
                var usr = model.GetAll().Value?.Where(p => p.Id == IdUser).FirstOrDefault();
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
                    dateCertDate.Value = usr.CertDate.HasValue ? usr.CertDate.Value : dateCertDate.MaxDate;
                }
            }
        }

        private void LoadAllUsersTypes()
        {
            chkListUserTypes.Items.Clear();
            using(var model = new DLModelContainer())
            {
                var allUserTypes = model.UsersType.ToList();
                if (FormState == FormState.Edit)
                {
                    var currentUserTypes = model.User.Where(p => p.Id == IdUser).SelectMany(p => p.UsersType).ToList();
                    allUserTypes?.ForEach(item =>
                    {
                        if (currentUserTypes.Any(p => p.Id == item.Id))
                            chkListUserTypes.Items.Add(item.Name, true);
                        else
                            chkListUserTypes.Items.Add(item.Name, false);
                    });
                    
                }
                else
                {
                    allUserTypes?.ForEach(p=>
                    {
                        chkListUserTypes.Items.Add(p.Name, false);
                    });
                   
                }
            }
        }

        private void btnCheckLogin_Click(object sender, EventArgs e)
        {
            using(var model = new DLModelRepository<User>())
            {
                var isUser = model.GetAll().Value?.Any(p => p.Login == txtLogin.Text);
                if (!isUser.HasValue)
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
                User usr = new User();

                if (FormState != FormState.Add)
                {
                    usr = model.User.Include("UsersType").AsNoTracking().Where(p => p.Id == IdUser).FirstOrDefault();
                }

                var listUsersTypes = new List<UsersType>();
              
                foreach (var item in chkListUserTypes.CheckedItems)
                {
                    listUsersTypes.Add(model.UsersType.Where(p => p.Name == item.ToString()).FirstOrDefault());
                }

                if (txtCertyfikate.Text.HasValue())
                    usr.CertDate = dateCertDate.Value.Date;
                else
                    usr.CertDate = dateCertDate.MaxDate;

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

                if (FormState == FormState.Add)
                {
                    model.User.Add(usr);
                }

                model.SaveChanges();
                EventHandlerAddEditUser.Invoke(null, null);
             
                this.Close();
            }
        }

        private bool ValidateAddEditUser()
        {
            errorProvider1.Clear();

            using(DLModelRepository<User> _ctxUsr = new DLModelRepository<User>())
            {
                var userList = _ctxUsr.GetAll();
                if (userList.IsSuccess)
                {
                    if (!txtFirstName.Text.HasValue())
                    {
                        errorProvider1.SetError(txtFirstName, "Pole nie może być puste!");
                        return false;
                    }
                    if (!txtSurName.Text.HasValue())
                    {
                        errorProvider1.SetError(txtSurName, "Pole nie może być puste!");
                        return false;
                    }
                
                    if (userList.Value.Where(p => p.FirstName == txtFirstName.Text && p.SurName == txtSurName.Text && p.Id != IdUser).FirstOrDefault() != null)
                    {
                        errorProvider1.SetError(txtFirstName, "Użytkownik o tym imieniu i nazwisku już istnieje!");
                        errorProvider1.SetError(txtSurName, "Użytkownik o tym imieniu i nazwisku już istnieje!");
                        return false;
                    }
                    if (userList.Value.Any(p => p.Login == txtLogin.Text && p.Id != IdUser))
                    {
                        errorProvider1.SetError(txtLogin, "Ten login jest już w użyciu!");
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
