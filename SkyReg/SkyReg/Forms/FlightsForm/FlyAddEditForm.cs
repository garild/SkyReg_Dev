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
using System.Text.RegularExpressions;
using DataLayer.Result.Repository;
using SkyRegEnums;
using SkyReg.Common.Extensions;
using DataLayer.Entities.DBContext;

namespace SkyReg
{
    public partial class FlyAddEditForm : KryptonForm
    {
        public EventHandler EventHandlerAddedEditedFlight;//TODO DO wyjebania!

        public FormState _formState { get; set; }
        public int _flightId { get; set; }

        public FlyAddEditForm() 
        {
            InitializeComponent();
            txtFirtPartOfNr.Clear();
            txtLastPartOfNr.Clear();
        }

        private void FlyAddEditForm_Load(object sender, EventArgs e)
        {
            txtFirtPartOfNr.ReadOnly = true;
            LoadAllAirplanes();

            if(_formState == FormState.Add)
            {
                SetDefaultDataFields();
            }
            else
            {
                LoadEditedData();
            }
        }

        private void LoadEditedData()
        {
            using(SkyRegContext model = new SkyRegContext())
            {
                var flight = model.Flight.Include("Airplane").Where(p => p.Id == _flightId).FirstOrDefault();
                if(flight != null)
                {
                    datDate.Value = flight.FlyDateTime;
                    txtFirtPartOfNr.Text = string.Format("LOT {0}", datDate.Value.Date.ToString(@"yy\/MM\/dd"));
                    txtLastPartOfNr.Text = flight.FlyNr;
                    cmbAirplane.SelectedValue = flight.Airplane.Id;
                    numAltitude.Value = flight.Altitude;
                }
            }
        }

        private void LoadAllAirplanes()
        {
            using(SkyRegContextRepository<Airplane> _ctxAirplane = new SkyRegContextRepository<Airplane>())
            {
                var result = _ctxAirplane.GetAll();
                if(result.IsSuccess)
                {
                    List<Airplane> airplanes = result.Value;
                    cmbAirplane.ValueMember = "Id";
                    cmbAirplane.DisplayMember = "RegNr";
                    cmbAirplane.DataSource = airplanes;
                }
               
            }
        }

        private void SetDefaultDataFields()
        {
            datDate.Value = DateTime.Now.Date;
            txtFirtPartOfNr.Text = string.Format("LOT {0}", datDate.Value.Date.ToString(@"yy\/MM\/dd"));
            txtLastPartOfNr.Text = (GetLastDayNumber(datDate.Value.Date) + 1).ToString("00");
            if (cmbAirplane.Items.Count > 0)
                cmbAirplane.SelectedIndex = 0;

        }

        private int GetLastDayNumber(DateTime date)
        {
            int result = 0;
            using(SkyRegContext model = new SkyRegContext())
            {
                var lastDayNr = model.Flight.Where(p => p.FlyDateTime == date).OrderByDescending(p => p.FlyNr).Select(p => p.FlyNr).FirstOrDefault();
                if (lastDayNr.HasValue())
                { 
                    lastDayNr = Regex.Match(lastDayNr, @"\d+").Value;
                    int.TryParse(lastDayNr, out result);
                }           
            }

            return result;
        }

        private void datDate_ValueChanged(object sender, EventArgs e)
        {
            txtFirtPartOfNr.Text = string.Format("LOT {0}", datDate.Value.Date.ToString(@"yy\/MM\/dd"));
            txtLastPartOfNr.Text = (GetLastDayNumber(datDate.Value.Date) + 1).ToString("00");
        }

        private void btnSaveCfg_Click(object sender, EventArgs e)
        {
            if (FlightValidate())
            {
                SaveFlight();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void SaveFlight()
        {
            using(var  _ctx = new SkyRegContextRepository<Flight>())
            {
                Flight fly = _formState == FormState.Add ? new Flight() : _ctx.GetById(_flightId);
                Airplane air = _ctx.Model.Airplane.Where(p => p.Id == (int)cmbAirplane.SelectedValue).FirstOrDefault();

                if (air != null)
                    {
                        fly.Airplane_Id = air.Id;
                        fly.Altitude = (int)numAltitude.Value;
                        fly.FlyDateTime = datDate.Value.Date;
                        fly.FlyNr = txtLastPartOfNr.Text;
                        fly.FlyStatus = (int)FlightsStatus.Opened;

                    if (_formState == FormState.Add)
                        _ctx.InsertEntity(fly);
                    else
                        _ctx.InsertEntity(fly);

                    this.Close();
                    }
            }
        }

        private bool FlightValidate()// TODO Kod Janusza!
        {
            bool result = true;
            errorProvider1.Clear();
            using (SkyRegContext model = new SkyRegContext())
            {
                if(txtLastPartOfNr.Text == string.Empty)
                {
                    errorProvider1.SetError(txtLastPartOfNr, "Pole nie może być puste!");
                    result = false;
                }
                bool isFlight = model.Flight.Any(p => p.FlyNr == txtLastPartOfNr.Text && p.FlyDateTime == datDate.Value.Date && p.Id != _flightId);
                if(isFlight)
                {
                    errorProvider1.SetError(txtLastPartOfNr, "Wylot o tym numerze jest już zaplanowany na wskazany dzień!");
                    result = false;
                }
                if(numAltitude.Value <= 0)
                {
                    errorProvider1.SetError(numAltitude, "Pułap musi być większy od 0!");
                    result = false;
                }
            }
            return result;
        }

        private void FlyAddEditForm_Shown(object sender, EventArgs e)
        {
            datDate.Focus();
        }
    }
}
