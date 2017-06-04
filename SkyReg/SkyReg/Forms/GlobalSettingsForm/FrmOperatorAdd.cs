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

namespace SkyReg
{
    public partial class FrmOperatorAdd : KryptonForm
    {
        public EventHandler AddedUser;


        public FrmOperatorAdd()
        {
            InitializeComponent();
            cmbTypes.SelectedIndex = 0;
        }

        private void FrmOperatorAdd_Load(object sender, EventArgs e)
        {
            using(DLModelContainer model = new DLModelContainer())
            {
                List<UserOnComboBox> usersList = new List<UserOnComboBox>();

                usersList = model.User.Select(p => new UserOnComboBox
                {
                    Id = p.Id,
                    Name = p.SurName + " " + p.FirstName
                }).OrderBy(p => p.Name)
                .ToList();

                cmbName.DataSource = usersList;
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
            if(addOperatorValidate() == true)
            {
                addOperatorToDB();
            }

        }

        private void addOperatorToDB()
        {
            using( DLModelContainer model = new DLModelContainer())
            {
                short typ;
                if (cmbTypes.Text == "Operator")
                    typ = (short)Enum_OperatorTypes.Operator;
                else
                    typ = (short)Enum_OperatorTypes.Registrar;

                Operator op = new Operator();
                op.Type = typ;
                op.User = model.User.Where(p => p.Id == (int)cmbName.SelectedValue).FirstOrDefault();
                model.Operator.Add(op);
                model.SaveChanges();
                AddedUser.Invoke(this, null);
                this.Close();
            }
        }

        private bool addOperatorValidate()
        {
            bool result = true;

            if (cmbName.SelectedValue == null)
            {
                errorProvider1.SetError(cmbName, "Pole nie może być puste!");
                result = false;
            }
            else
            {
                errorProvider1.SetError(cmbName, string.Empty);
            }
            if(cmbTypes.Text == string.Empty)
            {
                errorProvider1.SetError(cmbTypes, "Pole nie może być puste!");
                result = false;
            }
            else
            {
                errorProvider1.SetError(cmbTypes, string.Empty);
            }

            using (DLModelContainer model = new DLModelContainer())
            {
                short typ;
                if (cmbTypes.Text == "Operator")
                    typ = (int)Enum_OperatorTypes.Operator;
                else
                    typ = (int)Enum_OperatorTypes.Registrar;

                int idUser = (int)cmbName.SelectedValue;
                if( model.Operator.Include("User").Any(p => p.User.Id == idUser && p.Type == typ) == true)
                {
                    errorProvider1.SetError(cmbName, "Taki operator już istnieje");
                    errorProvider1.SetError(cmbTypes, "Taki operator już istnieje");
                    result = false;
                }
            }

            if(result == true)
            {
                errorProvider1.SetError(cmbName, string.Empty);
                errorProvider1.SetError(cmbTypes, string.Empty);
            }

            return result;

        }
    }
}
