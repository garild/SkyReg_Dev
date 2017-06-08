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
    public partial class FlightsForm : KryptonForm
    {
        int _lastGridSelectedIndex = -1;
        FlyAddEditForm FlyAddEditForm = null;

        public FlightsForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (grdFlights.SelectedRows.Count > 0)
                _lastGridSelectedIndex = grdFlights.SelectedRows[0].Index;
            RefreshFlightsList();
        }

        private void FlightsForm_Shown(object sender, EventArgs e)
        {
            datSince.Value = DateTime.Now.Date;
            datTo.Value = DateTime.Now.Date;
            RefreshFlightsList();

        }

        private void SetFlightsListView()
        {
            grdFlights.Columns["Id"].Visible = false;

            grdFlights.Columns["Date"].HeaderText = "Data";
            grdFlights.Columns["FlightsNr"].HeaderText = "Numer lotu";
            grdFlights.Columns["AirplaneNr"].HeaderText = "Numer samolotu";
            grdFlights.Columns["Status"].HeaderText = "Status lotu";
            grdFlights.Columns["Altitude"].HeaderText = "Pułap";
            grdFlights.Columns["AvailableSeats"].HeaderText = "Wolne miejsca";
            grdFlights.Columns["FlightsNr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            grdFlights.ReadOnly = true;
            grdFlights.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdFlights.MultiSelect = false;
            grdFlights.AllowUserToResizeColumns = false;
        }

        private void RefreshFlightsList()
        {
            grdFlights.DataSource = null;
            using (DLModelContainer model = new DLModelContainer())
            {
                List<FlightsOnList> flightsList = model.Flight
                    .Include("Airplane")
                    .Include("FlightsElem")
                    .Where(p => p.FlyDateTime >= datSince.Value.Date && p.FlyDateTime <= datTo.Value.Date)
                    .OrderBy(p => p.FlyNr)
                    .Select(p => new FlightsOnList
                    {
                        Id = p.Id,
                        FlightsNr = "LOT " + p.FlyDateTime.Year + @"/" + p.FlyDateTime.Month + @"/" + p.FlyDateTime.Day + @"/" + p.FlyNr,
                        Date = p.FlyDateTime,
                        AirplaneNr = p.Airplane.RegNr,
                        Altitude = p.Altitude,
                        AvailableSeats = p.Airplane.Seats - p.FlightsElem.Count,
                        Status = p.FlyStatus == (short)Enum_flightsStatuses.Opened ? "Otwarty" :
                                    p.FlyStatus == (short)Enum_flightsStatuses.Closed ? "Zamknięty" :
                                    p.FlyStatus == (short)Enum_flightsStatuses.Executed ? "Zrealizowany" :
                                    p.FlyStatus == (short)Enum_flightsStatuses.Canceled ? "Anulowany" :
                                    string.Empty
                    }).ToList();
                grdFlights.DataSource = flightsList;

                SetFlightsListView();
                if (_lastGridSelectedIndex >= 0 && grdFlights.SelectedRows.Count > 0 && _lastGridSelectedIndex <= grdFlights.Rows.Count)
                    grdFlights.Rows[_lastGridSelectedIndex].Selected = true;
            }
        }

        private void btnDatRefresh_Click(object sender, EventArgs e)
        {
            RefreshFlightsList();
        }

        private void btnAddFlight_Click(object sender, EventArgs e)
        {
            FlyAddEditForm = FormsOpened<FlyAddEditForm>.IsOpened(FlyAddEditForm);
            FlyAddEditForm.EventHandlerAddedEditedFlight += RefreshAfterAddedEditedFlight;
            FlyAddEditForm.TopMost = true;
            FlyAddEditForm.FormState = Enum_FormState.Add;
            FlyAddEditForm.FlightId = default(int);
            FlyAddEditForm.ShowDialog();
        }



        private void btnEditFlight_Click(object sender, EventArgs e)
        {
            if (grdFlights.SelectedRows.Count > 0)
            {
                int flightId = (int)grdFlights.SelectedRows[0].Cells["Id"].Value;

                FlyAddEditForm = FormsOpened<FlyAddEditForm>.IsOpened(FlyAddEditForm);
                FlyAddEditForm.EventHandlerAddedEditedFlight += RefreshAfterAddedEditedFlight;
                FlyAddEditForm.TopMost = true;
                FlyAddEditForm.FormState = Enum_FormState.Edit;
                FlyAddEditForm.FlightId = flightId;
                FlyAddEditForm.ShowDialog();
            }
        }

        private void RefreshAfterAddedEditedFlight(object sender, EventArgs e)
        {
            RefreshFlightsList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeleteFlight_Click(object sender, EventArgs e)
        {
            DeleteFlight();
        }

        private void DeleteFlight()
        {
            if (grdFlights.SelectedRows.Count > 0)
            {
                using (DLModelContainer model = new DLModelContainer())
                {
                    int idFlight = (int)grdFlights.SelectedRows[0].Cells["Id"].Value;
                    Flight fly = model.Flight.Where(p => p.Id == idFlight).FirstOrDefault();
                    if(fly != null)
                    {
                        if(KryptonMessageBox.Show("Usunąć zaznaczoną pozycję?", "Usunąć?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            model.Flight.Remove(fly);
                            model.SaveChanges();
                            RefreshFlightsList();
                        }
                    }
                }
            }
        }
    }
}
