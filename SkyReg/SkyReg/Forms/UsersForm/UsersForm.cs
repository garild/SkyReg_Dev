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
using DataLayer.Result.Repository;
using SkyReg.Common.Extensions;
using SkyRegEnums;
using DataLayer.Entities.DBContext;

namespace SkyReg
{
    public partial class UsersForm : KryptonForm
    {
        private UsersAddEditForm UsersAddEditForm = null;


        public UsersForm()
        {
            InitializeComponent();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            LoadGroupToCmbGroup();
        }

        private void LoadGroupToCmbGroup()
        {
            using (SkyRegContextRepository<Group> _contextGroup = new SkyRegContextRepository<Group>())
            {
                var allGroup = _contextGroup.GetAll().Value;

                cmbGroup.DataSource = allGroup.Select(p => p).OrderBy(p => p.Id).ToList();
                cmbGroup.ValueMember = "Id";
                cmbGroup.DisplayMember = "Name";
                if (cmbGroup.Items.Count > 0)
                    cmbGroup.SelectedIndex = 0;
            }
        }

        private void UsersForm_Shown(object sender, EventArgs e)
        {
            RefreshUsersList();
        }

        private void RefreshUsersList()
        {
            using (SkyRegContext model = new SkyRegContext())
            {
                int selectedGroupId = default(int);
                int.TryParse(cmbGroup.SelectedValue.ToString(), out selectedGroupId);

                //var users = model.User.AsNoTracking().OrderBy(p => p.SurName).ThenBy(p => p.FirstName).ToList();
                //grdUsers.DataSource = users;

                grdUsers.DataSource = model.User
                    .Include("Group")
                    .AsNoTracking()
                    .Where(p => p.Group.Id == selectedGroupId)
                    .OrderBy(p => p.Name)
                    .ToList();
            }

            UsersSetListView();
        }

        private void UsersSetListView()
        {
            grdUsers.Columns["Id"].Visible = false;
            grdUsers.Columns["Login"].Visible = false;
            grdUsers.Columns["Password"].Visible = false;
            grdUsers.Columns["Certificate"].Visible = false;
            grdUsers.Columns["ZipCode"].Visible = false;
            grdUsers.Columns["Street"].Visible = false;
            grdUsers.Columns["StreetNr"].Visible = false;
            grdUsers.Columns["Phone"].Visible = false;
            grdUsers.Columns["Email"].Visible = false;
            grdUsers.Columns["FaceBook"].Visible = false;
          
            grdUsers.Columns["UsersType"].Visible = false;
            grdUsers.Columns["Operator"].Visible = false;
            grdUsers.Columns["Parachute"].Visible = false;
            grdUsers.Columns["FlightsElem"].Visible = false;
            grdUsers.Columns["Order"].Visible = false;
            grdUsers.Columns["Group"].Visible = false;

          
            grdUsers.Columns["City"].DisplayIndex = 2;
            grdUsers.Columns["CertDate"].DisplayIndex = 3;

   
            grdUsers.Columns["City"].Width = 200;
            grdUsers.Columns["CertDate"].Width = 200;

      
            grdUsers.Columns["City"].HeaderText = "Miasto";
            grdUsers.Columns["CertDate"].HeaderText = "Data wygaśnięcia licencji";


            grdUsers.ReadOnly = true;
            grdUsers.MultiSelect = true;
            grdUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdUsers.AllowUserToResizeRows = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshUsersList();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UsersAddEditForm = FormsOpened<UsersAddEditForm>.IsShowDialog(UsersAddEditForm);
            UsersAddEditForm.FormClosed += UsersAddEditForm_FormClosed;
            UsersAddEditForm.TopMost = true;
            UsersAddEditForm.FormState = FormState.Add;
            UsersAddEditForm.IdUser = default(int);
            UsersAddEditForm.UserGroup = (int)cmbGroup.SelectedValue;
            UsersAddEditForm.ShowDialog();
        }

        private void UsersAddEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshUsersList();
            UsersAddEditForm = null;
        }

        private void RefreshListAfterAddEdit(object sender, EventArgs e)
        {
            RefreshUsersList();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (grdUsers.SelectedRows.Count > 0)
            {
                int idUsr = (int)grdUsers.SelectedRows[0].Cells["Id"].Value;

                UsersAddEditForm = FormsOpened<UsersAddEditForm>.IsShowDialog(UsersAddEditForm);
                 UsersAddEditForm.FormClosed += UsersAddEditForm_FormClosed;
                UsersAddEditForm.FormState = FormState.Edit;
                UsersAddEditForm.IdUser = idUsr;
                UsersAddEditForm.UserGroup = (int)cmbGroup.SelectedValue;
                UsersAddEditForm.ShowDialog();
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }

        private void DeleteUser()
        {
            if (grdUsers.SelectedRows.Count > 0)
            {
                if (KryptonMessageBox.Show("Usunąć zaznaczoną pozycję?", "Usunąć?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int idUsr = (int)grdUsers.SelectedRows[0].Cells["Id"].Value;
                    using(SkyRegContext model = new SkyRegContext())
                    {
                        User usr = model.User.Include("UsersType").Where(p => p.Id == idUsr).FirstOrDefault();
                        if (usr != null)
                        {
                            model.User.Remove(usr);
                            model.SaveChanges();
                            RefreshUsersList();
                        }
                    }

                }
            }
        }
    }
}
