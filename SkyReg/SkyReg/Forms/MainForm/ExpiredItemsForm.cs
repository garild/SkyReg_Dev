using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyReg
{
    public partial class ExpiredItemsForm : KryptonForm
    {
        public List<ExpiredItem> UsersExpiredList { get; set; }
        public List<ExpiredItem> SupervisorsExpiredList { get; set; }

        public ExpiredItemsForm()
        {
            InitializeComponent();
        }

        private void ExpiredItemsForm_Load(object sender, EventArgs e)
        {
            grdUserEx.DataSource = UsersExpiredList;
            grdSupervisorsEx.DataSource = SupervisorsExpiredList;
            SetGridsView();
        }

        private void SetGridsView()
        {
            grdSupervisorsEx.ReadOnly = true;
            grdSupervisorsEx.Columns["InsuranceExpire"].Visible = false;
            grdSupervisorsEx.Columns["CertExpire"].HeaderText = "Świadectwo kwalifikacji";
            grdSupervisorsEx.Columns["SurveyExpire"].HeaderText = "Badania";
            grdSupervisorsEx.Columns["Name"].HeaderText = "Nazwisko i imię";
            grdSupervisorsEx.Columns["CertExpire"].Width = 150;
            grdSupervisorsEx.Columns["SurveyExpire"].Width = 150;
            grdSupervisorsEx.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            grdUserEx.ReadOnly = true;
            grdUserEx.Columns["InsuranceExpire"].HeaderText = "Ubezpieczenie";
            grdUserEx.Columns["CertExpire"].HeaderText = "Świadectwo kwalifikacji";
            grdUserEx.Columns["SurveyExpire"].HeaderText = "Badania";
            grdUserEx.Columns["Name"].HeaderText = "Nazwisko i imię";
            grdUserEx.Columns["InsuranceExpire"].Width = 150;
            grdUserEx.Columns["CertExpire"].Width = 150;
            grdUserEx.Columns["SurveyExpire"].Width = 150;
            grdUserEx.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
    }
}
