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


        public ScheduleAddEditForm()
        {
            InitializeComponent();
        }

        private void ScheduleAddEditForm_Load(object sender, EventArgs e)
        {
            LoadFlightsOnGrid();
            LoadUsers();
            LoadUserTypes();
            if (FormState == FormState.Add)
            {

            }
            else
            {

            }
        }

        private void LoadUserTypes()
        {
            using(DLModelContainer model = new DLModelContainer())
            {
                //int selectedUser = (int)cmbName.SelectedValue;

                //if (selectedUser != default(int))
                //    var usersTypesList = model
                //        .UsersType
                //        .Include("User")
                //        .AsNoTracking()
                //        .Where(p => p.User.Id == selectedUser)
                //        .ToList();

            }
        }

        private void LoadUsers()
        {
            using(DLModelContainer model = new DLModelContainer())
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
                    .OrderBy(p=>p.FlyNr)
                    .Select(p=> new
                    {
                        Id = p.Id,
                        Nr = "LOT " + p.FlyDateTime.Year + @"/" + p.FlyDateTime.Month + @"/" + p.FlyDateTime.Day + @"/" + p.FlyNr
                    })
                    .ToList();
                if(flightsList != null)
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
    }
}
