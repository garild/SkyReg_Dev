using ComponentFactory.Krypton.Toolkit;
using DataLayer.Models;
using DataLayer.Result.Repository;
using SkyReg.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyReg.Forms
{
    public partial class ReportedUsersList : KryptonForm
    {
        public int userID { get; set; } = 0;

        public ReportedUsersList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            userID = 0;
            AddEditUser();

        }

        private void AddEditUser()
        {
            _reportUserAddEdit = FormsOpened<ReportedUserAddEdit>.IsShowDialog(_reportUserAddEdit);
            _reportUserAddEdit.UserId = userID;
            if (_reportUserAddEdit.ShowDialog() == DialogResult.OK)
                RefreshDataList();
        }

        private void RefreshDataList()
        {
            grdReportedUsers.DataSource = null;
            using (var _ctx = new SkyRegContextRepository<ReportedUsers>())
            {
                var userList = _ctx.Table.OrderByDescending(p => p.Id).Select(p => new
                {
                    Name = p.UserName,
                    ReportedByUser = p.ReportByUser,
                    CreateDate = p.CreateDate,
                    Id = p.Id
                }).ToList();
                if (userList?.Count >0 )
                {
                    grdReportedUsers.DataSource = userList;
                    MapCollumns();
                }
            }
        }

        private void MapCollumns()
        {
            if(grdReportedUsers.Columns.Count > 0)
            {
                grdReportedUsers.Columns["Id"].Visible = false;

                grdReportedUsers.Columns["Name"].HeaderText = "Osoba Oczekująca";
                grdReportedUsers.Columns["ReportedByUser"].HeaderText = "Zgłoszony przez";
                grdReportedUsers.Columns["CreateDate"].HeaderText = "Data Zgłoszenia";
                grdReportedUsers.Columns["Name"].Width = 200;
                grdReportedUsers.Columns["ReportedByUser"].Width = 200;
                grdReportedUsers.Columns["CreateDate"].Width = 120;
            }
        }

        private ReportedUserAddEdit _reportUserAddEdit = null;

        private void ReportedUsersList_Load(object sender, EventArgs e)
        {
            RefreshDataList();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            EditUser();

        }

        private void EditUser()
        {
            if (grdReportedUsers.SelectedRows?.Count > 0)
            {
                userID = (int)grdReportedUsers.SelectedRows[0].Cells["Id"]?.Value;
                if (userID > 0)
                    AddEditUser();
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (grdReportedUsers.SelectedRows?.Count > 0)
            {
                userID = (int)grdReportedUsers.SelectedRows[0].Cells["Id"]?.Value;
                if (userID > 0)
                {
                   var dr = KryptonMessageBox.Show("Czy na pewno chcesz usunąć ?", "Uwaga", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if(dr == DialogResult.Yes)
                    {
                        using (var _ctx = new SkyRegContextRepository<ReportedUsers>())
                        {
                            _ctx.Delete(_ctx.GetById(userID));
                        }
                        RefreshDataList();
                    }
                }
            }
        }

        private void grdReportedUsers_DoubleClick(object sender, EventArgs e)
        {
            EditUser();
        }
    }
}
