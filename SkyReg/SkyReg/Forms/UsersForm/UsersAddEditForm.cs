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


        public UsersAddEditForm()
        {
            InitializeComponent();
        }

        private void UsersAddEditForm_Load(object sender, EventArgs e)
        {
            LoadAllUsersTypes();
        }


        private void LoadAllUsersTypes()
        {
            using(DLModelContainer model = new DLModelContainer())
            {
                List<UsersType> allUsrTypes = model.UsersType.ToList();
                if (FormState == Enum_FormState.Edit)
                {
                    List<UsersType> currentUsrTypes = model.User.Where(p => p.Id == IdUser).SelectMany(p => p.UsersType).ToList();
                    foreach (UsersType item in allUsrTypes)
                    {
                        chkListUserTypes.Items.Add(item.Name, currentUsrTypes.Any(p => p.Id == item.Id));
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

            }
        }

        private bool ValidateAddEditUser()
        {
            bool result = true;
            errorProvider1.Clear();


            using(DLModelRepository<User> _ctxUsr = new DLModelRepository<User>())
            {
                var users = _ctxUsr.GetAll().Value?.Where(p => p.FirstName == txtFirstName.Text).FirstOrDefault();
                if(txtFirstName.Text == default(string))
                {
                    errorProvider1.SetError(txtFirstName, "Pole nie może być puste!");
                    result = false;
                }
                if(txtSurName.Text == default(string))
                {
                    errorProvider1.SetError(txtSurName, "Pole nie może być puste!");
                    result = false;
                }



            }

            return result;
        }
    }
}
