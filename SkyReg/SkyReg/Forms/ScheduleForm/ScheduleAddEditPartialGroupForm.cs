using ComponentFactory.Krypton.Toolkit;
using SkyRegEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer;
using DataLayer.Result.Repository;

namespace SkyReg
{
    public partial class ScheduleAddEditForm : KryptonForm
    {
        private void TryAddGroup()
        {
            if( ValidateForGroupAdd())
            {
                AddGroupToDB();
            }
        }

        private void AddGroupToDB()
        {
            using (DLModelContainer model = new DLModelContainer())
            {
                foreach (DataGridViewRow item in grdFlightsForGroup.Rows)
                {
                    if (item.Cells["Check"].Value != null)
                    {
                        int idFly = (int)item.Cells["Id"].Value;
                        Flight fly = model.Flight.Where(p => p.Id == idFly).FirstOrDefault();
                        if (fly != null)
                        {
                            for (int n = 0; n < numUsersCount.Value; n++)
                            {
                                FlightsElem fe = new FlightsElem();
                                fe.Color = btnColorGroup.SelectedColor.Name;
                                fe.Flight = fly;
                                fe.Lp = model.FlightsElem.Where(p => p.Flight.Id == idFly).ToList().Count + 1;
                                fe.TeamName = txtGroupName.Text;
                                model.FlightsElem.Attach(fe);
                                model.FlightsElem.Add(fe);
                                model.SaveChanges();
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }
                    }
                }
            }
        }

        private bool ValidateForGroupAdd()
        {
            bool result = true;

            errorProvider1.Clear();

            if(txtGroupName.Text == string.Empty)
            {
                errorProvider1.SetError(txtGroupName, "Wartość nie może być pusta!");
                result = false;
            }

            if(numUsersCount.Value <= 0)
            {
                errorProvider1.SetError(numUsersCount, "Wartość musi być większa od zera!");
                result = false;
            }

            string message = default(string);
            if (result == true)
            {
                if ((int)grdFlight.SelectedRows[0].Cells["Places"].Value < numUsersCount.Value)
                {
                    message += string.Format("W wylocie {0} brak miejsc!\n", grdFlight.SelectedRows[0].Cells["Number"].Value.ToString());
                    result = false;
                }


                foreach (DataGridViewRow item in grdFlightsForGroup.Rows)
                {
                    if (item.Cells["Check"].Value != null)
                    {
                        if ((int)item.Cells["AllSeats"].Value - (int)item.Cells["BusySeats"].Value < numUsersCount.Value)
                        {
                            message += string.Format("W wylocie {0} brak miejsc!\n", item.Cells["Nr"].Value.ToString());
                            result = false;
                        }
                    }
                }
                if (message != default(string))
                    KryptonMessageBox.Show(message, "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


            return result;
        }

        private void LoadFlightsOnGridGroup()
        {
            using (DLModelContainer model = new DLModelContainer())
            {
                DateTime dateNow = DateTime.Now.Date;

                var flightsList = model
                    .Flight
                    .Where(p => p.FlyDateTime == dateNow && (p.FlyStatus == (int)FlightsStatus.Opened || p.FlyStatus == (int)FlightsStatus.Closed))
                    .OrderBy(p => p.FlyNr)
                    .Select(p => new
                    {
                        Id = p.Id,
                        Nr = "LOT " + p.FlyDateTime.Year + @"/" + p.FlyDateTime.Month + @"/" + p.FlyDateTime.Day + @"/" + p.FlyNr,
                        AllSeats = p.Airplane.Seats,
                        BusySeats = p.FlightsElem.Count
                    })
                    .ToList();
                if (flightsList != null)
                {
                    grdFlightsForGroup.DataSource = flightsList;
                    SetFlightsGroupView();
                }

            }
        }

        private void SetFlightsGroupView()
        {
            grdFlightsForGroup.ReadOnly = false;
            grdFlightsForGroup.Columns["Id"].Visible = false;
            DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
            col.ReadOnly = false;
            col.Name = "Check";
            col.HeaderText = "Wybór";
            col.Width = 50;
            grdFlightsForGroup.Columns.Add(col);
            grdFlightsForGroup.Columns["Nr"].HeaderText = "Numer";
            grdFlightsForGroup.Columns["Nr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            grdFlightsForGroup.ReadOnly = false;
            grdFlightsForGroup.AllowUserToResizeRows = false;
            grdFlightsForGroup.RowHeadersVisible = false;

            grdFlightsForGroup.Columns["Check"].DisplayIndex = 0;
            grdFlightsForGroup.Columns["Nr"].DisplayIndex = 1;

            grdFlightsForGroup.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdFlightsForGroup.MultiSelect = false;

            grdFlightsForGroup.Columns["AllSeats"].Visible = false;
            grdFlightsForGroup.Columns["BusySeats"].Visible = false;
        }
    }
}
