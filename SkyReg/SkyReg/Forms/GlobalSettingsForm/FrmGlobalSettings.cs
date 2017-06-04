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

namespace SkyReg
{
    public partial class FrmGlobalSettings : KryptonForm
    {
        #region Konstruktor

        public FrmGlobalSettings()
        {
            InitializeComponent();
            PaymentsTypesLoad();
            grdPaymentViewSettings();
            OperatorsLoad();
            loadGlobalSettingsFields();
            grdOperatorsViewSettings();
        }

        #endregion

        #region Metody prywatne

        private void loadGlobalSettingsFields()
        {
            using (DLModelContainer model = new DLModelContainer())
            {
                GlobalSetting gs = model.GlobalSetting.Select(p => p).FirstOrDefault();
                if (gs != null)
                {
                    numCamPrice.Value = gs.CamPrice.Value;
                    numDaysExpiredCert.Value = gs.CertExpired.Value;
                    txtAirportId.Text = gs.AirportsName;
                }
            }
        }

        private void OperatorsLoad()
        {
            using (DLModelContainer model = new DLModelContainer())
            {
                var operators = model
                    .Operator
                    .Include("User")
                    .AsNoTracking()
                    .Select(p => new
                    {
                        Id = p.Id,
                        Name = p.User.SurName + " " + p.User.FirstName,
                        Type = p.Type == (int)Enum_OperatorTypes.Operator ? "Operator" : "Rejestrujący",
                    })
                    .OrderBy(p => Name)
                    .ToList();

                grdOperators.DataSource = operators;
                grdOperators.Refresh();
            }
        }

        private void grdOperatorsViewSettings()
        {
            grdOperators.RowHeadersVisible = false;
            grdOperators.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdOperators.ReadOnly = true;

            grdOperators.Columns["Id"].Visible = false;
            grdOperators.Columns["Name"].Visible = true;
            grdOperators.Columns["Type"].Visible = true;

            grdOperators.Columns["Name"].HeaderText = "Nazwisko imię";
            grdOperators.Columns["Type"].HeaderText = "Typ";

            grdOperators.Columns["Type"].Width = 100;
            grdOperators.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            foreach (DataGridViewRow item in grdOperators.Rows)
            {
                if (item.Cells["Type"].Value.ToString() == "Operator")
                {
                    item.DefaultCellStyle.BackColor = Color.Gold;
                }
            }

        }

