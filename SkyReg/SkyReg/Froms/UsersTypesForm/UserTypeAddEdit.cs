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

namespace SkyReg
{
    public partial class UserTypeAddEdit : KryptonForm
    {
        Enum_FormState _formState;
        int? _idUsrType;

        public EventHandler UserTypeAddEditEH;

        public UserTypeAddEdit()
        {
            InitializeComponent();
        }

        public UserTypeAddEdit(Enum_FormState formState, int? idUsrType)
        {
            _formState = formState;
            _idUsrType = idUsrType;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(ValidateUserType() == true)
            {
                SaveUserType();
            }
        }

        private void SaveUserType()
        {
            using (DLModelContainer model = new DLModelContainer())
            {
                if (_formState == Enum_FormState.Add)
                {
                    UsersType ut = new UsersType();
                    ut.Name = txtName.Text;
                    ut.Value = numValue.Value;
                    ut.IsCam = chkCam.Checked;
                    model.UsersType.Add(ut);
                    model.SaveChanges();
                }
                else
                {
                    UsersType ut = model.UsersType.Where(p => p.Id == _idUsrType).FirstOrDefault();
                    if (ut != null)
                    {
                        ut.Name = txtName.Text;
                        ut.Value = numValue.Value;
                        ut.IsCam = chkCam.Checked;
                        model.SaveChanges();
                    }
                }
            }
            this.Close();
            UserTypeAddEditEH.Invoke(null, null);
        }

        private bool ValidateUserType()
        {
            bool result = true;

            errorProvider1.SetError(txtName, string.Empty);
            errorProvider1.SetError(numValue, string.Empty);

            if(txtName.Text == string.Empty)
            {
                errorProvider1.SetError(txtName, "Pole nie może być puste!");
                result = false;
            }
            if(numValue.Value == 0)
            {
                errorProvider1.SetError(numValue, "Wartość nie może być równa 0!");
                result = false;
            }

            using(DLModelContainer model = new DLModelContainer())
            {
                if(_formState == Enum_FormState.Add)
                {
                    var isUserType = model.UsersType.Any(p => p.Name == txtName.Text);
                    if(isUserType == true)
                    {
                        errorProvider1.SetError(txtName, "Typ skoczka już istnieje!");
                        result = false;
                    }
                }
                else
                {
                    var isUserType = model.UsersType.Any(p => p.Name == txtName.Text && p.Id != _idUsrType);
                    if (isUserType == true)
                    {
                        errorProvider1.SetError(txtName, "Typ skoczka już istnieje!");
                        result = false;
                    }
                }
            }

            return result;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserTypeAddEdit_Load(object sender, EventArgs e)
        {
            if (_formState == Enum_FormState.Edit)
                LoadUserType();
        }

        private void LoadUserType()
        {
            using(DLModelContainer model = new DLModelContainer())
            {
                UsersType ut = model.UsersType.Where(p => p.Id == _idUsrType).FirstOrDefault();
                if(ut != null)
                {
                    txtName.Text = ut.Name;
                    numValue.Value = ut.Value;
                    chkCam.Checked = ut.IsCam;
                }
            }
        }
    }
}
