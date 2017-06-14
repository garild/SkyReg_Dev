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

namespace SkyReg
{
    public partial class ScheduleAddEditForm : KryptonForm
    {
        public FormState FormState { get; set; }
        public int IdScheduleElem { get; set; }
        public KryptonDataGridView grdFlight { get; set; }

        public ScheduleAddEditForm()
        {
            InitializeComponent();
        }

        private void ScheduleAddEditForm_Load(object sender, EventArgs e)
        {
            LoadFlightsOnGrid();
            LoadUsers();
            LoadParachutes();

            if (FormState == FormState.Add)
            {

            }
            else
            {

            }
        }

        private void LoadParachutes()
        {
            using (DLModelContainer model = new DLModelContainer())
            {

                int curFlightsIndex = grdFlight.SelectedRows[0].Cells["Id"].RowIndex;
                List<Parachute> parachuteNotAvaliable = new List<Parachute>();
                if (curFlightsIndex > 0)
                {
                    int prevFlightId = (int)grdFlight.Rows[curFlightsIndex - 1].Cells["Id"].Value;
                    parachuteNotAvaliable.AddRange(model.FlightsElem.Where(p => p.Flight.Id == prevFlightId).SelectMany(p => p.Parachute).ToList());
                }
                if(curFlightsIndex < grdFlight.Rows.Count - 1)
                {
                    int nextFlightId = (int)grdFlight.Rows[curFlightsIndex + 1].Cells["Id"].Value;
                    parachuteNotAvaliable.AddRange(model.FlightsElem.Where(p => p.Flight.Id == nextFlightId).SelectMany(p => p.Parachute).ToList());
                }

                var allParachutes = model.Parachute.OrderBy(p => p.IdNr).ToList();
                List<Parachute> avaliableParachutes = new List<Parachute>();
                foreach(var item in allParachutes)
                {
                    if (!parachuteNotAvaliable.Any(p => p.Id == item.Id))
                        avaliableParachutes.Add(item);
                }

                cmbParachute.DataSource = avaliableParachutes;
                cmbParachute.DisplayMember = "IdNr";
                cmbParachute.ValueMember = "Id";

            }          

        }

        private void LoadUserTypes()
        {
            using (DLModelContainer model = new DLModelContainer())
            {

                cmbName.DisplayMember = "Name";
                cmbName.ValueMember = "Id";
                int selectedUser = (int)cmbName.SelectedValue;
                List<UsersType> usersTypesList = null;
                if (selectedUser != default(int))
                {
                    var user = model.User.Where(p => p.Id == selectedUser).FirstOrDefault();
                    if (user != null)
                    {
                        usersTypesList = model.User.Where(p => p.Id == selectedUser).SelectMany(p => p.UsersType).ToList();
                    }
                }
                else
                {
                    usersTypesList = model
                        .UsersType
                        .OrderBy(p => p.Name)
                        .ToList();
                }
                cmbUsersType.DataSource = usersTypesList;
                cmbUsersType.DisplayMember = "Name";
                cmbUsersType.ValueMember = "Id";
            }
        }

        private void LoadUsers()
        {
            using (DLModelContainer model = new DLModelContainer())
            {
                var users = model.User
                    .OrderBy(p => p.SurName)
                    .ThenBy(p => p.FirstName)
                    .Select(p => new
                    {
                        Name = p.SurName + " " + p.FirstName,
                        Id = p.Id
                    }).ToList();
                cmbName.DataSource = users;
                cmbName.DisplayMember = "Name";
                cmbName.ValueMember = "Id";
            }
        }

        private void LoadFlightsOnGrid()
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
                        Nr = "LOT " + p.FlyDateTime.Year + @"/" + p.FlyDateTime.Month + @"/" + p.FlyDateTime.Day + @"/" + p.FlyNr
                    })
                    .ToList();
                if (flightsList != null)
                {
                    grdFlightsListSelectedForUser.DataSource = flightsList;
                    SetFlightsUserView();
                }

            }

        }

        private void SetFlightsUserView()
        {
            grdFlightsListSelectedForUser.ReadOnly = false;
            grdFlightsListSelectedForUser.Columns["Id"].Visible = false;
            DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
            col.ReadOnly = false;
            col.Name = "Check";
            col.HeaderText = "Wybór";
            col.Width = 50;
            grdFlightsListSelectedForUser.Columns.Add(col);
            grdFlightsListSelectedForUser.Columns["Nr"].HeaderText = "Numer";
            grdFlightsListSelectedForUser.Columns["Nr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            grdFlightsListSelectedForUser.ReadOnly = false;
            grdFlightsListSelectedForUser.AllowUserToResizeRows = false;
            grdFlightsListSelectedForUser.RowHeadersVisible = false;

            grdFlightsListSelectedForUser.Columns["Check"].DisplayIndex = 0;
            grdFlightsListSelectedForUser.Columns["Nr"].DisplayIndex = 1;

            grdFlightsListSelectedForUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdFlightsListSelectedForUser.MultiSelect = false;



        }

        private void cmbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUserTypes();
        }
    }
}
