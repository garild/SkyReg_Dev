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
using SkyRegEnums;
using DataLayer.Entities.DBContext;

namespace SkyReg
{
    public partial class UserTypeAddEdit : KryptonForm
    {
        public FormState? _formState = null;
        public int? _idUserType = 0;

        public UserTypeAddEdit()
        {
            InitializeComponent();
            txtName.Clear();
            numValue.Value = 0;
            this.DialogResult = DialogResult.None;
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
            using (var _ctx = new SkyRegContextRepository<DefinedUserType>())
            {
                DefinedUserType ut = _formState == FormState.Add ? new DefinedUserType() : _ctx.GetById(_idUserType);

                ut.Name = txtName.Text;
                ut.Value = numValue.Value;
                ut.IsCam = chkCam.Checked;
                ut.RequiredSupervisor = chkNeedSupervisor.Checked;
                if (_formState == FormState.Add)
                    _ctx.InsertEntity(ut);
                else
                    _ctx.Update(ut);

            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidateUserType()
        {
            bool result = true;
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

            using(SkyRegContext model = new SkyRegContext())
            {
                if(_formState == FormState.Add)
                {
                    var isUserType = model.DefinedUserType.Any(p => p.Name == txtName.Text);
                    if(isUserType == true)
                    {
                        errorProvider1.SetError(txtName, "Typ skoczka już istnieje!");
                        result = false;
                    }
                }
                else
                {
                    if (model.DefinedUserType.Any(p => p.Name == txtName.Text && p.Id != _idUserType))
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
            using(SkyRegContext model = new SkyRegContext())
            {
                DefinedUserType ut = model.DefinedUserType.Where(p => p.Id == _idUserType).FirstOrDefault();
                if(ut != null)
                {
                    txtName.Text = ut.Name;
                    numValue.Value = ut.Value;
                    chkCam.Checked = ut.IsCam;
                    chkNeedSupervisor.Checked = ut.RequiredSupervisor;
                }
            }
        }

        private void UserTypeAddEdit_Shown(object sender, EventArgs e)
        {
            txtName.Focus();
        }
    }
}
