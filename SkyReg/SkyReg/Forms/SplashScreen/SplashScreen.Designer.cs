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
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.progressBar = new MetroFramework.Controls.MetroProgressBar();
            this.cbDbExists = new MetroFramework.Controls.MetroCheckBox();
            this.cbLoadSettings = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox2 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox3 = new MetroFramework.Controls.MetroCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = null;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.White;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // progressBar
            // 
            this.progressBar.HideProgressText = false;
            this.progressBar.Location = new System.Drawing.Point(33, 450);
            this.progressBar.Name = "progressBar";
            this.progressBar.ProgressBarStyle = System.Windows.Forms.ProgressBarStyle.Blocks;
            this.progressBar.Size = new System.Drawing.Size(655, 23);
            this.progressBar.Step = 25;
            this.progressBar.Style = MetroFramework.MetroColorStyle.Black;
            this.progressBar.TabIndex = 0;
            // 
            // cbDbExists
            // 
            this.cbDbExists.AutoSize = true;
            this.cbDbExists.Location = new System.Drawing.Point(33, 345);
            this.cbDbExists.Name = "cbDbExists";
            this.cbDbExists.Size = new System.Drawing.Size(266, 15);
            this.cbDbExists.TabIndex = 1;
            this.cbDbExists.Text = "Baza danych SkyReg zainstalowana poprawnie";
            this.cbDbExists.UseVisualStyleBackColor = true;
            // 
            // cbLoadSettings
            // 
            this.cbLoadSettings.AutoSize = true;
            this.cbLoadSettings.Location = new System.Drawing.Point(33, 366);
            this.cbLoadSettings.Name = "cbLoadSettings";
            this.cbLoadSettings.Size = new System.Drawing.Size(215, 15);
            this.cbLoadSettings.TabIndex = 1;
            this.cbLoadSettings.Text = "Ładowanie konfiguracji bazy danych";
            this.cbLoadSettings.UseVisualStyleBackColor = true;
            // 
            // metroCheckBox2
            // 
            this.metroCheckBox2.AutoSize = true;
            this.metroCheckBox2.Location = new System.Drawing.Point(33, 387);
            this.metroCheckBox2.Name = "metroCheckBox2";
            this.metroCheckBox2.Size = new System.Drawing.Size(266, 15);
            this.metroCheckBox2.TabIndex = 1;
            this.metroCheckBox2.Text = "Baza danych SkyReg zainstalowana poprawnie";
            this.metroCheckBox2.UseVisualStyleBackColor = true;
            // 
            // metroCheckBox3
            // 
            this.metroCheckBox3.AutoSize = true;
            this.metroCheckBox3.Location = new System.Drawing.Point(33, 408);
            this.metroCheckBox3.Name = "metroCheckBox3";
            this.metroCheckBox3.Size = new System.Drawing.Size(266, 15);
            this.metroCheckBox3.TabIndex = 1;
            this.metroCheckBox3.Text = "Baza danych SkyReg zainstalowana poprawnie";
            this.metroCheckBox3.UseVisualStyleBackColor = true;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 515);
            this.Controls.Add(this.metroCheckBox3);
            this.Controls.Add(this.metroCheckBox2);
            this.Controls.Add(this.cbLoadSettings);
            this.Controls.Add(this.cbDbExists);
            this.Controls.Add(this.progressBar);
            this.Name = "SplashScreen";
            this.Text = "SplashScreen";
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroProgressBar progressBar;
        private MetroFramework.Controls.MetroCheckBox cbDbExists;
        private MetroFramework.Controls.MetroCheckBox cbLoadSettings;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox2;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox3;
    }
}