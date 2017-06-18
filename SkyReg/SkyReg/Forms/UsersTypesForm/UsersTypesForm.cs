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
using SkyReg.Common.Extensions;
using DataLayer.Entities.DBContext;

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
            RefreshUsersTypesList();
            SetUsrTypesListView();
        }

        //private void ParentFormSizeFromParentsWorkSpaceSize()
        //{
        //    Size s = new Size();
        //    s.Height = this.Parent.Size.Height - 10;
        //    s.Width = this.Parent.Size.Width - 10;
        //    this.Size = s;
        //    this.StartPosition = FormStartPosition.Manual;
        //}

        private void UsersTypesForm_Shown(object sender, EventArgs e)
        {

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
            using (var model = new SkyRegContextRepository<DefinedUserType>())
            {
                var usrTypes = model.GetAll().Value?
                    .Select(p => new
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Value = p.Value,
                        Camera = p.IsCam ? "Tak" : "Nie"
                    })
                    .OrderBy(p => p.Name)
                    .ToList();
                if (usrTypes.Count > 0)
                {
                    grdUsersTypes.DataSource = usrTypes;
                    SetUsrTypesListView();
                }
                    
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            userTypeAddEdit = FormsOpened<UserTypeAddEdit>.IsShowDialog(userTypeAddEdit);
            userTypeAddEdit._formState = FormState.Add;
            userTypeAddEdit._idUserType = 0;
            userTypeAddEdit.FormClosed += UserTypeAddEdit_FormClosed;
            userTypeAddEdit.StartPosition = FormStartPosition.CenterParent;
            if (userTypeAddEdit.ShowDialog() == DialogResult.OK)
            {
                RefreshUsersTypesList();
                SetUsrTypesListView();
                grdUsersTypes.Refresh();
            }
        }

        private void UserTypeAddEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            userTypeAddEdit = null;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grdUsersTypes.SelectedRows.Count > 0)
            {
                int usrTypeId = (int)grdUsersTypes.SelectedRows[0].Cells["Id"].Value;
                userTypeAddEdit = FormsOpened<UserTypeAddEdit>.IsShowDialog(userTypeAddEdit);
                userTypeAddEdit._formState = FormState.Edit;
                userTypeAddEdit._idUserType = usrTypeId;
                userTypeAddEdit.FormClosed += UserTypeAddEdit_FormClosed;
                if (userTypeAddEdit.ShowDialog() == DialogResult.OK)
                {
                    RefreshUsersTypesList();
                    SetUsrTypesListView();
                    grdUsersTypes.Refresh();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grdUsersTypes.SelectedRows.Count > 0)
            {
                int usrTypeId = (int)grdUsersTypes.SelectedRows[0].Cells["Id"].Value;
                using (SkyRegContext model = new SkyRegContext())
                {
                    if (KryptonMessageBox.Show("Usunąć zaznaczoną pozycję?", "Usunąć?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DefinedUserType usrType = model.DefinedUserType.Where(p => p.Id == usrTypeId).FirstOrDefault();
                        if (usrType != null)
                        {
                            model.DefinedUserType.Remove(usrType);
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
