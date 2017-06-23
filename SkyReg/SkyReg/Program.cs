using Msg = AC.ExtendedRenderer.Toolkit.KryptonMessageBox;
using SkyReg.MainForm;
using SkyReg.Utils;
using System;
using System.Windows.Forms;
using SkyReg.Common.Extensions;
using SkyReg.Forms.SplashScreen;
using SkyReg.Properties;

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
            //var expDate = Settings.Default.Properties["ExpDate"].DefaultValue.ToString();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            //try
            //{
            //if (DateTime.Now < Convert.ToDateTime(expDate))
            //{
            _splashScreen = FormsOpened<SplashScreen>.IsOpened(_splashScreen);
            _splashScreen.WindowState = FormWindowState.Normal;
            _splashScreen.StartPosition = FormStartPosition.CenterScreen;

            if (_splashScreen.ShowDialog() == DialogResult.OK)
            {

                if (Licence() == true)
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
                else
                {
                    MessageBox.Show("Brak licencji.\nProszę wprowadzić klucz\n lub kontakt z nr tel. 502-333-661", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    LicenceAddKeyForm lakf = new LicenceAddKeyForm();
                    lakf.ShowDialog();
                }
            }

            //}
            //else
            //    Msg.Show("Termin wersji demo SkyReg upłynął", "Informacja!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
            //catch (Exception ex)
            //{
            //    _splashScreen.Close();
            //    Msg.Show("Wystąpił błąd, treść : " + ex.Message, "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //    Application.Exit();
            //}

        }

        private static bool Licence()
        {
            bool result = false;
            if (Settings.Default.LicenceKey == "0okm)OKM" && DateTime.Now.Date <= DateTime.Parse("2017-07-31"))
                result = true;
            if (Settings.Default.LicenceKey == "ZAQ12wsx")
                result = true;

            return result;
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
