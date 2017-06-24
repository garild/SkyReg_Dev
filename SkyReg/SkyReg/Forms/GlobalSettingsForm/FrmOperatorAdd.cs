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
using DataLayer.Result.Repository;
using SkyRegEnums;
using DataLayer.Entities.DBContext;

namespace SkyReg
{
    public partial class FrmOperatorAdd : KryptonForm
    {
        public FrmOperatorAdd()
        {
            InitializeComponent();
        }

        private void FrmOperatorAdd_Load(object sender, EventArgs e)
        {
            cmbTypes.DataSource = Enum.GetNames(typeof(OperatorTypes));

            using (SkyRegContext model = new SkyRegContext())
            {
                var userList = model.User.Select(p => new
                {
                    Id = p.Id,
                    Name = p.Name
                }).OrderBy(p => p.Name)
                .ToList();

                cmbName.DataSource = userList;
                cmbName.DisplayMember = "Name";
                cmbName.ValueMember = "Id";
            }
        }

        private void btnOperatorCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOperatorAdd_Click(object sender, EventArgs e)
        {
            if (OperatorValidate())
                AddOperator();
        }

        private void AddOperator()
        {
            using (var _operator = new SkyRegContextRepository<Operator>())
            using (var _user = new SkyRegContextRepository<User>())
            {
                OperatorTypes typ = OperatorTypes.Operator;
                Enum.TryParse(cmbTypes.Text, out typ);

                var op = new Operator();
                op.Type = (short)typ;
                op.User_Id = _user.GetById((int)cmbName.SelectedValue).Id;

                if (_operator.InsertEntity(op).IsSuccess)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }

            }
        }

        private bool OperatorValidate()
        {
            var result = true;
            if (cmbName.SelectedValue != null)
            {
                int idUser = (int)cmbName.SelectedValue;

                if (cmbName.SelectedValue == null)
                {
                    errorProvider1.SetError(cmbName, "Pole nie może być puste!");
                    result = false;
                }
                if (cmbTypes.Text == string.Empty)
                {
                    errorProvider1.SetError(cmbTypes, "Pole nie może być puste!");
                    result = false;
                }
                
                errorProvider1.Clear();

                if (idUser > 0)
                {
                    using (SkyRegContext model = new SkyRegContext())
                    {

                        if (model.Operator.Include("User").Any(p => p.User.Id == idUser && p.Type == cmbTypes.SelectedIndex) == true)
                        {
                            errorProvider1.SetError(cmbName, "Taki operator już istnieje");
                            errorProvider1.SetError(cmbTypes, "Taki operator już istnieje");
                            result = false;
                        }
                    }
                }
            }
            else
            {
                errorProvider1.SetError(cmbName, "Wpisana osoba nie istnieje w bazie !");
                result = false;
            }

            return result;

        }

        private void FrmOperatorAdd_Shown(object sender, EventArgs e)
        {
            cmbName.Focus();
        }
    }
}
    

