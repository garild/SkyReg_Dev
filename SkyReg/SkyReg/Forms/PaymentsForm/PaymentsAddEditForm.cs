using ComponentFactory.Krypton.Toolkit;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DataLayer;
using DataLayer.Result.Repository;
using SkyRegEnums;
using DataLayer.Entities.DBContext;

namespace SkyReg
{
    public partial class PaymentsAddEditForm : KryptonForm
    {
        public FormState _formState { get; set; }
        public int _payId { get; set; }

        public PaymentsAddEditForm()
        {
            InitializeComponent();
        }

        private void PaymentsAddEditForm_Load(object sender, EventArgs e)
        {
            LoadPayTypes();
            LoadUsers();
            if (_formState == FormState.Edit)
            {
                btnSave.Text = "Zapisz";
                LoadPayData();
            }
            else
            {
                btnSave.Text = "Dodaj";
                datData.Value = DateTime.Now.Date;
            }
               
        }

        private void LoadPayData()
        {
            using (var _ctx = new SkyRegContextRepository<Payment>())
            {
                var pay = _ctx.GetAll(Tuple.Create(nameof(User),nameof(PaymentsSetting),"")).Value?
                    .Where(p => p.Id == _payId)
                    .FirstOrDefault();

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
            using (SkyRegContext model = new SkyRegContext())
            {
                var allUsers = model
                    .User.OrderBy(p => p.Name)
                    .Select(p => new
                    {
                        Id = p.Id,
                        Name = p.Name

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
            using (SkyRegContext model = new SkyRegContext())
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

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (PayValidate() == true)
            {
                SaveData();
            }
        }

        private void SaveData()
        {
            int selectedUserId = (int)cmbUser.SelectedValue;
            int selectedPaySetId = (int)cmbPayType.SelectedValue;

            using (var _pay = new SkyRegContextRepository<Payment>())
            {
                Payment pay = _formState == FormState.Add ? new Payment() : _pay.GetById(_payId);

                PaymentsSetting ps = _pay.Model.PaymentsSetting.Where(p => p.Id == selectedPaySetId).FirstOrDefault();

                User usr = _pay.Model.User.Where(p => p.Id == selectedUserId).FirstOrDefault();

                pay.IsBooked = false;
                pay.Date = datData.Value.Date;
                pay.Description = txtDescription.Text;
                pay.Value = numValue.Value;
                pay.Count = ps.Count ?? 0;
                pay.User_Id = usr.Id;
                pay.PaymentsSetting_Id = ps.Id;

                if (_formState != FormState.Add)
                    _pay.Update(pay);
                else
                    _pay.InsertEntity(pay);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool PayValidate()
        {
            bool result = true;
            using (SkyRegContext model = new SkyRegContext())
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
                    if (!model.User.Any(p => p.Name.ToLower() == "")) // TODO Dodać 1 pole imie i nazwisko
                    {
                        errorProvider1.SetError(cmbUser, "Taka osoba nie widnieje w bazie danych!");
                    }
                }

            }
            return result;
        }

        private void PaymentsAddEditForm_Shown(object sender, EventArgs e)
        {
            datData.Focus();
        }
    }
}
