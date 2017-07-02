using ComponentFactory.Krypton.Toolkit;
using DataLayer;
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

namespace SkyReg.Forms.SupervisorsForm
{
    public partial class FrmSupervisors : KryptonForm
    {
        public int SupervisorId { get; set; } = 0;
        public FrmSupervisors()
        {
            InitializeComponent();
        }

        private void FrmSupervisors_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            grdSupervisor.DataSource = null;

            using (var _ctx = new SkyRegContextRepository<Supervisors>())
            {
                var result = _ctx.GetAll();
                if (result.IsSuccess)
                {
                    grdSupervisor.DataSource = result.Value.ToList();
                    MapColumns();
                    ColorGrid();
                }
            }
        }

        private void MapColumns()
        {
            grdSupervisor.Columns["Id"].Visible = false;


            grdSupervisor.Columns["UserName"].HeaderText = "Nazwisko i imię";
            grdSupervisor.Columns["CertificateNr"].HeaderText = "Nr świadecta";
            grdSupervisor.Columns["CertificateExpirateDate"].HeaderText = "Termin ważności świadectwa";
            grdSupervisor.Columns["SurveyNr"].HeaderText = "Nr badania";
            grdSupervisor.Columns["SurveyExpirateDate"].HeaderText = "Termin ważności badania";
            grdSupervisor.Columns["IsUpToDate"].HeaderText = "Aktualny";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddSupervisor_Click(object sender, EventArgs e)
        {
            SupervisorId = 0;
            AddEditFrom();
        }

        private void AddEditFrom()
        {
            _supervisorAddEdit = FormsOpened<SupervisorAddEdit>.IsShowDialog(_supervisorAddEdit);
            _supervisorAddEdit.Supervisor_Id = SupervisorId;
            _supervisorAddEdit.FormClosed += _supervisorAddEdit_FormClosed;
            _supervisorAddEdit.ShowDialog();

        }

        private void _supervisorAddEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData();
            _supervisorAddEdit = null;
        }

        private SupervisorAddEdit _supervisorAddEdit = null;

        private void btnEditSupervisor_Click(object sender, EventArgs e)
        {
            EditForm();
        }

        private void EditForm()
        {
            if (grdSupervisor.SelectedRows.Count > 0)
            {
                SupervisorId = (int)grdSupervisor.SelectedRows[0].Cells["Id"].Value;
                AddEditFrom();
            }
        }

        private void grdSupervisor_DoubleClick(object sender, EventArgs e)
        {
            EditForm();
        }

        private void btnDeleteSupervisor_Click(object sender, EventArgs e)
        {
            if (grdSupervisor.SelectedRows.Count > 0)
            {
                SupervisorId = (int)grdSupervisor.SelectedRows[0].Cells["Id"].Value;
                var dr = KryptonMessageBox.Show("Czy na pewno chcesz usunąć ?", "Uwaga", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (dr == DialogResult.Yes)
                {
                    if (SupervisorId > 0)
                        using (var _ctx = new SkyRegContextRepository<Supervisors>())
                        {
                            var data = new Supervisors();
                            data = _ctx.GetById(SupervisorId);
                            _ctx.Delete(data);
                        }

                    LoadData();
                }
            }
        }

        private void ColorGrid()
        {
            if (grdSupervisor.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in grdSupervisor.Rows)
                {
                    item.DefaultCellStyle.BackColor = (bool)item.Cells["IsUpToDate"].Value ? Color.Empty : Color.Red;
                }
            }
        }

        private void FrmSupervisors_Shown(object sender, EventArgs e)
        {
            ColorGrid();
        }
    }
}

