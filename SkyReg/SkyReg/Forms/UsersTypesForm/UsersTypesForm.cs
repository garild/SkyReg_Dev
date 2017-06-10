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

namespace SkyReg
{
    public partial class UsersTypesForm : KryptonForm
    {
        public UsersTypesForm()
        {
            InitializeComponent();
        }

        private void UsersTypesForm_Load(object sender, EventArgs e)
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

        private void UsersTypesForm_Shown(object sender, EventArgs e)
        {
            RefreshUsersTypesList();
            SetUsrTypesListView();
        }

        private void SetUsrTypesListView()
        {
            grdUsersTypes.Columns["Id"].Visible = false;
            grdUsersTypes.Columns["Name"].Visible = true;
            grdUsersTypes.Columns["Value"].Visible = true;
            grdUsersTypes.Columns["Camera"].Visible = true;

            grdUsersTypes.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grdUsersTypes.Columns["Value"].Width = 200;
            grdUsersTypes.Columns["Camera"].Width = 200;

            grdUsersTypes.Columns["Name"].HeaderText = "Nazwa typu skoczka";
            grdUsersTypes.Columns["Value"].HeaderText = "Koszt skoku";
            grdUsersTypes.Columns["Camera"].HeaderText = "Czy używa kamery";

            grdUsersTypes.Columns["Value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grdUsersTypes.ReadOnly = true;
            grdUsersTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdUsersTypes.AllowUserToResizeRows = false;

        }

        private void RefreshUsersTypesList()
        {
            grdUsersTypes.DataSource = null;
            using (var model = new DLModelRepository<UsersType>())
            {
                var usrTypes = model.GetAll().Value?
                    .Select(p => new UserTypeListElem
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Value = p.Value,
                        Camera = p.IsCam ? "Tak": "Nie"
                    })
                    .OrderBy(p => p.Name)
                    .ToList();
                if(usrTypes.Count > 0)

                grdUsersTypes.DataSource = usrTypes;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            userTypeAddEdit = new UserTypeAddEdit(FormState.Add, null);
            userTypeAddEdit.FormClosed += UserTypeAddEdit_FormClosed;
            userTypeAddEdit.ShowDialog();
        }

        private void UserTypeAddEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(userTypeAddEdit.DialogResult == DialogResult.OK)
            {
                RefreshUsersTypesList();
                SetUsrTypesListView();
                grdUsersTypes.Refresh();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grdUsersTypes.SelectedRows.Count > 0)
            {
                int usrTypeId = (int)grdUsersTypes.SelectedRows[0].Cells["Id"].Value;
                userTypeAddEdit = new UserTypeAddEdit(FormState.Edit, usrTypeId);
                userTypeAddEdit.FormClosed += UserTypeAddEdit_FormClosed;
                userTypeAddEdit.Show();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grdUsersTypes.SelectedRows.Count > 0)
            {
                int usrTypeId = (int)grdUsersTypes.SelectedRows[0].Cells["Id"].Value;
                using (DLModelContainer model = new DLModelContainer())
                {
                    if (KryptonMessageBox.Show("Usunąć zaznaczoną pozycję?", "Usunąć?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        UsersType usrType = model.UsersType.Where(p => p.Id == usrTypeId).FirstOrDefault();
                        if (usrType != null)
                        {
                            model.UsersType.Remove(usrType);
                            model.SaveChanges();
                            RefreshUsersTypesList();
                        }
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private UserTypeAddEdit userTypeAddEdit = null;
    }
}
