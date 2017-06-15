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
using SkyRegEnums;

namespace SkyReg
{
    public partial class PaymentsAddEditForm : KryptonForm
    {
        public FormState _formState { get; set; }
        public int _payId { get; set; }

        public PaymentsAddEditForm(FormState FormState, int PayId)
        {
            InitializeComponent();
            this._formState = FormState;
            this._payId = PayId;
        }

        private void PaymentsAddEditForm_Load(object sender, EventArgs e)
        {
            LoadPayTypes();
            LoadUsers();
            if (_formState == FormState.Edit)
                LoadPayData();
            else
                datData.Value = DateTime.Now.Date;
        }

        private void LoadPayData()
        {
            using (DLModelContainer model = new DLModelContainer())
            {
                var pay = model
                    .Payment
                    .Include("PaymentsSetting")
                    .Include("User")
                    .AsNoTracking()
                    .Where(p => p.Id == _payId)
                    .FirstOrDefault();

                //var pay = model
                //    .PaymentsSetting.OrderBy(p => p.Name).ToList();



                if (pay != null)
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
            using (DLModelContainer model = new DLModelContainer())
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
            using (DLModelContainer model = new DLModelContainer())
            {
                var allPayments = model.PaymentsSetting.AsNoTracking().OrderBy(p => p.Name).ToList();
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
            if (paySet.Type == (short)PaymentsTypes.Pakiet)
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
           
            if (PayValidate() == true)
            {
                SaveData();
            }
        }

        private void SaveData()
        {
            using (var _pay = new DLModelRepository<Payment>())
            using (var _ps = new DLModelRepository<PaymentsSetting>())
            using (var _usr = new DLModelRepository<User>())
            {
                Payment pay = new Payment();

                if (_formState != FormState.Add)
                    pay = _pay.Table.Where(p => p.Id == _payId).FirstOrDefault();

                int selectedUserId = (int)cmbUser.SelectedValue;
                int selectedPaySetId = (int)cmbPayType.SelectedValue;
                PaymentsSetting ps = _ps.Table.Where(p => p.Id == selectedPaySetId).FirstOrDefault();
                User usr = _usr.Table.Where(p => p.Id == selectedUserId).FirstOrDefault();

                pay.Date = datData.Value.Date;
                pay.Description = txtDescription.Text;
                pay.IsBooked = false;
                pay.PaymentsSetting = ps;
                pay.User = usr;
                pay.Value = numValue.Value;
                if (ps.Count == null)
                    pay.Count = 0;
                else
                    pay.Count = ps.Count;

                if (_formState == FormState.Add)
                {
                    _pay.InsertEntity(pay);
                }
                else
                {
                    _pay.Update(pay);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool PayValidate()
        {
            bool result = true;
            using (DLModelContainer model = new DLModelContainer())
            {

                errorProvider1.Clear();
                if (cmbUser.SelectedValue != null)
                {
                    if (numValue.Value == 0)
                    {
                        errorProvider1.SetError(numValue, "Wartość musi być większa od zera!");
                        result = false;
                    }

                    string surName = default(string);
                    string firstName = default(string);
                    string[] surAndFirstName = cmbUser.Text.Split(' ');
                    surName = surAndFirstName[0];
                    if (surAndFirstName.Count() >= 2)
                        firstName = surAndFirstName[1];
                    if (!model.User.Any(p => p.SurName == surName && p.FirstName == firstName))
                    {
                        errorProvider1.SetError(cmbUser, "Taka osoba nie widnieje w bazie danych!");
                    }
                }

            }
            return result;
        }
    }
}
