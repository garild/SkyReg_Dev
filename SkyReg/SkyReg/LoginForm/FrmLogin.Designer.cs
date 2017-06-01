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
            this.Lab_password = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lab_login = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Txt_Pasword = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.Txt_Login = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.StyleManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonPanelEx1.SuspendLayout();
            this.kryptonPanelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            this.Btn_Login.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Btn_Login.Size = new System.Drawing.Size(93, 25);
            this.Btn_Login.TabIndex = 0;
            this.Btn_Login.Values.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Login.Values.Image")));
            this.Btn_Login.Values.Text = "Zaloguj się";
            this.Btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            // 
            // kryptonPanelEx2
            // 
            this.kryptonPanelEx2.Controls.Add(this.Lab_password);
            this.kryptonPanelEx2.Controls.Add(this.lab_login);
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
            // Lab_password
            // 
            this.Lab_password.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.Lab_password.Location = new System.Drawing.Point(188, 68);
            this.Lab_password.Name = "Lab_password";
            this.Lab_password.Size = new System.Drawing.Size(43, 20);
            this.Lab_password.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.Lab_password.TabIndex = 23;
            this.Lab_password.Values.Text = "Hasło";
            // 
            // lab_login
            // 
            this.lab_login.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.lab_login.Location = new System.Drawing.Point(188, 42);
            this.lab_login.Name = "lab_login";
            this.lab_login.Size = new System.Drawing.Size(43, 20);
            this.lab_login.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.lab_login.TabIndex = 22;
            this.lab_login.Values.Text = "Login";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(139, 120);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // Txt_Pasword
            // 
            this.Txt_Pasword.Location = new System.Drawing.Point(235, 68);
            this.Txt_Pasword.Name = "Txt_Pasword";
            this.Txt_Pasword.PasswordChar = '●';
            this.Txt_Pasword.Size = new System.Drawing.Size(162, 23);
            this.Txt_Pasword.TabIndex = 1;
            this.Txt_Pasword.UseSystemPasswordChar = true;
            this.Txt_Pasword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_Pasword_KeyDown);
            // 
            // Txt_Login
            // 
            this.Txt_Login.Location = new System.Drawing.Point(235, 42);
            this.Txt_Login.Name = "Txt_Login";
            this.Txt_Login.Size = new System.Drawing.Size(162, 23);
            this.Txt_Login.TabIndex = 0;
            // 
            // StyleManager
            // 
            this.StyleManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Black;
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
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logowanie";
            this.Shown += new System.EventHandler(this.FrmLogin_Shown);
            this.kryptonPanelEx1.ResumeLayout(false);
            this.kryptonPanelEx2.ResumeLayout(false);
            this.kryptonPanelEx2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_Close;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_Login;
        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel Lab_password;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lab_login;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Txt_Pasword;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Txt_Login;
        private ComponentFactory.Krypton.Toolkit.KryptonManager StyleManager;
    }
}