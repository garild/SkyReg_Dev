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
    public partial class GroupAddForm : KryptonForm
    {
        public EventHandler GRoupAddedEH;

        public GroupAddForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(ValidateGroup() == true)
            {
                SaveGroup();
            }
        }

        private void SaveGroup()
        {
            using(DLModelContainer model = new DLModelContainer())
            {
                Group gr = new Group();
                gr.Name = txtGroupName.Text;
                gr.Color = colorBtn.SelectedColor.Name;
                gr.AllowDelete = false;
                model.Group.Add(gr);
                model.SaveChanges();
                GRoupAddedEH(null, null);
                this.Close();
            }
        }

        private bool ValidateGroup()
        {
            bool result = true;
            errorProvider1.SetError(txtGroupName, string.Empty);

            if(txtGroupName.Text == string.Empty)
            {
                errorProvider1.SetError(txtGroupName, "Pole nie może być puste!");
                result = false;
            }
            using (DLModelContainer model = new DLModelContainer())
            {
                bool isGroupName = model.Group.Any(p => p.Name == txtGroupName.Text);
                if (isGroupName)
                {
                    errorProvider1.SetError(txtGroupName, "Grupa o tej nazwie już istnieje!");
                    result = false;
                }
            }
            return result;
        }
    }
}
