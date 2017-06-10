﻿using ComponentFactory.Krypton.Toolkit;
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

namespace SkyReg
{
    public partial class AirPlanesFormAddEdit : KryptonForm
    {
        FormState _formState;
        int _airplaneId = -1;

        public EventHandler RefreshAirplanesGridEH;

        public AirPlanesFormAddEdit()
        {
            InitializeComponent();
        }

        public AirPlanesFormAddEdit(FormState formState, int? airplaneId)
        {
            InitializeComponent();
            _formState = formState;
            if(formState == FormState.Edit)
            {
                _airplaneId = airplaneId.Value;
                LoadAirplaneData(airplaneId);
            }
        }

        private void LoadAirplaneData(int? airplaneId)
        {
            using(DLModelContainer model = new DLModelContainer())
            {
                Airplane ap = model.Airplane.Where(p => p.Id == airplaneId.Value).FirstOrDefault();
                if (ap != null)
                {
                    txtName.Text = ap.Name;
                    txtID.Text = ap.RegNr;
                    numSeatsCount.Value = ap.Seats;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(ValidateAirplane() == true)
            {
                SaveAirplane();
            }
        }

        private void SaveAirplane()
        {
            using (DLModelContainer model = new DLModelContainer())
            {
                if (_formState == FormState.Add)
                {
                    Airplane ap = new Airplane();
                    ap.Name = txtName.Text;
                    ap.RegNr = txtID.Text;
                    ap.Seats = (int)numSeatsCount.Value;
                    model.Airplane.Add(ap);
                }
                else
                {
                    Airplane ap = model.Airplane.Where(p => p.Id == _airplaneId).FirstOrDefault();
                    if (ap != null)
                    {
                        ap.Name = txtName.Text;
                        ap.RegNr = txtID.Text;
                        ap.Seats = (int)numSeatsCount.Value;
                    }
                }
                model.SaveChanges();
                RefreshAirplanesGridEH.Invoke(null, null);
                this.Close();
            }
        }

        private bool ValidateAirplane()
        {
            bool result = true;
            errorProvider1.SetError(txtName, string.Empty);
            errorProvider1.SetError(txtID, string.Empty);
            errorProvider1.SetError(numSeatsCount, string.Empty);

            if (txtName.Text == string.Empty)
            {
                errorProvider1.SetError(txtName, "Pole nie może być puste!");
                result = false;
            }
            if(txtID.Text == string.Empty)
            {
                errorProvider1.SetError(txtID, "Pole nie może być puste!");
                result = false;
            }
            if(numSeatsCount.Value < 1)
            {
                errorProvider1.SetError(numSeatsCount, "Wartość musi być większa od 1!");
                result = false;
            }
            if(_formState == FormState.Add)
            {
                using(DLModelContainer model = new DLModelContainer())
                {
                    bool isAirplane = model.Airplane.Any(p => p.RegNr == txtID.Text);
                    if(isAirplane == true)
                    {
                        errorProvider1.SetError(txtID, "Samolot o tym numerze rejestracyjnym już istnieje!");
                        result = false;
                    }
                }
            }
            return result;   
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
