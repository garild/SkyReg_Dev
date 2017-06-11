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
using SkyReg.BLL.Services;
using DataLayer.Result.Repository;
using DataLayer.Utils;

namespace SkyReg
{
    public partial class PaymentsAddEditForm : KryptonForm
    {
        public SkyRegEnums.FormState FormState { get; set; }
        public int PayId { get; set; }

        public PaymentsAddEditForm()
        {
            InitializeComponent();
        }

        private void PaymentsAddEditForm_Load(object sender, EventArgs e)
        {
            LoadPayTypes();
            LoadUsers();
            if (FormState == SkyRegEnums.FormState.Edit)
                LoadPayData();
            else
                datData.Value = DateTime.Now.Date;
        }

        private void LoadPayData()
        {
            using(DLModelContainer model = new DLModelContainer())
            {
                var pay = model
                    .Payment
                    .Include("PaymentsSetting")
                    .Include("User")
                    .AsNoTracking()
                    .Where(p => p.Id == PayId)
                    .FirstOrDefault();
                if(pay != null)
                {
                    cmbPayType.SelectedValue = pay.PaymentsSetting.Id;
                    cmbUser.SelectedValue = pay.User.Id;
                    txtDescription.Text = pay.Description;
                    datData.Value = pay.Date.Value;
                    numValue.Value = pay.Value;
                }

            }
        }

        private void LoadUsers()
        {
            using(DLModelContainer model = new DLModelContainer())
            {
                var allUsers = model
                    .User.OrderBy(p => p.SurName)
                    .ThenBy(p => p.FirstName)
                    .Select(p => new
                    {
                        Id = p.Id,
                        Name = p.SurName + " " + p.FirstName
                    }).ToList();
                if (allUsers != null)
                {
                    cmbUser.DataSource = allUsers;
                    cmbUser.DisplayMember = "Name";
                    cmbUser.ValueMember = "Id";
                    cmbUser.SelectedIndex = 0;
                }
            }
        }

        private void LoadPayTypes()
        {
            using(DLModelContainer model = new DLModelContainer())
            {
                var allPayments = model.PaymentsSetting.OrderBy(p => p.Name).ToList();
                if (allPayments != null)
                {
                    cmbPayType.DataSource = allPayments;
                    cmbPayType.DisplayMember = "Name";
                    cmbPayType.ValueMember = "Id";
                    cmbPayType.SelectedIndex = 0;
                }
            }
        }

        private void cmbPayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PaymentsSetting paySet = (PaymentsSetting)cmbPayType.SelectedItem;
            if(paySet.Type == (short)PaymentsTypes.Pakiet)
            {
                numValue.Value = paySet.Value.Value;
                numValue.Enabled = false;
            }
            else
            {
                numValue.Value = 0;
                numValue.Enabled = true;
            }
            
        }

        private void btnSaveCfg_Click(object sender, EventArgs e)
        {
            if(PayValidate() == true)
            {
                SaveData();
            }
        }

        private void SaveData()
        {
            using (DLModelContainer model = new DLModelContainer())
            {
                Payment pay = null;
                if (FormState == SkyRegEnums.FormState.Add)
                {
                    pay = new Payment();
                }
                else
                {
                    pay = model
                        .Payment
                        .Include("User")
                        .Include("PaymentsSetting")
                        .AsNoTracking()
                        .Where(p => p.Id == PayId)
                        .FirstOrDefault();
                }
                int selectedUserId = (int)cmbUser.SelectedValue;
                int selectedPaySetId = (int)cmbPayType.SelectedValue;
                PaymentsSetting ps = model.PaymentsSetting.Where(p => p.Id == selectedPaySetId).FirstOrDefault();
                User usr = model.User.Where(p => p.Id == selectedUserId).FirstOrDefault();

                pay.Date = datData.Value.Date;
                pay.Description = txtDescription.Text;
                pay.IsBooked = false;
                pay.PaymentsSetting = ps;
                pay.User = usr;
                pay.Value = numValue.Value;
                if (FormState == SkyRegEnums.FormState.Add)
                {
                    model.Payment.Add(pay);
                    model.Entry(pay).State = System.Data.Entity.EntityState.Added;
                }
                else
                {
                    model.Entry(pay).State = System.Data.Entity.EntityState.Modified;
                }
                model.SaveChanges();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool PayValidate()
        {
            bool result = true;
            errorProvider1.Clear();
            if(numValue.Value == 0 )
            {
                errorProvider1.SetError(numValue, "Wartość musi być większa od zera!");
                result = false;
            }
            return result;
        }
    }
}
