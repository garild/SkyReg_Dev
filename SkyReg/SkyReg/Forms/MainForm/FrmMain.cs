using ComponentFactory.Krypton.Toolkit;
using DataLayer;
using SkyReg.Common.Extensions;
using SkyReg.Forms;
using SkyReg.Forms.SplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SkyReg
{
    public partial class FrmMain : KryptonForm
    {
        public FrmMain()
        {
            InitializeComponent();
            LoadStatusBarSettings();
        }

        private void LoadStatusBarSettings()
        {
            tstrVersion.Text = String.Format("{0}  ", SkyRegUser.AppVer);
            tstrComputerName.Text = SkyRegUser.LocalMachineName;
            tstrLoggedUser.Text = SkyRegUser.UserLogin;


        }

        private void outlookBar1_ButtonClicked(object sender, EventArgs e)
        {
            switch (outlookBar.Buttons[outlookBar.SelectedIndex].BuddyPage1)
            {
                case "Settings":
                    FrmGlobalSettings = FormsOpened<FrmGlobalSettings>.IsOpened(FrmGlobalSettings);
                    FrmGlobalSettings.MdiParent = this;
                    FrmGlobalSettings.WindowState = FormWindowState.Maximized;
                    FrmGlobalSettings.FormClosed += FrmGlobalSettings_FormClosed;
                    FrmGlobalSettings.Show();
                    FrmGlobalSettings.BringToFront();
                    FrmGlobalSettings.Activate();
                    break;
                case "Airplanes":
                    AirplanesForm = FormsOpened<AirplanesForm>.IsOpened(AirplanesForm);
                    AirplanesForm.MdiParent = this;
                    AirplanesForm.WindowState = FormWindowState.Maximized;
                    AirplanesForm.FormClosed += AirplanesForm_FormClosed;
                    AirplanesForm.BringToFront();
                    AirplanesForm.TopLevel = false;
                    AirplanesForm.Show();
                    AirplanesForm.Activate();
                    break;
                case "Parachutes":
                    ParachutesForm = FormsOpened<ParachutesForm>.IsOpened(ParachutesForm);
                    ParachutesForm.MdiParent = this;
                    ParachutesForm.WindowState = FormWindowState.Maximized;
                    ParachutesForm.FormClosed += ParachutesForm_FormClosed;
                    ParachutesForm.BringToFront();
                    ParachutesForm.TopLevel = false;
                    ParachutesForm.Show();
                    ParachutesForm.Activate();
                    break;
                case "Jumpers_types":
                    UsersTypesForm = FormsOpened<UsersTypesForm>.IsOpened(UsersTypesForm);
                    UsersTypesForm.MdiParent = this;
                    UsersTypesForm.WindowState = FormWindowState.Maximized;
                    UsersTypesForm.FormClosed += UsersTypesForm_FormClosed;
                    UsersTypesForm.BringToFront();
                    UsersTypesForm.TopLevel = false;
                    UsersTypesForm.Show();
                    UsersTypesForm.Activate();
                    break;
                case "Jumpers":
                    UsersForm = FormsOpened<UsersForm>.IsOpened(UsersForm);
                    UsersForm.MdiParent = this;
                    UsersForm.WindowState = FormWindowState.Maximized;
                    UsersForm.FormClosed += UsersForm_FormClosed;
                    UsersForm.BringToFront();
                    UsersForm.TopLevel = false;
                    UsersForm.Show();
                    UsersForm.Activate();
                    break;
                case "Flights":
                    FlightsForm = FormsOpened<FlightsForm>.IsOpened(FlightsForm);
                    FlightsForm.MdiParent = this;
                    FlightsForm.WindowState = FormWindowState.Maximized;
                    FlightsForm.FormClosed += FlightsForm_FormClosed;
                    FlightsForm.BringToFront();
                    FlightsForm.TopLevel = false;
                    FlightsForm.Show();
                    FlightsForm.Activate();
                    break;
                case "Planer":
                    ScheduleForm = FormsOpened<ScheduleForm>.IsOpened(ScheduleForm);
                    ScheduleForm.MdiParent = this;
                    ScheduleForm.WindowState = FormWindowState.Maximized;
                    ScheduleForm.FormClosed += ScheduleForm_FormClosed;
                    ScheduleForm.BringToFront();
                    ScheduleForm.TopLevel = false;
                    ScheduleForm.Show();
                    ScheduleForm.Activate();
                    break;
                case "Moneys":
                    PaymentsForm = FormsOpened<PaymentsForm>.IsOpened(PaymentsForm);
                    PaymentsForm.MdiParent = this;
                    PaymentsForm.WindowState = FormWindowState.Maximized;
                    PaymentsForm.FormClosed += PaymentsForm_FormClosed;
                    PaymentsForm.BringToFront();
                    PaymentsForm.TopLevel = false;
                    PaymentsForm.Show();
                    PaymentsForm.Activate();
                    break;
                case "PassangerList":
                    PassangerList = new PassangerList();
                    PassangerList.WindowState = FormWindowState.Maximized;
                    PassangerList.BringToFront();
                    PassangerList.Show();
                    PassangerList.Activate();
                    break;
                case "ReportedUsers":
                    ReportedUsersList = FormsOpened<ReportedUsersList>.IsOpened(ReportedUsersList);
                    ReportedUsersList.MdiParent = this;
                    ReportedUsersList.WindowState = FormWindowState.Maximized;
                    ReportedUsersList.FormClosed += ReportedUsersList_FormClosed;
                    ReportedUsersList.BringToFront();
                    ReportedUsersList.TopLevel = false;
                    ReportedUsersList.Show();
                    ReportedUsersList.Activate();
                    break;
            }
        }

        private void PaymentsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            PaymentsForm = null;
        }

        private void ScheduleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ScheduleForm = null;

        }

        private void FlightsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FlightsForm = null;
        }

        private void FrmGlobalSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmGlobalSettings = null;
        }

        private void AirplanesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AirplanesForm = null;
        }

        private void ParachutesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ParachutesForm = null;
        }

        private void UsersTypesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            UsersTypesForm = null;
        }

        private void UsersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            UsersForm = null;
        }
        private void ReportedUsersList_FormClosed(object sender, FormClosedEventArgs e)
        {
            ReportedUsersList = null;
        }


        #region Forms

        private UsersForm UsersForm = null;
        private FrmGlobalSettings FrmGlobalSettings = null;
        private UsersTypesForm UsersTypesForm = null;
        private ParachutesForm ParachutesForm = null;
        private AirplanesForm AirplanesForm = null;
        private FlightsForm FlightsForm = null;
        private ScheduleForm ScheduleForm = null;
        private PaymentsForm PaymentsForm = null;
        private PassangerList PassangerList = null;
        private ReportedUsersList ReportedUsersList = null;


        #endregion

        private void tsmSettings_Click(object sender, EventArgs e)
        {
            _panel = FormsOpened<PanelSettings>.IsOpened(_panel);
            if(_panel.ShowDialog() == DialogResult.OK)
            {
                if (Application.OpenForms["PassangerList"] != null)
                {
                    (Application.OpenForms["PassangerList"] as PassangerList).GenerateDynamicControls();
                }
            }
        }
        PanelSettings _panel = null;

        private void dodajKluczToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicenceAddKeyForm lakf = new LicenceAddKeyForm();
            lakf.ShowDialog();
        }

        private void informacjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicenceInfoForm lif = new LicenceInfoForm();
            lif.ShowDialog();
        }
    } }
