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
using SkyRegEnums;
using SkyReg.Common.Extensions;
using DataLayer.Result.Repository;
using DataLayer.Entities.DBContext;

namespace SkyReg
{
    public partial class ScheduleForm : KryptonForm
    {
        private ScheduleAddEditForm ScheduleAddEditForm = null;


        public ScheduleForm()
        {
            InitializeComponent();
        }


        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            RefreshFlightsList();
            //GetLoadData();
        }

        private void RefreshPlanerList()
        {
            using (SkyRegContext model = new SkyRegContext())
            {
                if (grdFlights.SelectedRows.Count > 0)
                {
                    var flyId = grdFlights.SelectedRows[0].Cells["Id"].Value;

                    if (flyId != null)
                    {
                        var elems = model
                            .FlightsElem.Where(p => p.Flight.Id == (int)flyId)
                            .OrderBy(p => p.Lp)
                            .Select(p => new
                            {
                                Id = p.Id,
                                Lp = p.Lp,
                                UserName = p.User == null ? p.TeamName : p.User.Name,
                                //Type = p.User.DefinedUserType.Name,
                                Parachute = p.Parachute.FirstOrDefault().IdNr + " " + p.Parachute.FirstOrDefault().Name,
                                AssemblyType = p.AssemblySelf == true ? "Układa sam" : "Układalnia",
                                Color = p.Color
                            })
                            .ToList();
                        grdPlaner.DataSource = elems;
                        SetPlanerListView();
                    }
                }
            }
        }

