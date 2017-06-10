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
using SkyReg.Common.Extensions;
using DataLayer.Result.Repository;

namespace SkyReg
{
    public partial class UserTypeAddEdit : KryptonForm
    {
        FormState? _formState;
        int? _idUserType;

        public UserTypeAddEdit(FormState? formState = null, int? idUserType = null)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.None;
            _formState = formState;
            _idUserType = idUserType;
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
            using (var model = new DLModelRepository<UsersType>())
            {
                if (_formState == FormState.Add)
                {
                    UsersType ut = new UsersType();
                    ut.Name = txtName.Text;
                    ut.Value = numValue.Value;
                    ut.IsCam = chkCam.Checked;
                    model.Insert(ut);
                  
                }
                else
                {
                    var ut = model.GetAll().Value?.Where(p => p.Id == _idUserType).FirstOrDefault();
                    if (ut != null)
                    {
                        ut.Name = txtName.Text;
                        ut.Value = numValue.Value;
                        ut.IsCam = chkCam.Checked;
                        model.Update(ut);
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidateUserType()
        {
            bool result = true;
            errorProvider1.Clear();
            errorProvider1.Clear();

            if (!txtName.Text.HasValue())
            {
                errorProvider1.SetError(txtName, "Pole nie może być puste!");
                result = false; 
            }
            if(numValue.Value == default(decimal))
            {
                errorProvider1.SetError(numValue, "Wartość nie może być równa 0!");
                result = false;
            }

            using(DLModelContainer model = new DLModelContainer())
            {
                if(_formState == FormState.Add)
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
                    if (model.UsersType.Any(p => p.Name == txtName.Text && p.Id != _idUserType))
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
            if (_formState == FormState.Edit)
                LoadUserType();
        }

        private void LoadUserType()
        {
            using(DLModelContainer model = new DLModelContainer())
            {
                UsersType ut = model.UsersType.Where(p => p.Id == _idUserType).FirstOrDefault();
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
