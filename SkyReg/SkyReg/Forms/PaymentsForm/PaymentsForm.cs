using ComponentFactory.Krypton.Toolkit;
using SkyReg.Common.Extensions;
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
    public partial class PaymentsForm : KryptonForm
    {

        private PaymentsAddEditForm PaymentsAddEditForm = null;

        public PaymentsForm()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            PaymentsAddEditForm = FormsOpened<PaymentsAddEditForm>.IsOpened(PaymentsAddEditForm);
            PaymentsAddEditForm.FormState = SkyRegEnums.FormState.Add;
            PaymentsAddEditForm.PayId = default(int);
            if( PaymentsAddEditForm.ShowDialog() == DialogResult.OK)
            {
                RefreshPayList();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (grdPayments.SelectedRows.Count > 0)
            {
                int selectedId = (int)grdPayments.SelectedRows[0].Cells["Id"].Value;

                PaymentsAddEditForm = FormsOpened<PaymentsAddEditForm>.IsOpened(PaymentsAddEditForm);
                PaymentsAddEditForm.FormState = SkyRegEnums.FormState.Edit;
                PaymentsAddEditForm.PayId = selectedId;
                if (PaymentsAddEditForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshPayList();
                }
            }
        }

        

        private void PaymentsForm_Shown(object sender, EventArgs e)
        {
            RefreshPayList();
        }

        private void RefreshPayList()
        {
            using(DLModelContainer model = new DLModelContainer())
            {
                var payList = model.Payment
                    .Include("User")
                    .Include("PaymentsSetting")
                    .AsNoTracking()
                    .Where(p=>p.IsBooked == false)
                    .Select(p=> new PayOnGrid
                    {
                        Id = p.Id,
                        Date = p.Date.Value,
                        Value = p.Value,
                        Count = p.Count.Value,
                        Description = p.Description,
                        PayType = p.PaymentsSetting.Name,
                        UserName = p.User.SurName + " " + p.User.FirstName
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
    }
}
