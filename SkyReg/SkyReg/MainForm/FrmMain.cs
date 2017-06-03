using ComponentFactory.Krypton.Toolkit;
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
            Form openForm;
            switch( outlookBar1.Buttons[outlookBar1.SelectedIndex].BuddyPage1)
            {
                case "Settings":
                    openForm = null;
                    foreach(Form item in Application.OpenForms)
                    {
                        if (item.GetType() == typeof(FrmGlobalSettings))
                        {
                            openForm = item;
                            openForm.Activate();
                        }
                    }
                    if (openForm == null)
                    {
                        FrmGlobalSettings fgs = new FrmGlobalSettings();
                        fgs.MdiParent = this;
                        fgs.ControlBox = true;
                        Size s = new Size();
                        s.Height = fgs.Parent.Size.Height - 10;
                        s.Width = fgs.Parent.Size.Width - 10;
                        fgs.Size = s;
                        fgs.StartPosition = FormStartPosition.Manual;
                        fgs.Location = new Point(0, 0);
                        fgs.Show();
                    }
                    else
                    {
                        openForm.WindowState = FormWindowState.Normal;
                    }
                    break;
                case "Airplanes":
                    openForm = null;
                    foreach(Form item in Application.OpenForms)
                    {
                        if (item.GetType() == typeof(AirplanesForm))
                        {
                            openForm = item;
                            openForm.Activate();
                        }
                    }
                    if(openForm == null)
                    {
                        AirplanesForm af = new AirplanesForm();
                        af.MdiParent = this;
                        af.ControlBox = true;
                        Size s = new Size();
                        s.Height = af.Parent.Size.Height - 10;
                        s.Width = af.Parent.Size.Width - 10;
                        af.Size = s;
                        af.StartPosition = FormStartPosition.Manual;
                        af.Location = new Point(0, 0);
                        af.Show();
                    }
                    else
                    {
                        openForm.WindowState = FormWindowState.Normal;
                    }
                    break;
                case "Parachutes":
                    openForm = null;
                    foreach (Form item in Application.OpenForms)
                    {
                        if (item.GetType() == typeof(ParachutesForm))
                        {
                            openForm = item;
                            openForm.Activate();
                        }
                    }
                    if (openForm == null)
                    {
                        ParachutesForm af = new ParachutesForm();
                        af.MdiParent = this;
                        af.ControlBox = true;
                        Size s = new Size();
                        s.Height = af.Parent.Size.Height - 10;
                        s.Width = af.Parent.Size.Width - 10;
                        af.Size = s;
                        af.StartPosition = FormStartPosition.Manual;
                        af.Location = new Point(0, 0);
                        af.Show();
                    }
                    else
                    {
                        openForm.WindowState = FormWindowState.Normal;
                    }
                    break;
                case "Jumpers_types":
                    openForm = null;
                    foreach (Form item in Application.OpenForms)
                    {
                        if (item.GetType() == typeof(UsersTypesForm))
                        {
                            openForm = item;
                            openForm.Activate();
                        }
                    }
                    if (openForm == null)
                    {
                        UsersTypesForm af = new UsersTypesForm();
                        af.MdiParent = this;
                        af.ControlBox = true;
                        Size s = new Size();
                        s.Height = af.Parent.Size.Height - 10;
                        s.Width = af.Parent.Size.Width - 10;
                        af.Size = s;
                        af.StartPosition = FormStartPosition.Manual;
                        af.Location = new Point(0, 0);
                        af.Show();
                    }
                    else
                    {
                        openForm.WindowState = FormWindowState.Normal;
                    }
                    break;
                case "Jumpers":
                    openForm = null;
                    foreach (Form item in Application.OpenForms)
                    {
                        if (item.GetType() == typeof(UsersForm))
                        {
                            openForm = item;
                            openForm.Activate();
                        }
                    }
                    if (openForm == null)
                    {
                        UsersForm af = new UsersForm();
                        af.MdiParent = this;
                        af.ControlBox = true;

                        Size s = new Size();
                        s.Height = af.Parent.Size.Height - 10;
                        s.Width = af.Parent.Size.Width - 10;
                        af.Size = s;
                        af.StartPosition = FormStartPosition.Manual;
                        af.Location = new Point(0, 0);
                        af.Show();
                        
                    }
                    else
                    {
                        openForm.WindowState = FormWindowState.Normal;
                    }
                    break;


            }
        }
    }
}
