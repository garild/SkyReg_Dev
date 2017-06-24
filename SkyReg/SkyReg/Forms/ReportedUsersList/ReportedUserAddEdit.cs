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
    public partial class ReportedUserAddEdit : KryptonForm
    {
        public int UserId { get; set; }

        public ReportedUserAddEdit()
        {
            InitializeComponent();
        }

        private void AddNewUser()
        {
            var userList = new List<ReportedUsers>();
            if (ValidateData())
            {
                numAmount.Enabled = true;

                string userName = txtUserName.Text.Trim();

                for (int i = 0; i < numAmount.Value; i++)
                {
                    var user = new ReportedUsers();
                    user.ReportByUser = txtReportedByUser.Text.Trim();
                    user.UserName = i > 0 ? $"{userName}{i}" : userName;
                    user.CreateDate = DateTime.Now;
                    userList.Add(user);
                }

                using (var _ctx = new SkyRegContextRepository<ReportedUsers>())
                {
                    var userExists = _ctx.GetAll();
                    if (userExists.IsSuccess && userExists.Value?.Where(p => p.UserName.ToLower() == txtUserName.Text.Trim().ToLower()).Select(p=>p.Id).FirstOrDefault() >  0)
                    {
                        KryptonMessageBox.Show("Wpisana nazwa już istnieje na liście osób oczekujących!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    _ctx.InsertMany(userList);
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void EditUser()
        {
            using (var _ctx = new SkyRegContextRepository<ReportedUsers>())
            {
                var userEdit = _ctx.GetById(UserId);
                userEdit.ReportByUser = txtReportedByUser.Text.Trim();
                userEdit.UserName = txtUserName.Text.Trim();

                _ctx.Update(userEdit);
            }
        }

        private bool ValidateData()
        {
            errorProvider1.Clear();
         
            if(!txtUserName.Text.HasValue())
            {
                errorProvider1.SetError(txtUserName, "Wpisz nazwę!");
                return false;
            }
            if (!txtReportedByUser.Text.HasValue())
            {
                errorProvider1.SetError(txtUserName, "Wpisz imię i nazwisko osoby zagłaszającej!");
                return false;
            }

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReportedUserAddEdit_Shown(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void ReportedUserAddEdit_Load(object sender, EventArgs e)
        {
            numAmount.Enabled = true;
            txtReportedByUser.Clear();
            txtUserName.Clear();
            if (UserId > 0)
            {
                numAmount.Enabled = false;
                using (var _ctx = new SkyRegContextRepository<ReportedUsers>())
                {
                    var userEdit = _ctx.GetById(UserId);
                    txtReportedByUser.Text = userEdit.ReportByUser;
                    txtUserName.Text = userEdit.UserName;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (UserId > 0)
                EditUser();
            else
                AddNewUser();
        }
    }
}
