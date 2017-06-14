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

namespace SkyReg
{
    public partial class ParachuteFormAddEdit : KryptonForm
    {
        public FormState? _formState;
        public int? _parachuteId = -1;

        public EventHandler ParachuteAddedEdited;//TODO Kod Janusza

        public ParachuteFormAddEdit()
        {
            InitializeComponent();
           
        }

        private void chkPrivate_CheckedChanged(object sender, EventArgs e)
        {
            cmbOwnerEnableDisable();
        }

        private void cmbOwnerEnableDisable()
        {
            if (chkPrivate.Checked)
                cmbOwner.Enabled = true;
            else
                cmbOwner.Enabled = false;
        }

        private void ParachuteFormAddEdit_Load(object sender, EventArgs e)
        {
            OwnersComboBoxLoad();

            if (_formState == FormState.Edit && _parachuteId > 0)
            {
                LoadParachuteData(_parachuteId);
            }
            
            cmbOwnerEnableDisable();
        }

        private void LoadParachuteData(int? parachuteId)
        {
            using(DLModelContainer model = new DLModelContainer())
            {
                Parachute par = model.Parachute.Include("User").Where(p => p.Id == parachuteId).FirstOrDefault();
                if (par != null)
                {
                    txtRegNr.Text = par.IdNr;
                    txtName.Text = par.Name;
                    numRentValue.Value = par.RentValue.Value;
                    numAssembyValue.Value = par.AssemblyValue.Value;
                    if (par.User != null)
                    {
                        chkPrivate.Checked = true;
                        cmbOwner.SelectedIndex = GetCmbIndexByName(par.User.SurName, par.User.FirstName);
                    }
                }
            }
        }

        private int GetCmbIndexByName(string surName, string firstName)
        {
            int result=0;

            string fullName = string.Format("{0} {1}", surName, firstName);
            for(int i = 0; i < cmbOwner.Items.Count; i++)
            {
                if (cmbOwner.GetItemText(cmbOwner.Items[i]) == fullName)
                    result = i;
            }

            return result;
        }

        private void OwnersComboBoxLoad()
        {
            //TODO dorobić sprawdzanie czy to nie jest pasażer, żeby nie ładowało długiej listy
            using(DLModelContainer model = new DLModelContainer())
            {
                var users = model.User.Select(p => new
                {
                    Name = p.SurName + " " + p.FirstName,
                    Id = p.Id
                })
                .OrderBy(p => p.Name)
                .ToList();

                cmbOwner.DataSource = users;
                cmbOwner.ValueMember = "Id";
                cmbOwner.DisplayMember = "Name";
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(ParachuteValidate())
            {
                ParachuteSave();
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void ParachuteSave() //TODO Kod Janusza Edycja nie działa!!
        {
            using (DLModelContainer model = new DLModelContainer())
            {
                if (_formState == FormState.Add)
                {
                    Parachute par = new Parachute();
                    par.IdNr = txtRegNr.Text;
                    par.Name = txtName.Text;
                    par.RentValue = numRentValue.Value;
                    par.AssemblyValue = numAssembyValue.Value;
                    if (chkPrivate.Checked)
                        par.User = model.User.Where(p => p.Id == (int)cmbOwner.SelectedValue).FirstOrDefault();
                    model.Parachute.Add(par);
                }
                else
                {
                    Parachute par = model.Parachute.Where(p => p.Id == _parachuteId).FirstOrDefault();
                    if (par != null)
                    {
                        par.IdNr = txtRegNr.Text;
                        par.Name = txtName.Text;
                        par.RentValue = numRentValue.Value;
                        par.AssemblyValue = numAssembyValue.Value;
                        if (chkPrivate.Checked)
                            par.User = model.User.Where(p => p.Id == (int)cmbOwner.SelectedValue).FirstOrDefault();
                    }
                }
                model.SaveChanges();
            }
        }

        private bool ParachuteValidate()
        {

            //TODO dorobić sprawdzanie numeru ewidencyjnego po edycji czy nie ma już takiego w bazie
            bool result = true;
            errorProvider1.SetError(txtRegNr, string.Empty);
            errorProvider1.SetError(txtName, string.Empty);
            errorProvider1.SetError(cmbOwner, string.Empty);

            if(txtRegNr.Text == string.Empty)
            {
                errorProvider1.SetError(txtRegNr, "Pole nie może być puste!");
                result = false;
            }
            if(txtName.Text == string.Empty)
            {
                errorProvider1.SetError(txtName, "Pole nie może być puste!");
                result = false;
            }
            if (chkPrivate.Checked)
            {
                using(DLModelContainer model = new DLModelContainer())
                {
                    if (cmbOwner.SelectedValue != null)
                    {
                        bool isUser = model.User.Any(p => p.Id == (int)cmbOwner.SelectedValue);
                        if (isUser == false)
                        {
                            errorProvider1.SetError(cmbOwner, "Nie odnaleziono użytkownika!");
                            result = false;
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(cmbOwner, "Niewłaściwa wartość pola!");
                        result = false;
                    }
                }
            }
            if(_formState == FormState.Add)
            {
                using(DLModelContainer model = new DLModelContainer())
                {
                    bool isParachute = model.Parachute.Any(p => p.IdNr == txtRegNr.Text);
                    if(isParachute == true)
                    {
                        errorProvider1.SetError(txtRegNr, "Spadochron o tym numerze już istnieje!");
                        result = false;
                    }
                }
            }
            else
            {
                using(DLModelContainer model = new DLModelContainer())
                {
                    bool isParachute = model.Parachute.Any(p => p.IdNr == txtRegNr.Text && p.Id != _parachuteId);
                    if(isParachute == true)
                    {
                        errorProvider1.SetError(txtRegNr, "Spadochron o tym numerze już istnieje!");
                        result = false;
                    }
                }
            }

            return result;
        }

        private void ParachuteFormAddEdit_Shown(object sender, EventArgs e)
        {
            txtRegNr.Focus();
        }
    }
}
