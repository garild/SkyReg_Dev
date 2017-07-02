using ComponentFactory.Krypton.Toolkit;
using DataLayer;
using DataLayer.Result.Repository;
using SkyReg.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyReg.Forms.SupervisorsForm
{
    public partial class SupervisorAddEdit : KryptonForm
    {
        public int Supervisor_Id;

        public SupervisorAddEdit()
        {
            InitializeComponent();
          
        }

        private void LoadData()
        {
            txtCertificateNR.Clear();
            txtSurveyNr.Clear();
            txtUserName.Clear();
            dtCertificateDate.Value = DateTime.Now;
            dtSurveyDate.Value = DateTime.Now;

            if (Supervisor_Id > 0)
            {
                using (var _ctx = new SkyRegContextRepository<Supervisors>())
                {
                    var data = _ctx.GetById(Supervisor_Id);
                    if (data != null)
                    {
                        txtCertificateNR.Text = data.CertificateNr;
                        txtSurveyNr.Text = data.SurveyNr;
                        txtUserName.Text = data.UserName;
                        dtCertificateDate.Value = data.CertificateExpirateDate;
                        dtSurveyDate.Value = data.SurveyExpirateDate;
                    }
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool ValidateControls()
        {
            errorProvider1.Clear();
        
            if (!txtUserName.Text.HasValue())
            {
                errorProvider1.SetError(txtUserName, "Pole wymagane!");
                return false;
            }
            if (!txtCertificateNR.Text.HasValue())
            {
                errorProvider1.SetError(txtCertificateNR, "Pole wymagane!");
                return false;
            }

            if (dtCertificateDate.Value.Date == DateTime.Now.Date)
            {
                errorProvider1.SetError(dtCertificateDate, "Data pokrywa się z dzisiejszą datą!");
                return false;
            }

            if (!txtSurveyNr.Text.HasValue())
            {
                errorProvider1.SetError(txtSurveyNr, "Pole wymagane!");
                return false;
            }

            if (dtSurveyDate.Value.Date == DateTime.Now.Date)
            {
                errorProvider1.SetError(dtSurveyDate, "Data pokrywa się z dzisiejszą datą!");
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AddEditSupervisor();
        }

        private void AddEditSupervisor()
        {
            bool result = false;
            using (var _ctx = new SkyRegContextRepository<Supervisors>())
            {
                var data = new Supervisors();

                if (Supervisor_Id > 0)
                    data = _ctx.GetById(Supervisor_Id);

                data.UserName = txtUserName.Text.Trim();
                data.CertificateNr = txtCertificateNR.Text.Trim();
                data.SurveyNr = txtSurveyNr.Text.Trim();
                data.SurveyExpirateDate = dtSurveyDate.Value;
                data.CertificateExpirateDate = dtCertificateDate.Value;

                if (data.Id > 0)
                {
                    if (ValidateControls())
                        result = _ctx.Update(data).IsSuccess;
                }
                else
                {
                    if (ValidateControls())
                        result = _ctx.InsertEntity(data).IsSuccess;

                }
            }

            if(result)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void SupervisorAddEdit_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
