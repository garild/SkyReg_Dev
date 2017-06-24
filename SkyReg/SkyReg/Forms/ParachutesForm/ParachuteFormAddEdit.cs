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
using DataLayer.Entities.DBContext;
using DataLayer.Result.Repository;

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
            using(SkyRegContext model = new SkyRegContext())
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
                        cmbOwner.SelectedIndex = GetCmbIndexByName(par.User.Name);
                    }
                }
            }
        }

        private int GetCmbIndexByName(string Name)
        {
            int result=0;

            for(int i = 0; i < cmbOwner.Items.Count; i++)
            {
                if (cmbOwner.GetItemText(cmbOwner.Items[i]) == Name)
                    result = i;
            }

            return result;
        }

        private void OwnersComboBoxLoad()
        {
            //TODO dorobić sprawdzanie czy to nie jest pasażer, żeby nie ładowało długiej listy
            using(SkyRegContext model = new SkyRegContext())
            {
                var users = model.User.Select(p => new
                {
                    Name = p.Name,
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
            using (var _ctx = new SkyRegContextRepository<Parachute>())
            {
                int? userId = null;
                if (chkPrivate.Checked)
                    userId = _ctx.Model.User.Where(p => p.Id == (int)cmbOwner.SelectedValue).FirstOrDefault().Id;

                Parachute par = _formState == FormState.Add ? new Parachute() : _ctx.GetById(_parachuteId);

                par.IdNr = txtRegNr.Text;
                par.Name = txtName.Text;
                par.RentValue = numRentValue.Value;
                par.AssemblyValue = numAssembyValue.Value;
                par.User_Id = userId;

                if (_formState == FormState.Add)
                    _ctx.InsertEntity(par);
                else
                    _ctx.Update(par);
            }

        }

        private bool ParachuteValidate()
        {

            //TODO dorobić sprawdzanie numeru ewidencyjnego po edycji czy nie ma już takiego w bazie
            bool result = true;
            errorProvider1.Clear();

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
                if (cmbOwner.SelectedValue == null)
                {
                    errorProvider1.SetError(cmbOwner, "Niewłaściwa wartość pola!");
                    result = false;
                }
            }
            if (_formState == FormState.Add)
            {
                using (SkyRegContext model = new SkyRegContext())
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
                using(SkyRegContext model = new SkyRegContext())
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
