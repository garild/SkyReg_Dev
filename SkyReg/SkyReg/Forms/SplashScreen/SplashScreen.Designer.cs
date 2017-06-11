namespace SkyReg.Forms.SplashScreen
{
    partial class SplashScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.progressBar = new MetroFramework.Controls.MetroProgressBar();
            this.labAppVersion = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = null;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // progressBar
            // 
            this.progressBar.FontWeight = MetroFramework.MetroProgressBarWeight.Bold;
            this.progressBar.HideProgressText = false;
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            this.progressBar.ProgressBarStyle = System.Windows.Forms.ProgressBarStyle.Blocks;
            this.progressBar.Step = 25;
            this.progressBar.Style = MetroFramework.MetroColorStyle.Green;
            this.progressBar.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // labAppVersion
            // 
            this.labAppVersion.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            resources.ApplyResources(this.labAppVersion, "labAppVersion");
            this.labAppVersion.Name = "labAppVersion";
            this.labAppVersion.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver;
            this.labAppVersion.StateCommon.LongText.Color1 = System.Drawing.Color.White;
            this.labAppVersion.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.labAppVersion.StateNormal.ShortText.Color1 = System.Drawing.Color.White;
            this.labAppVersion.Values.Text = resources.GetString("labAppVersion.Values.Text");
            // 
            // SplashScreen
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.labAppVersion);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Custom2;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SplashScreen";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroProgressBar progressBar;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labAppVersion;
    }
}