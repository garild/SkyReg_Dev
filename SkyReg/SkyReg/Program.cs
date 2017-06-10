using Msg = AC.ExtendedRenderer.Toolkit.KryptonMessageBox;
using SkyReg.MainForm;
using SkyReg.Utils;
using System;
using System.Windows.Forms;
using SkyReg.Common.Extensions;

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
              
                FrmLogin frm = new FrmLogin();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    frm.Close();
                    FrmMain = FormsOpened<FrmMain>.IsOpened(FrmMain);
                    Application.Run(FrmMain);
                    
                }
                else
                    Application.Exit();
            }
            else
                Msg.Show("Brak połaczenia z internetem", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static FrmMain FrmMain = null;
    }
}
