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
            //ParentFormSizeFromParentsWorkSpaceSize();
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
            grdGroups.ReadOnly = true;
            grdGroups.AllowUserToResizeRows = false;

            for (int i = 0; i <= grdGroups.Rows.Count-1; i++)
            {
                grdGroups.Rows[i].DefaultCellStyle.BackColor = Color.FromName(grdGroups.Rows[i].Cells["Color"].Value.ToString());
            }

        }

        private void RefreshGroupList()
        {
            using(DLModelContainer model = new DLModelContainer())
            {
                List<Group> groups = model.Group.Select(p => p).OrderBy(p => p.Id).ToList();
                if (groups != null)
                {
                    grdGroups.DataSource = groups;
                    //po przeładowaniu grid grup ustawia select na pierwszym elemencie
                    grdGroups.Rows[0].Selected = true;
                }
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            GroupAddForm gad = new GroupAddForm();
            gad.MdiParent = this.MdiParent;
            gad.GRoupAddedEH += GroupAddedEventHandler;
            gad.Show();
        }

        private void GroupAddedEventHandler(object sender, EventArgs e)
        {
            RefreshGroupList();
            GroupListSetView();
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            if(grdGroups.SelectedRows.Count > 0)
            {
                TryDeleteGroup();
            }
        }

        private void TryDeleteGroup()
        {
            using(DLModelContainer model = new DLModelContainer())
            {
                int groupId = (int)grdGroups.SelectedRows[0].Cells["Id"].Value;
                bool isGroupElement = model.User.Include("Group").Any(p => p.Group.Id == groupId);
                if (isGroupElement)
                {
                    KryptonMessageBox.Show("Nie można usunąć zaznaczonej grupy ponieważ zawiera elementy!\nUsuń najpierw elementy grupy i spróbuj ponownie.", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    if(KryptonMessageBox.Show("Usunąć zaznaczoną pozycję?", "Usunąć?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var group = model.Group.Where(p => p.Id == groupId).FirstOrDefault();
                        if(group != null)
                        {
                            model.Group.Remove(group);
                            model.SaveChanges();
                            GroupAddedEventHandler(null, null);
                        }
                    }
                }
            }
        }
    }
}
