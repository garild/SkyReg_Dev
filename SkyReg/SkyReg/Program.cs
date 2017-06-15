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
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            //try
            //{
                if (CommonMethods.isNetworkWorking())
                {
                    _splashScreen = FormsOpened<SplashScreen>.IsOpened(_splashScreen);
                    _splashScreen.WindowState = FormWindowState.Normal;
                    _splashScreen.StartPosition = FormStartPosition.CenterScreen;
                    
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
            //}
            //catch (Exception ex)
            //{
            //    _splashScreen.Close();
            //    Msg.Show("Wystąpił błąd, treść : " + ex.Message, "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //    Application.Exit();
            //}
            
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Msg.Show($"Wystąpił błąd w {nameof(Program)}, treść : {(e.ExceptionObject as Exception).Message}", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Application.Exit();
        }

        public static FrmMain _frmMain = null;
        public static SplashScreen _splashScreen = null;
    }
}
