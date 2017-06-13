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
using System.Globalization;
using SkyRegEnums;
using DataLayer.Result.Repository;

namespace SkyReg
{
    public partial class FrmGlobalSettings : KryptonForm
    {

        private readonly CultureInfo culture = new CultureInfo("pl-PL");
        private List<DayOfWeek> dayOfWeeks = new List<DayOfWeek>();

        #region Konstruktor

        public FrmGlobalSettings()
        {
            InitializeComponent();
            PaymentsTypesLoad();
            PaymentViewSettings();
            OperatorsLoad();
            LoadGlobalSettingsFields();
            OperatorsViewSettings();
            LoadAirplanes();
        }

        #endregion

        #region Metody prywatne

        private void LoadAirplanes()
        {
            using (DLModelRepository<Airplane> _ctxAirplane = new DLModelRepository<Airplane>())
            {
                var airplanes = _ctxAirplane.GetAll();
                if (airplanes.IsSuccess)
                {
                    cmbAirplane.ValueMember = "Id";
                    cmbAirplane.DisplayMember = "RegNr";
                    cmbAirplane.DataSource = airplanes.Value;
                }

            }
        }

        private void LoadGlobalSettingsFields()
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

        private void OperatorsLoad() //TODO Kod Janusza
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
                        Type = p.Type == (int)OperatorTypes.Operator ? "Operator" : "Rejestrujący",
                    })
                    .OrderBy(p => Name)
                    .ToList();

                grdOperators.DataSource = operators;
                grdOperators.Refresh();
            }
        }

        private void OperatorsViewSettings()
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



        }

        private void FrmGlobalSettings_Shown(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in grdOperators.Rows)
            {
                if (item.Cells["Type"].Value.ToString() == "Operator")
                {
                    item.DefaultCellStyle.BackColor = Color.Gold;
                }
            }

            foreach (DataGridViewRow item in grdPayment.Rows)
            {
                if (item.Cells["Type"].Value.ToString() == "Płatność")
                {
                    item.DefaultCellStyle.BackColor = Color.Gold;
                }
            }
        }

        private void PaymentViewSettings()
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

        private void OperatorDelete()//TODO KOD Janusza
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
                                OperatorsViewSettings();
                            }
                        }
                    }
                }
            }
        }

        private void PaymentsSetDelete() //TODO KOD Janusza
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
                                PaymentViewSettings();
                            }
                        }
                    }
                }
            }
        }

        private void PaymentsSetAdd()
        {
            FrmPaymentAdd = FormsOpened<FrmPaymentAdd>.IsShowDialog(FrmPaymentAdd);
            FrmPaymentAdd.FormClosed += FrmPaymentAdd_FormClosed;
            FrmPaymentAdd.ShowDialog();
        }

        private void FrmPaymentAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (FrmPaymentAdd.DialogResult == DialogResult.OK)
            {
                PaymentsTypesLoad();
                PaymentViewSettings();
            }
        }

        private void saveGlobalSettings()//TODO KOD Janusza
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
            FrmOperatorAdd = FormsOpened<FrmOperatorAdd>.IsShowDialog(FrmOperatorAdd);
            FrmOperatorAdd.FormClosed += FrmOperatorAdd_FormClosed;
            FrmOperatorAdd.ShowDialog();
        }

        private void FrmOperatorAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (FrmOperatorAdd.DialogResult == DialogResult.OK)
            {
                OperatorsLoad();
                OperatorsViewSettings();
            }
        }


        #endregion

        #region Form

        private FrmPaymentAdd FrmPaymentAdd = null;
        private FrmOperatorAdd FrmOperatorAdd = null;

        #endregion


        private void GeneradeFlights()
        {
            // LOT 17/06/13
            DateTime dateCount = dateFrom.Value.AddDays(-1);
            var dateEnd = dateTo.Value;
            var listFlights = new List<Flight>();
            var flight = new Flight();
            var days = (int)Math.Ceiling((dateTo.Value.AddDays(1) - dateFrom.Value).TotalDays);
            int getYear = DateTime.Now.Year;

            using (DLModelRepository<Airplane> _ctxAirplane = new DLModelRepository<Airplane>())
            using (DLModelRepository<Flight> _ctxFlight = new DLModelRepository<Flight>())
            {
                var airplane = _ctxAirplane.GetById((int)cmbAirplane.SelectedValue);


                if (dayOfWeeks.Count > 0)
                {
                    for (int i = 1; i < days + 1; i++)
                    {
                        dateCount = dateCount.AddDays(1);

                        if (dayOfWeeks.Contains(dateCount.DayOfWeek))
                        {
                            for (int a = 1; a < flightsPerDay.Value + 1; a++)
                            {
                                flight = new Flight();
                                flight.Airplane = airplane;
                                flight.FlyDateTime = dateCount;
                                flight.FlyStatus = (int)FlightsStatus.Opened;
                                flight.FlyNr = $"LOT /{dateCount.ToString(@"yy\/MM\/dd")}/{a.ToString("00")}";

                                listFlights.Add(flight);
                            }
                        }

                        if (dateCount >= dateEnd)
                            break;

                    }
                }

                if (listFlights.Count > 0)
                    _ctxFlight.InsertMany(listFlights);
            }
        }

        public void AddOrDeleteDayOfWeek(DayOfWeek day, Actions action)
        {

            if (action == Actions.Add)
            {
                if (!dayOfWeeks.Contains(day))
                    dayOfWeeks.Add(day);
            }
            else
            {
                if (dayOfWeeks.Contains(day))
                    dayOfWeeks.Remove(day);
            }


        }

        #region Zdarzenia - Dni Tygodnia


        private void chkMonday_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMonday.CheckState == CheckState.Checked)
                AddOrDeleteDayOfWeek(DayOfWeek.Monday, Actions.Add);
            else
                AddOrDeleteDayOfWeek(DayOfWeek.Monday, Actions.Delete);

        }

        private void chkTuesday_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTuesday.CheckState == CheckState.Checked)
                AddOrDeleteDayOfWeek(DayOfWeek.Tuesday, Actions.Add);
            else
                AddOrDeleteDayOfWeek(DayOfWeek.Tuesday, Actions.Delete);
        }

        private void chkWednesday_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWednesday.CheckState == CheckState.Checked)
                AddOrDeleteDayOfWeek(DayOfWeek.Wednesday, Actions.Add);
            else
                AddOrDeleteDayOfWeek(DayOfWeek.Wednesday, Actions.Delete);
        }

        private void chkThursday_CheckedChanged(object sender, EventArgs e)
        {
            if (chkThursday.CheckState == CheckState.Checked)
                AddOrDeleteDayOfWeek(DayOfWeek.Thursday, Actions.Add);
            else
                AddOrDeleteDayOfWeek(DayOfWeek.Thursday, Actions.Delete);
        }

        private void chkFriday_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFriday.CheckState == CheckState.Checked)
                AddOrDeleteDayOfWeek(DayOfWeek.Friday, Actions.Add);
            else
                AddOrDeleteDayOfWeek(DayOfWeek.Friday, Actions.Delete);
        }

        private void chkSaturday_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSaturday.CheckState == CheckState.Checked)
                AddOrDeleteDayOfWeek(DayOfWeek.Saturday, Actions.Add);
            else
                AddOrDeleteDayOfWeek(DayOfWeek.Saturday, Actions.Delete);
        }

        private void chkSunday_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSunday.CheckState == CheckState.Checked)
                AddOrDeleteDayOfWeek(DayOfWeek.Sunday, Actions.Add);
            else
                AddOrDeleteDayOfWeek(DayOfWeek.Sunday, Actions.Delete);
        }
        #endregion

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            GeneradeFlights();
        }
    }
}
