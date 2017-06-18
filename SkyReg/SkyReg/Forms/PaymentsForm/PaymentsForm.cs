using ComponentFactory.Krypton.Toolkit;
using SkyReg.Common.Extensions;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SkyRegEnums;
using DataLayer.Entities;
using DataLayer.Entities.DBContext;

namespace SkyReg
{
    public partial class PaymentsForm : KryptonForm
    {

        private PaymentsAddEditForm _paymentsAddEditForm = null;

        public PaymentsForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _paymentsAddEditForm = FormsOpened<PaymentsAddEditForm>.IsShowDialog(_paymentsAddEditForm);
            _paymentsAddEditForm._formState = FormState.Add;
            _paymentsAddEditForm.FormClosed += _paymentsAddEditForm_FormClosed;
            _paymentsAddEditForm._payId = 0;
            if ( _paymentsAddEditForm.ShowDialog() == DialogResult.OK)
            {
                RefreshPayList();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EditPayment();
        }

        private void EditPayment()
        {
            if (grdPayments.SelectedRows.Count > 0)
            {
                int selectedId = (int)grdPayments.SelectedRows[0].Cells["Id"].Value;

                _paymentsAddEditForm = FormsOpened<PaymentsAddEditForm>.IsShowDialog(_paymentsAddEditForm);
                _paymentsAddEditForm._formState = FormState.Edit;
                _paymentsAddEditForm._payId = selectedId;
                _paymentsAddEditForm.FormClosed += _paymentsAddEditForm_FormClosed;
                if (_paymentsAddEditForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshPayList();
                }
            }
        }

        private void _paymentsAddEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _paymentsAddEditForm = null;
        }

        private void PaymentsForm_Shown(object sender, EventArgs e) //TODO KOD Janusza!!!!!!! 
        {
            //RefreshPayList(); MASZ MI NIC NIE WSTAWIAC DO SHOWN!! TO OBCIĄZA UZYWAJ OnLOAD!!!
        }

        private void RefreshPayList()
        {
            using(SkyRegContext model = new SkyRegContext())
            {
                var payList = model.Payment
                    .Include("User")
                    .Include("PaymentsSetting")
                    .AsNoTracking()
                    .Where(p => p.IsBooked == false)
                    .Select(p => new
                    {
                        Id = p.Id,
                        Date = p.Date.Value,
                        Value = p.Value,
                        Count = p.Count.HasValue ? p.Count : default(decimal),
                        Description = p.Description,
                        PayType = p.PaymentsSetting.Name,
                        UserName = p.User.Name
                    })
                    .OrderBy(p => p.Date).ToList();
                if (payList != null)
                {
                    grdPayments.DataSource = payList;
                    PaymentsSetListView();
                }
            }
        }

        private void PaymentsSetListView()
        {
            grdPayments.Columns["Id"].Visible = false;

            grdPayments.Columns["Date"].DisplayIndex = 0;
            grdPayments.Columns["UserName"].DisplayIndex = 1;
            grdPayments.Columns["PayType"].DisplayIndex = 2;
            grdPayments.Columns["Description"].DisplayIndex = 3;
            grdPayments.Columns["Value"].DisplayIndex = 4;
            grdPayments.Columns["Count"].DisplayIndex = 5;

            grdPayments.Columns["Date"].HeaderText = "Data";
            grdPayments.Columns["UserName"].HeaderText = "Nazwisko i imię";
            grdPayments.Columns["PayType"].HeaderText = "Typ";
            grdPayments.Columns["Description"].HeaderText = "Opis";
            grdPayments.Columns["Value"].HeaderText = "Wartość";
            grdPayments.Columns["Count"].HeaderText = "Ilość skoków";

            grdPayments.Columns["Date"].Width = 100;
            grdPayments.Columns["UserName"].Width = 200;
            grdPayments.Columns["PayType"].Width = 200;
            grdPayments.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grdPayments.Columns["Value"].Width = 100;
            grdPayments.Columns["Count"].Width = 100;

            grdPayments.Columns["Value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdPayments.Columns["Count"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            grdPayments.ReadOnly = true;
            grdPayments.MultiSelect = true;
            grdPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdPayments.AllowUserToResizeRows = false;

        }

        private void PaymentsForm_Load(object sender, EventArgs e)
        {
            RefreshPayList();
        }

        private void grdPayments_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditPayment();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            using (SkyRegContext model = new SkyRegContext())
            {
                if (grdPayments.SelectedRows.Count > 0)
                {
                    int idPayForDelete = (int)grdPayments.SelectedRows[0].Cells["Id"].Value;
                    if(KryptonMessageBox.Show("Czy usunąć zaznaczoną pozycję?", "Usunąć", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var payToDel = model.Payment.Where(p => p.Id == idPayForDelete).FirstOrDefault();
                        model.Payment.Remove(payToDel);
                        model.SaveChanges();
                        RefreshPayList();
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