        private void grdPaymentViewSettings()
        {
            grdPayment.RowHeadersVisible = false;
            grdPayment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdPayment.ReadOnly = true;

            grdPayment.Columns["Id"].Visible = false;
            grdPayment.Columns["Name"].Visible = true;
            grdPayment.Columns["Value"].Visible = true;
            grdPayment.Columns["Count"].Visible = true;
            grdPayment.Columns["Type"].Visible = true;

            grdPayment.Columns["Name"].HeaderText = "Nazwa";
            grdPayment.Columns["Type"].HeaderText = "Typ";
            grdPayment.Columns["Value"].HeaderText = "Kwota";
            grdPayment.Columns["Count"].HeaderText = "Skoki";

            grdPayment.Columns["Type"].Width = 80;
            grdPayment.Columns["Value"].Width = 80;
            grdPayment.Columns["Count"].Width = 80;
            grdPayment.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            grdPayment.Columns["Value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdPayment.Columns["Count"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewRow item in grdPayment.Rows)
            {
                if (item.Cells["Type"].Value.ToString() == "Płatność")
                {
                    item.DefaultCellStyle.BackColor = Color.Gold;
                }
            }
        }

        private void PaymentsTypesLoad()
        {
            using (DLModelContainer model = new DLModelContainer())
            {
                var paymSetList = model.PaymentsSetting.Select(p => new
                {
                    Id = p.Id,
                    Name = p.Name,
                    Type = p.Type == 2 ? "Pakiet" : "Płatność",
                    Value = p.Value,
                    Count = p.Count
                })
                .OrderBy(p => p.Name)
                .ToList();

                grdPayment.DataSource = null;
                grdPayment.DataSource = paymSetList;
                grdPayment.Refresh();
            }
        }

        private void OperatorDelete()
        {
            if (grdOperators.SelectedRows.Count > 0)
            {
                if (KryptonMessageBox.Show("Usunąć zaznaczoną pozycję?", "Usunąć?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in grdOperators.SelectedRows)
                    {
                        using (DLModelContainer model = new DLModelContainer())
                        {
                            int opeID = (int)item.Cells["Id"].Value;
                            var opeToDelete = model.Operator.Where(p => p.Id == opeID).FirstOrDefault();
                            if (opeToDelete != null)
                            {
                                model.Operator.Remove(opeToDelete);
                                model.SaveChanges();
                                OperatorsLoad();
                                grdOperatorsViewSettings();
                            }
                        }
                    }
                }
            }
        }

        private void PaymentsSetDelete()
        {
            if (grdPayment.SelectedRows.Count > 0)
            {
                if (KryptonMessageBox.Show("Usunąć zaznaczoną pozycję?", "Usunąć?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in grdPayment.SelectedRows)
                    {
                        using (DLModelContainer model = new DLModelContainer())
                        {
                            int IDps = (int)item.Cells["Id"].Value;
                            var paySetToDelete = model.PaymentsSetting.Where(p => p.Id == IDps).FirstOrDefault();
                            if (paySetToDelete != null)
                            {
                                model.PaymentsSetting.Remove(paySetToDelete);
                                model.SaveChanges();
                                PaymentsTypesLoad();
                                grdPaymentViewSettings();
                            }
                        }
                    }
                }
            }
        }

        private void PaymentsSetAdd()
        {
            FrmPaymentAdd = FormsOpened<FrmPaymentAdd>.IsOpened(FrmPaymentAdd);
            FrmPaymentAdd.FormaAccept += RefreshPaymentSetGrid;
            FrmPaymentAdd.TopMost = true;
            FrmPaymentAdd.ShowDialog();
        }

        private void RefreshPaymentSetGrid(object sender, EventArgs e)
        {
            PaymentsTypesLoad();
            grdPaymentViewSettings();
        }

        private void RefreshOperatorGrid(object sender, EventArgs e)
        {
            OperatorsLoad();
            grdOperatorsViewSettings();
        }

        private void saveGlobalSettings()
        {
            using (DLModelContainer model = new DLModelContainer())
            {
                GlobalSetting gs = model.GlobalSetting.Select(p => p).FirstOrDefault();
                if (gs == null)
                {
                    gs = new GlobalSetting();
                    gs.CamPrice = numCamPrice.Value;
                    gs.AirportsName = txtAirportId.Text;
                    gs.CertExpired = (short)numDaysExpiredCert.Value;
                    model.GlobalSetting.Add(gs);
                }
                else
                {
                    gs.CamPrice = numCamPrice.Value;
                    gs.AirportsName = txtAirportId.Text;
                    gs.CertExpired = (short)numDaysExpiredCert.Value;
                }
                model.SaveChanges();
            }
        }

        #endregion

        #region Zdarzenia

        private void btnOperatorDelete_Click(object sender, EventArgs e)
        {
            OperatorDelete();
        }

        private void btnPaymentsDelete_Click(object sender, EventArgs e)
        {
            PaymentsSetDelete();
        }

        private void btnPaymentAdd_Click(object sender, EventArgs e)
        {
            PaymentsSetAdd();
        }

        private void btnCloseSettings_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            saveGlobalSettings();
        }

        private void btnOperatorAdd_Click(object sender, EventArgs e)
        {
            FrmOperatorAdd foa = new FrmOperatorAdd();
            foa.MdiParent = this.ParentForm;
            //TODO sprawdzić czy nie ma wywołanego tego okna
            foa.AddedUser += RefreshOperatorGrid;
            foa.Show();
        }


        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHeader_Add_Click(object sender, EventArgs e)
        {
            PaymentsSetAdd();
        }

        #region Form

        private FrmPaymentAdd FrmPaymentAdd = null;

        #endregion

    }
}
