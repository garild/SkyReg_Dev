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



            GetLoadData();
        }

        private void RefreshFlightsList()
        {
            using(DLModelContainer model = new DLModelContainer())
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

                grdFlights.DataSource = flightsList;
                SetFlightsListView();
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

            foreach(DataGridViewRow item in grdFlights.Rows)
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
        }

        private void ScheduleForm_Shown(object sender, EventArgs e)
        {
            SetFlightsListView();
        }

        private void grdFlights_SelectionChanged(object sender, EventArgs e)
        {
            LoadAirplaneAndAltitude();
            LoadScheduleData();
        }

        private void LoadScheduleData()
        {
            using(DLModelContainer model = new DLModelContainer())
            {

            }
        }

        private void LoadAirplaneAndAltitude()
        {
            if(grdFlights.SelectedRows.Count > 0)
            {
                int idFlight = int.Parse(grdFlights.SelectedRows[0].Cells["Id"].Value.ToString());
                using(DLModelContainer model = new DLModelContainer())
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
            int allFlightsRows = grdFlights.Rows.Count-1;
            if (value == -1 && currentSelectIndex > 0)
                grdFlights.Rows[currentSelectIndex - 1].Selected = true;
            if (value == 1 && currentSelectIndex < allFlightsRows)
                grdFlights.Rows[currentSelectIndex + 1].Selected = true;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ScheduleAddEditForm = FormsOpened<ScheduleAddEditForm>.IsOpened(new ScheduleAddEditForm());
            ScheduleAddEditForm.FormState = FormState.Add;
            ScheduleAddEditForm.IdScheduleElem = default(int);
            if (ScheduleAddEditForm.ShowDialog() == DialogResult.OK)
            {
                RefreshFlightsList();
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
                    grdPlaner.Rows.Insert(rowCount > 0 ? rowCount - 1: rowCount, p.Cells[0].Value); //TODO otworzyć formatkę i dodać dane
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
            if(grdOrders.SelectedRows.Count > 0)
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
    }
}
