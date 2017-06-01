namespace SkyReg
{
    partial class FrmMain
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
            AC.ExtendedRenderer.Navigator.OutlookBarButton outlookBarButton1 = new AC.ExtendedRenderer.Navigator.OutlookBarButton();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            AC.ExtendedRenderer.Navigator.OutlookBarButton outlookBarButton2 = new AC.ExtendedRenderer.Navigator.OutlookBarButton();
            AC.ExtendedRenderer.Navigator.OutlookBarButton outlookBarButton3 = new AC.ExtendedRenderer.Navigator.OutlookBarButton();
            AC.ExtendedRenderer.Navigator.OutlookBarButton outlookBarButton4 = new AC.ExtendedRenderer.Navigator.OutlookBarButton();
            AC.ExtendedRenderer.Navigator.OutlookBarButton outlookBarButton5 = new AC.ExtendedRenderer.Navigator.OutlookBarButton();
            AC.ExtendedRenderer.Navigator.OutlookBarButton outlookBarButton6 = new AC.ExtendedRenderer.Navigator.OutlookBarButton();
            AC.ExtendedRenderer.Navigator.OutlookBarButton outlookBarButton7 = new AC.ExtendedRenderer.Navigator.OutlookBarButton();
            AC.ExtendedRenderer.Navigator.OutlookBarButton outlookBarButton8 = new AC.ExtendedRenderer.Navigator.OutlookBarButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.StyleManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.outlookBar1 = new AC.ExtendedRenderer.Navigator.OutlookBar();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 446);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(1101, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(300, 16);
            // 
            // StyleManager
            // 
            this.StyleManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Black;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.outlookBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 446);
            this.panel1.TabIndex = 3;
            // 
            // outlookBar1
            // 
            this.outlookBar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.outlookBar1.ButtonColorHoveringBottom = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(239)))), ((int)(((byte)(177)))));
            this.outlookBar1.ButtonColorHoveringTop = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(77)))));
            this.outlookBar1.ButtonColorPassiveBottom = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(232)))), ((int)(((byte)(236)))));
            this.outlookBar1.ButtonColorPassiveTop = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(208)))), ((int)(((byte)(214)))));
            this.outlookBar1.ButtonColorSelectedAndHoveringBottom = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(207)))), ((int)(((byte)(100)))));
            this.outlookBar1.ButtonColorSelectedAndHoveringTop = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(142)))), ((int)(((byte)(49)))));
            this.outlookBar1.ButtonColorSelectedBottom = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(195)))), ((int)(((byte)(108)))));
            this.outlookBar1.ButtonColorSelectedTop = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(122)))), ((int)(((byte)(5)))));
            this.outlookBar1.ButtonHeight = 35;
            outlookBarButton1.BuddyPage1 = "Flights";
            outlookBarButton1.BuddyPage2 = null;
            outlookBarButton1.Image = ((System.Drawing.Icon)(resources.GetObject("outlookBarButton1.Image")));
            outlookBarButton1.Tag1 = null;
            outlookBarButton1.Tag2 = null;
            outlookBarButton1.Text = "Wyloty";
            outlookBarButton2.BuddyPage1 = "Jumpers";
            outlookBarButton2.BuddyPage2 = null;
            outlookBarButton2.Image = ((System.Drawing.Icon)(resources.GetObject("outlookBarButton2.Image")));
            outlookBarButton2.Tag1 = null;
            outlookBarButton2.Tag2 = null;
            outlookBarButton2.Text = "Skoczkowie";
            outlookBarButton3.BuddyPage1 = "Parachutes";
            outlookBarButton3.BuddyPage2 = null;
            outlookBarButton3.Image = ((System.Drawing.Icon)(resources.GetObject("outlookBarButton3.Image")));
            outlookBarButton3.Tag1 = null;
            outlookBarButton3.Tag2 = null;
            outlookBarButton3.Text = "Spadochrony";
            outlookBarButton4.BuddyPage1 = "Jumpers_types";
            outlookBarButton4.BuddyPage2 = null;
            outlookBarButton4.Image = ((System.Drawing.Icon)(resources.GetObject("outlookBarButton4.Image")));
            outlookBarButton4.Tag1 = null;
            outlookBarButton4.Tag2 = null;
            outlookBarButton4.Text = "Typy skoczków";
            outlookBarButton5.BuddyPage1 = "Airplanes";
            outlookBarButton5.BuddyPage2 = null;
            outlookBarButton5.Image = ((System.Drawing.Icon)(resources.GetObject("outlookBarButton5.Image")));
            outlookBarButton5.Tag1 = null;
            outlookBarButton5.Tag2 = null;
            outlookBarButton5.Text = "Samoloty";
            outlookBarButton6.BuddyPage1 = "Orders";
            outlookBarButton6.BuddyPage2 = null;
            outlookBarButton6.Image = ((System.Drawing.Icon)(resources.GetObject("outlookBarButton6.Image")));
            outlookBarButton6.Tag1 = null;
            outlookBarButton6.Tag2 = null;
            outlookBarButton6.Text = "Zgłoszenia";
            outlookBarButton7.BuddyPage1 = "Moneys";
            outlookBarButton7.BuddyPage2 = null;
            outlookBarButton7.Image = ((System.Drawing.Icon)(resources.GetObject("outlookBarButton7.Image")));
            outlookBarButton7.Tag1 = null;
            outlookBarButton7.Tag2 = null;
            outlookBarButton7.Text = "Finanse";
            outlookBarButton8.BuddyPage1 = "Settings";
            outlookBarButton8.BuddyPage2 = null;
            outlookBarButton8.Image = ((System.Drawing.Icon)(resources.GetObject("outlookBarButton8.Image")));
            outlookBarButton8.Tag1 = null;
            outlookBarButton8.Tag2 = null;
            outlookBarButton8.Text = "Ustawienia";
            this.outlookBar1.Buttons.Add(outlookBarButton1);
            this.outlookBar1.Buttons.Add(outlookBarButton2);
            this.outlookBar1.Buttons.Add(outlookBarButton3);
            this.outlookBar1.Buttons.Add(outlookBarButton4);
            this.outlookBar1.Buttons.Add(outlookBarButton5);
            this.outlookBar1.Buttons.Add(outlookBarButton6);
            this.outlookBar1.Buttons.Add(outlookBarButton7);
            this.outlookBar1.Buttons.Add(outlookBarButton8);
            this.outlookBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.outlookBar1.DrawBorders = true;
            this.outlookBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.outlookBar1.ForeColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.outlookBar1.Location = new System.Drawing.Point(0, 0);
            this.outlookBar1.MinimumSize = new System.Drawing.Size(16, 40);
            this.outlookBar1.Name = "outlookBar1";
            this.outlookBar1.OutlookBarLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(83)))), ((int)(((byte)(92)))));
            this.outlookBar1.RemoveTopBorder = true;
            this.outlookBar1.Renderer = AC.ExtendedRenderer.Navigator.Renderer.Krypton;
            this.outlookBar1.Size = new System.Drawing.Size(200, 296);
            this.outlookBar1.TabIndex = 1;
            this.outlookBar1.Text = "outlookBar1";
            this.outlookBar1.ButtonClicked += new AC.ExtendedRenderer.Navigator.OutlookBar.ButtonClickedEventHandler(this.outlookBar1_ButtonClicked);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SkyReg.Properties.Resources.logo_opacity;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1101, 468);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SkyReg";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private ComponentFactory.Krypton.Toolkit.KryptonManager StyleManager;
        private System.Windows.Forms.Panel panel1;
        private AC.ExtendedRenderer.Navigator.OutlookBar outlookBar1;
    }
}

