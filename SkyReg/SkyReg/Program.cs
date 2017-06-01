using Msg = AC.ExtendedRenderer.Toolkit.KryptonMessageBox;
using SkyReg.MainForm;
using SkyReg.Utils;
using System;
using System.Windows.Forms;

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

               // AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                Application.ApplicationExit += Application_ApplicationExit;
                FirstTimeRun.CheckAndAdd();
                FrmLogin frm = new FrmLogin();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    frm.Close();
                    Application.Run(new FrmMain());
                    
                }
                else
                    Application.Exit();
            }
            else
                Msg.Show("Brak połaczenia z internetem", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (hasRestart)
                Application.Restart();
            else
                Application.ExitThread();
        }

        //private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        //{
        //    //ExceptionLogger.UnhandledException(e, "Program - Main()");
        //    Msg.Show("Wystąpił błąd - zresetuj połączenie sieciowe i spróbuj ponownie uruchomić program", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    return;
        //}
    }
}
