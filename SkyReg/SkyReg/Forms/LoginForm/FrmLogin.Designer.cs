namespace SkyReg.MainForm
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.kryptonPanelEx1 = new AC.ExtendedRenderer.Toolkit.KryptonPanelEx();
            this.Btn_Close = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Btn_Login = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonPanelEx2 = new AC.ExtendedRenderer.Toolkit.KryptonPanelEx();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnDatabaseCfg = new System.Windows.Forms.ToolStripMenuItem();
            this.Txt_Pasword = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.Txt_Login = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.StyleManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonPanelEx1.SuspendLayout();
            this.kryptonPanelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanelEx1
            // 
            this.kryptonPanelEx1.Controls.Add(this.Btn_Close);
            this.kryptonPanelEx1.Controls.Add(this.Btn_Login);
            this.kryptonPanelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanelEx1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.kryptonPanelEx1.GradientToogleColors = false;
            this.kryptonPanelEx1.GradientUseBlend = false;
            this.kryptonPanelEx1.Image = null;
            this.kryptonPanelEx1.ImageLocation = new System.Drawing.Point(4, 4);
            this.kryptonPanelEx1.Location = new System.Drawing.Point(0, 142);
            this.kryptonPanelEx1.Name = "kryptonPanelEx1";
            this.kryptonPanelEx1.PersistentColors = false;
            this.kryptonPanelEx1.Size = new System.Drawing.Size(431, 37);
            this.kryptonPanelEx1.TabIndex = 0;
            // 
            // Btn_Close
            // 
            this.Btn_Close.Location = new System.Drawing.Point(305, 6);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Btn_Close.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Btn_Close.Size = new System.Drawing.Size(92, 25);
            this.Btn_Close.TabIndex = 1;
            this.Btn_Close.Values.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Close.Values.Image")));
            this.Btn_Close.Values.Text = "Zamknij";
            this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // Btn_Login
            // 
            this.Btn_Login.Location = new System.Drawing.Point(206, 6);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Btn_Login.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Btn_Login.Size = new System.Drawing.Size(93, 25);
            this.Btn_Login.TabIndex = 0;
            this.Btn_Login.Values.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Login.Values.Image")));
            this.Btn_Login.Values.Text = "Zaloguj się";
            this.Btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            // 
            // kryptonPanelEx2
            // 
            this.kryptonPanelEx2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanelEx2.Controls.Add(this.kryptonLabel3);
            this.kryptonPanelEx2.Controls.Add(this.pictureBox2);
            this.kryptonPanelEx2.Controls.Add(this.Txt_Pasword);
            this.kryptonPanelEx2.Controls.Add(this.Txt_Login);
            this.kryptonPanelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanelEx2.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.kryptonPanelEx2.GradientToogleColors = false;
            this.kryptonPanelEx2.GradientUseBlend = false;
            this.kryptonPanelEx2.Image = null;
            this.kryptonPanelEx2.ImageLocation = new System.Drawing.Point(4, 4);
            this.kryptonPanelEx2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanelEx2.Name = "kryptonPanelEx2";
            this.kryptonPanelEx2.PersistentColors = false;
            this.kryptonPanelEx2.Size = new System.Drawing.Size(431, 142);
            this.kryptonPanelEx2.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(187, 67);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(42, 17);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kryptonLabel1.StateNormal.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonLabel1.TabIndex = 23;
            this.kryptonLabel1.Values.Text = "Hasło:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(187, 44);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(41, 17);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kryptonLabel3.StateNormal.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonLabel3.TabIndex = 22;
            this.kryptonLabel3.Values.Text = "Login:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(169, 120);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDatabaseCfg});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 26);
            // 
            // btnDatabaseCfg
            // 
            this.btnDatabaseCfg.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDatabaseCfg.Image = ((System.Drawing.Image)(resources.GetObject("btnDatabaseCfg.Image")));
            this.btnDatabaseCfg.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDatabaseCfg.Name = "btnDatabaseCfg";
            this.btnDatabaseCfg.Size = new System.Drawing.Size(172, 22);
            this.btnDatabaseCfg.Text = "Konfiguracja bazy";
            this.btnDatabaseCfg.Click += new System.EventHandler(this.btnDatabaseCfg_Click);
            // 
            // Txt_Pasword
            // 
            this.Txt_Pasword.Location = new System.Drawing.Point(235, 68);
            this.Txt_Pasword.Name = "Txt_Pasword";
            this.Txt_Pasword.PasswordChar = '●';
            this.Txt_Pasword.Size = new System.Drawing.Size(162, 20);
            this.Txt_Pasword.TabIndex = 1;
            this.Txt_Pasword.UseSystemPasswordChar = true;
            this.Txt_Pasword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_Pasword_KeyDown);
            // 
            // Txt_Login
            // 
            this.Txt_Login.Location = new System.Drawing.Point(235, 42);
            this.Txt_Login.Name = "Txt_Login";
            this.Txt_Login.Size = new System.Drawing.Size(162, 20);
            this.Txt_Login.TabIndex = 0;
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
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 179);
            this.Controls.Add(this.kryptonPanelEx2);
            this.Controls.Add(this.kryptonPanelEx1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logowanie";
            this.Shown += new System.EventHandler(this.FrmLogin_Shown);
            this.kryptonPanelEx1.ResumeLayout(false);
            this.kryptonPanelEx2.ResumeLayout(false);
            this.kryptonPanelEx2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_Close;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_Login;
        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Txt_Pasword;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Txt_Login;
        private ComponentFactory.Krypton.Toolkit.KryptonManager StyleManager;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnDatabaseCfg;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
    }
}