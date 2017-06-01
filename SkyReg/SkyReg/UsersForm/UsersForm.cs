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
    public partial class UsersForm : KryptonForm
    {
        public UsersForm()
        {
            InitializeComponent();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            ParentFormSizeFromParentsWorkSpaceSize();
        }

        private void ParentFormSizeFromParentsWorkSpaceSize()
        {
            Size s = new Size();
            s.Height = this.Parent.Size.Height - 10;
            s.Width = this.Parent.Size.Width - 10;
            this.Size = s;
            this.StartPosition = FormStartPosition.Manual;
        }

        private void UsersForm_Shown(object sender, EventArgs e)
        {
            RefreshGroupList();
            GroupListSetView();
        }

        private void GroupListSetView()
        {
            grdGroups.Columns["Id"].Visible = false;
            grdGroups.Columns["Name"].Visible = true;
            grdGroups.Columns["Color"].Visible = false;
            grdGroups.Columns["AllowDelete"].Visible = false;
            grdGroups.Columns["User"].Visible = false;

            grdGroups.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grdGroups.Columns["Name"].HeaderText = "Grupa";
            grdGroups.RowHeadersVisible = false;

            //for(int i = 0;i<= grdGroups.Rows.Count; i++)
            //{
            //    grdGroups.Rows[i].DefaultCellStyle.BackColor = (Color)grdGroups.Rows[i].Cells["Color"].Value;
            //}

        }

        private void RefreshGroupList()
        {
            using(DLModelContainer model = new DLModelContainer())
            {
                List<Group> groups = model.Group.Select(p => p).OrderBy(p => p.Name).ToList();
                if (groups != null)
                    grdGroups.DataSource = groups;
            }
        }
    }
}
