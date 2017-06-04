namespace SkyReg.Forms.DatabaseConfiguration
{
    partial class FrmDataBaseConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDataBaseConfig));
            this.progresBarDB = new System.Windows.Forms.ProgressBar();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtUserName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.txtServer = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtPassword = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtDatabase = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnSaveCfg = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btGenerateDataBase = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.StyleManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // progresBarDB
            // 
            this.progresBarDB.Location = new System.Drawing.Point(0, 128);
            this.progresBarDB.Name = "progresBarDB";
            this.progresBarDB.Size = new System.Drawing.Size(472, 10);
            this.progresBarDB.TabIndex = 25;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(170, 19);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(68, 17);
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kryptonLabel4.StateNormal.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonLabel4.TabIndex = 19;
            this.kryptonLabel4.Values.Text = "Serwer SQL";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(244, 70);
            this.txtUserName.MaxLength = 40;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(213, 20);
            this.txtUserName.TabIndex = 14;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.progresBarDB);
            this.kryptonPanel1.Controls.Add(this.txtServer);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel1.Controls.Add(this.txtUserName);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel1.Controls.Add(this.txtPassword);
            this.kryptonPanel1.Controls.Add(this.txtDatabase);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.pictureBox2);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(469, 139);
            this.kryptonPanel1.StateNormal.Color1 = System.Drawing.SystemColors.WindowFrame;
            this.kryptonPanel1.TabIndex = 14;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(244, 18);
            this.txtServer.MaxLength = 80;
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(213, 20);
            this.txtServer.TabIndex = 12;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(130, 71);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(108, 17);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kryptonLabel1.StateNormal.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonLabel1.TabIndex = 15;
            this.kryptonLabel1.Values.Text = "Nazwa użytkownika";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(165, 45);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(73, 17);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kryptonLabel3.StateNormal.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonLabel3.TabIndex = 18;
            this.kryptonLabel3.Values.Text = "Baza danych";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(244, 96);
            this.txtPassword.MaxLength = 40;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(213, 20);
            this.txtPassword.TabIndex = 16;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(244, 44);
            this.txtDatabase.MaxLength = 80;
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(213, 20);
            this.txtDatabase.TabIndex = 13;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(157, 97);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(81, 17);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kryptonLabel2.StateNormal.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonLabel2.TabIndex = 17;
            this.kryptonLabel2.Values.Text = "Hasło dostępu";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(24, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(102, 102);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // btnSaveCfg
            // 
            this.btnSaveCfg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveCfg.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSaveCfg.Location = new System.Drawing.Point(299, 6);
            this.btnSaveCfg.Name = "btnSaveCfg";
            this.btnSaveCfg.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnSaveCfg.Size = new System.Drawing.Size(73, 25);
            this.btnSaveCfg.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnSaveCfg.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSaveCfg.TabIndex = 5;
            this.btnSaveCfg.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveCfg.Values.Image")));
            this.btnSaveCfg.Values.Text = "Zapisz";
            this.btnSaveCfg.Click += new System.EventHandler(this.btnSaveCfg_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(378, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnClose.Size = new System.Drawing.Size(80, 25);
            this.btnClose.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnClose.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnClose.TabIndex = 5;
            this.btnClose.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Values.Image")));
            this.btnClose.Values.Text = "Zamknij";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btGenerateDataBase
            // 
            this.btGenerateDataBase.Location = new System.Drawing.Point(3, 6);
            this.btGenerateDataBase.Name = "btGenerateDataBase";
            this.btGenerateDataBase.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btGenerateDataBase.Size = new System.Drawing.Size(114, 25);
            this.btGenerateDataBase.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btGenerateDataBase.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btGenerateDataBase.TabIndex = 4;
            this.btGenerateDataBase.Values.Image = ((System.Drawing.Image)(resources.GetObject("btGenerateDataBase.Values.Image")));
            this.btGenerateDataBase.Values.Text = "Generuj Bazę";
            this.btGenerateDataBase.Click += new System.EventHandler(this.btGenerateDataBase_Click);
            // 
            // StyleManager
            // 
            this.StyleManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Black;
            this.StyleManager.GlobalStrings.Abort = "Przerwij";
            this.StyleManager.GlobalStrings.Cancel = "Wyjdź";
            this.StyleManager.GlobalStrings.Close = "Zamknij";
            this.StyleManager.GlobalStrings.Ignore = "Ignoruj";
            this.StyleManager.GlobalStrings.No = "Nie";
            this.StyleManager.GlobalStrings.Retry = "Próbuj ponownie";
            this.StyleManager.GlobalStrings.Today = "Dzisiaj";
            this.StyleManager.GlobalStrings.Yes = "Tak";
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.btnSaveCfg);
            this.kryptonPanel3.Controls.Add(this.btnClose);
            this.kryptonPanel3.Controls.Add(this.btGenerateDataBase);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel3.Location = new System.Drawing.Point(0, 136);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(469, 37);
            this.kryptonPanel3.StateCommon.Color1 = System.Drawing.SystemColors.ActiveCaption;
            this.kryptonPanel3.StateNormal.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.kryptonPanel3.TabIndex = 15;
            // 
            // FrmDataBaseConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 173);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.kryptonPanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmDataBaseConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generowanie bazy";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progresBarDB;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUserName;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtServer;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPassword;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDatabase;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSaveCfg;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btGenerateDataBase;
        private ComponentFactory.Krypton.Toolkit.KryptonManager StyleManager;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel3;
    }
}