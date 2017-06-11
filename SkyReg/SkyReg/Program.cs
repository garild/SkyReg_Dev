using Msg = AC.ExtendedRenderer.Toolkit.KryptonMessageBox;
using SkyReg.MainForm;
using SkyReg.Utils;
using System;
using System.Windows.Forms;
using SkyReg.Common.Extensions;
using SkyReg.Forms.SplashScreen;

namespace SkyReg
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static bool hasRestart = false;
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            if (CommonMethods.isNetworkWorking())
            {
                //    if (System.Diagnostics.Process.GetProcessesByName("EMnet").Length > 1 && hasRestart)
                //    {
                //        KryptonMessageBox.Show("Aplikacja została już wcześniej uruchomiona !", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        return;
                //    }
                _splashScreen = FormsOpened<SplashScreen>.IsShowDialog(_splashScreen);
                if (_splashScreen.ShowDialog() == DialogResult.OK)
                {
                    FrmLogin frm = new FrmLogin();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        frm.Close();
                        _frmMain = FormsOpened<FrmMain>.IsOpened(_frmMain);
                        Application.Run(_frmMain);

                    }
                    else
                        Application.Exit();
                }
                
            }
            else
                Msg.Show("Brak połaczenia z internetem", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static FrmMain _frmMain = null;
        public static SplashScreen _splashScreen = null;
    }
}