        private void SetPlanerListView()
        {
            if (grdPlaner.Rows.Count > 0)
            {
               // grdPlaner.Columns["Name"].Visible = false;
                grdPlaner.Columns["Id"].Visible = false;
                grdPlaner.Columns["Color"].Visible = false;

                grdPlaner.Columns["Lp"].Width = 40;
                //grdPlaner.Columns["Type"].Width = 200;
                grdPlaner.Columns["Parachute"].Width = 200;
                grdPlaner.Columns["AssemblyType"].Width = 90;
                grdPlaner.Columns["UserName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //grdPlaner.Columns["Type"].HeaderText = "Typ skoczka";
                grdPlaner.Columns["Parachute"].HeaderText = "Spadochron";
                grdPlaner.Columns["AssemblyType"].HeaderText = "Typ układania";
                grdPlaner.Columns["UserName"].HeaderText = "Nazwisko i imię";

                grdPlaner.AllowUserToResizeRows = false;
                grdPlaner.ReadOnly = true;
                grdPlaner.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grdPlaner.MultiSelect = false;
                grdPlaner.RowHeadersVisible = false;

                foreach (DataGridViewRow item in grdPlaner.Rows)
                {
                    if (item != null)
                    {
                        item.DefaultCellStyle.BackColor = Color.FromName(item.Cells["Color"].Value.ToString());
                    }
                }

            }
        }

        private void RefreshFlightsList()
        {
            using (SkyRegContext model = new SkyRegContext())
            {
                var flightsList = model
                    .Flight
                    .Include("FlightsElem")
                    .Include("Airplanes")
                    .AsNoTracking()
                    .Where(p => p.FlyDateTime >= datSinceFlights.Value.Date && p.FlyDateTime <= datToFlights.Value.Date)
                    .OrderBy(p => p.FlyNr)
                    .Select(p => new
                    {
                        Id = p.Id,
                        Number = "LOT " + p.FlyDateTime.Year + @"/" + p.FlyDateTime.Month + @"/" + p.FlyDateTime.Day + @"/" + p.FlyNr,
                        Places = p.Airplane.Seats - p.FlightsElem.Count,
                        Status = p.FlyStatus
                    }).ToList();

                if(flightsList.Count > 0)
                {
                    grdFlights.DataSource = null;
                    grdFlights.DataSource = flightsList;
                    grdFlights.Refresh();
                    SetFlightsListView();
                }
               
            }
        }

        private void SetFlightsListView()
        {
            grdFlights.Columns["Id"].Visible = false;
            grdFlights.Columns["Status"].Visible = false;
            grdFlights.RowHeadersVisible = false;

            grdFlights.Columns["Places"].Width = 50;
            grdFlights.Columns["Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            grdFlights.Columns["Number"].HeaderText = "Numer lotu";
            grdFlights.Columns["Places"].HeaderText = "Wolne";

            grdFlights.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdFlights.MultiSelect = false;
            grdFlights.AllowUserToResizeRows = false;

            foreach (DataGridViewRow item in grdFlights.Rows)
            {
                if (int.Parse(item.Cells["Status"].Value.ToString()) == (int)FlightsStatus.Executed)
                    item.DefaultCellStyle.BackColor = Color.LightGreen;
                if (int.Parse(item.Cells["Status"].Value.ToString()) == (int)FlightsStatus.Canceled)
                    item.DefaultCellStyle.BackColor = Color.LightPink;
            }


        }

        private void btnRefreshFlights_Click(object sender, EventArgs e)
        {
            RefreshFlightsList();
            RefreshPlanerList();
        }

        private void ScheduleForm_Shown(object sender, EventArgs e)
        {
            SetFlightsListView();
            RefreshPlanerList();
        }

        private void grdFlights_SelectionChanged(object sender, EventArgs e)
        {
            LoadAirplaneAndAltitude();
            RefreshPlanerList();
        }

        private void LoadAirplaneAndAltitude()
        {
            if (grdFlights.SelectedRows.Count > 0)
            {
                int idFlight = int.Parse(grdFlights.SelectedRows[0].Cells["Id"].Value.ToString());
                using (SkyRegContext model = new SkyRegContext())
                {
                    var flight = model
                        .Flight
                        .Include("Airplane")
                        .AsNoTracking()
                        .Where(p => p.Id == idFlight)
                        .FirstOrDefault();
                    if (flight != null)
                    {
                        txtAirplane.Text = string.Format("{0} {1}", flight.Airplane.Name, flight.Airplane.RegNr);
                        txtAltitude.Text = flight.Altitude.ToString();
                    }
                }
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            MoveSelectFlight(-1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            MoveSelectFlight(1);
        }

        private void MoveSelectFlight(int value)
        {
            int currentSelectIndex = grdFlights.SelectedRows[0].Index;
            int allFlightsRows = grdFlights.Rows.Count - 1;
            if (value == -1 && currentSelectIndex > 0)
                grdFlights.Rows[currentSelectIndex - 1].Selected = true;
            if (value == 1 && currentSelectIndex < allFlightsRows)
                grdFlights.Rows[currentSelectIndex + 1].Selected = true;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (grdFlights.SelectedRows.Count > 0)
            {
                int flyStatus = int.Parse( grdFlights.SelectedRows[0].Cells["Status"].Value.ToString() ); 
                bool allowShowForm = true;

                if (flyStatus == (int)SkyRegEnums.FlightsStatus.Executed || flyStatus == (int)SkyRegEnums.FlightsStatus.Canceled)
                {
                    allowShowForm = false;
                    if (KryptonMessageBox.Show("Zaznaczony lot posiada status zrealizowany lub anulowany.\nCzy kontynuować?", "Kontynuować?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        allowShowForm = true;
                    }
                }

                if (allowShowForm == true)
                {
                    ScheduleAddEditForm = FormsOpened<ScheduleAddEditForm>.IsOpened(ScheduleAddEditForm);
                    ScheduleAddEditForm.FormState = FormState.Add;
                    ScheduleAddEditForm.IdScheduleElem = default(int);
                    ScheduleAddEditForm.grdFlight = grdFlights;
                    ScheduleAddEditForm.grdPlaner = grdPlaner;
                    if (ScheduleAddEditForm.ShowDialog() == DialogResult.OK)
                    {
                        RefreshFlightsList();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (var _ctx = new SkyRegContextRepository<FlightsElem>())
            using (var _ctxPayment = new SkyRegContextRepository<Payment>())
            {
                if (grdPlaner.SelectedRows.Count > 0)
                {
                    if (KryptonMessageBox.Show("Czy usunąć zaznaczony element?", "Usunąć?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int idFlightElem = (int)grdPlaner.SelectedRows[0].Cells["Id"].Value;

                        List<int> paysId = _ctx.Model.Payment.Include("FlightsElem").Include("PaymentsSetting").Include("User").AsNoTracking().Where(p => p.FlightsElem.Id == idFlightElem).Select(p => p.Id).ToList();

                        foreach (int idPay in paysId)
                        {
                            Payment pay = _ctx.Model.Payment.Where(p => p.Id == idPay).FirstOrDefault();
                            if (pay != null)
                            {
                                _ctxPayment.Delete(pay);
                            }
                        }

                        FlightsElem fe = _ctx.GetById(idFlightElem);
                        _ctx.Delete(fe);

                    }
                }
                RefreshFlightsList();
                RefreshPlanerList();
            }
        }

        #region Test
        private void GetLoadData()
        {
            grdOrders.Columns.Add("name", "Name");
            grdPlaner.Columns.Add("name", "Name");
            grdOrders.Rows.Add(5);
            grdOrders.Rows[0].Cells[0].Value = "Garib";
            grdOrders.Rows[1].Cells[0].Value = "Paweł";
            grdOrders.Rows[2].Cells[0].Value = "Wojtek";
            grdOrders.Rows[3].Cells[0].Value = "Aneta";
            grdOrders.Rows[4].Cells[0].Value = "Jasio";
        }




        int rowToDelete;
        List<DataGridViewRow> rw = new List<DataGridViewRow>();

        private void grdPlaner_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<DataGridViewRow>)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void grdPlaner_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<DataGridViewRow>)))
            {
                int rowCount = 0;
                rw.ForEach(p =>
                {
                    rowCount = grdPlaner.Rows.Count;
                    grdPlaner.Rows.Insert(rowCount > 0 ? rowCount - 1 : rowCount, p.Cells[0].Value); //TODO otworzyć formatkę i dodać dane
                    grdOrders.Rows.RemoveAt(p.Index);

                });

            }
        }

        private void grdOrders_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            rowToDelete = (int)e.RowIndex;
            rw = new List<DataGridViewRow>();
            foreach (DataGridViewRow item in grdOrders.SelectedRows)
            {
                rw.Add(grdOrders.Rows[item.Index]);

            }
            grdOrders.DoDragDrop(rw, DragDropEffects.Copy);
        }

        #endregion

        private void btnCopyRecord_Click(object sender, EventArgs e)
        {
            if (grdOrders.SelectedRows.Count > 0)
            {
                int rowCount = 0;
                foreach (DataGridViewRow p in grdOrders.SelectedRows)
                {
                    rowCount = grdPlaner.Rows.Count;
                    grdPlaner.Rows.Insert(rowCount > 0 ? rowCount - 1 : rowCount, p.Cells[0].Value);
                    grdOrders.Rows.RemoveAt(p.Index);
                }
            }
        }

        private void btnRightCopyRecord_Click(object sender, EventArgs e)
        {
            if (grdPlaner.SelectedRows.Count > 0)
            {
                int rowCount = 0;
                foreach (DataGridViewRow p in grdPlaner.SelectedRows)
                {
                    rowCount = grdOrders.Rows.Count;
                    grdOrders.Rows.Insert(rowCount > 0 ? rowCount - 1 : rowCount, p.Cells[0].Value);
                    grdPlaner.Rows.RemoveAt(p.Index);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (SkyRegContext model = new SkyRegContext())
            {
                if (grdFlights.SelectedRows.Count > 0)
                {
                    int flyId = (int)grdFlights.SelectedRows[0].Cells["Id"].Value;
                    Flight fly = model.Flight.Where(p => p.Id == flyId).FirstOrDefault();
                    if (fly != null)
                    {
                        if (KryptonMessageBox.Show("Zmienić status lotu na zrealizowany?", "Zmienić?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            fly.FlyStatus = (int)FlightsStatus.Executed;
                            model.SaveChanges();
                            RefreshFlightsList();
                            RefreshPlanerList();
                        }
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
