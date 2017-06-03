using ComponentFactory.Krypton.Toolkit;
using SkyReg.Common.Extensions;
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
        }

        private void outlookBar1_ButtonClicked(object sender, EventArgs e)
        {
            switch (outlookBar1.Buttons[outlookBar1.SelectedIndex].BuddyPage1)
            {
                case "Settings":
                    if (FrmGlobalSettings == null)
                    {
                        FrmGlobalSettings = FormsOpened<FrmGlobalSettings>.IsOpened(FrmGlobalSettings);
                        FrmGlobalSettings.MdiParent = this;
                        FrmGlobalSettings.WindowState = FormWindowState.Maximized;
                        FrmGlobalSettings.FormClosed += FrmGlobalSettings_FormClosed;
                        FrmGlobalSettings.BringToFront();
                        FrmGlobalSettings.TopLevel = false;
                        FrmGlobalSettings.Show();
                        FrmGlobalSettings.Activate();
                    }
                    break;
                case "Airplanes":
                    if (AirplanesForm == null)
                    {
                        AirplanesForm = FormsOpened<AirplanesForm>.IsOpened(AirplanesForm);
                        AirplanesForm.MdiParent = this;
                        AirplanesForm.WindowState = FormWindowState.Maximized;
                        AirplanesForm.FormClosed += AirplanesForm_FormClosed;
                        AirplanesForm.BringToFront();
                        AirplanesForm.TopLevel = false;
                        AirplanesForm.Show();
                        AirplanesForm.Activate();

                    }
                    break;
                case "Parachutes":
                    if (ParachutesForm == null)
                    {
                        ParachutesForm = FormsOpened<ParachutesForm>.IsOpened(ParachutesForm);
                        ParachutesForm.MdiParent = this;
                        ParachutesForm.WindowState = FormWindowState.Maximized;
                        ParachutesForm.FormClosed += ParachutesForm_FormClosed;
                        ParachutesForm.BringToFront();
                        ParachutesForm.TopLevel = false;
                        ParachutesForm.Show();
                        ParachutesForm.Activate();
                    }
                    break;
                case "Jumpers_types":
                    if (UsersTypesForm == null)
                    {
                        UsersTypesForm = FormsOpened<UsersTypesForm>.IsOpened(UsersTypesForm);
                        UsersTypesForm.MdiParent = this;
                        UsersTypesForm.WindowState = FormWindowState.Maximized;
                        UsersTypesForm.FormClosed += UsersTypesForm_FormClosed;
                        UsersTypesForm.BringToFront();
                        UsersTypesForm.TopLevel = false;
                        UsersTypesForm.Show();
                        UsersTypesForm.Activate();
                    }
                    break;
                case "Jumpers":
                    if (UsersForm == null)
                    {
                        UsersForm = FormsOpened<UsersForm>.IsOpened(UsersForm);
                        UsersForm.MdiParent = this;
                        UsersForm.WindowState = FormWindowState.Maximized;
                        UsersForm.FormClosed += UsersForm_FormClosed;
                        UsersForm.BringToFront();
                        UsersForm.TopLevel = false;
                        UsersForm.Show();
                        UsersForm.Activate();
                    }
                    break;
            }
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


        #region Forms

        private UsersForm UsersForm = null;
        private FrmGlobalSettings FrmGlobalSettings = null;
        private UsersTypesForm UsersTypesForm = null;
        private ParachutesForm ParachutesForm = null;
        private AirplanesForm AirplanesForm = null;

        #endregion

    }
}
