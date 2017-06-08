namespace SkyReg
{
    partial class FlightsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlightsForm));
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonPanelEx2 = new AC.ExtendedRenderer.Toolkit.KryptonPanelEx();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnDeleteFlight = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAddFlight = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnEditFlight = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonPanelEx1 = new AC.ExtendedRenderer.Toolkit.KryptonPanelEx();
            this.btnDatRefresh = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.datTo = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.datSince = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.grdFlights = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            this.kryptonPanelEx2.SuspendLayout();
            this.kryptonPanelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFlights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonPanelEx2);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonPanelEx1);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(1023, 619);
            this.kryptonHeaderGroup1.TabIndex = 0;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Wyloty";
            // 
            // kryptonPanelEx2
            // 
            this.kryptonPanelEx2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonPanelEx2.Controls.Add(this.btnClose);
            this.kryptonPanelEx2.Controls.Add(this.btnDeleteFlight);
            this.kryptonPanelEx2.Controls.Add(this.btnAddFlight);
            this.kryptonPanelEx2.Controls.Add(this.btnEditFlight);
            this.kryptonPanelEx2.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.kryptonPanelEx2.GradientToogleColors = false;
            this.kryptonPanelEx2.GradientUseBlend = false;
            this.kryptonPanelEx2.Image = null;
            this.kryptonPanelEx2.ImageLocation = new System.Drawing.Point(4, 4);
            this.kryptonPanelEx2.Location = new System.Drawing.Point(-1, 537);
            this.kryptonPanelEx2.Name = "kryptonPanelEx2";
            this.kryptonPanelEx2.PersistentColors = false;
            this.kryptonPanelEx2.Size = new System.Drawing.Size(1023, 51);
            this.kryptonPanelEx2.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(925, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(86, 25);
            this.btnClose.TabIndex = 7;
            this.btnClose.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Values.Image")));
            this.btnClose.Values.Text = "&Zamknij";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDeleteFlight
            // 
            this.btnDeleteFlight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteFlight.Location = new System.Drawing.Point(196, 14);
            this.btnDeleteFlight.Name = "btnDeleteFlight";
            this.btnDeleteFlight.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnDeleteFlight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDeleteFlight.Size = new System.Drawing.Size(86, 25);
            this.btnDeleteFlight.TabIndex = 5;
            this.btnDeleteFlight.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteFlight.Values.Image")));
            this.btnDeleteFlight.Values.Text = "&Usuń";
            this.btnDeleteFlight.Click += new System.EventHandler(this.btnDeleteFlight_Click);
            // 
            // btnAddFlight
            // 
            this.btnAddFlight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddFlight.Location = new System.Drawing.Point(12, 14);
            this.btnAddFlight.Name = "btnAddFlight";
            this.btnAddFlight.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnAddFlight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAddFlight.Size = new System.Drawing.Size(86, 25);
            this.btnAddFlight.TabIndex = 3;
            this.btnAddFlight.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFlight.Values.Image")));
            this.btnAddFlight.Values.Text = "&Dodaj";
            this.btnAddFlight.Click += new System.EventHandler(this.btnAddFlight_Click);
            // 
            // btnEditFlight
            // 
            this.btnEditFlight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditFlight.AutoSize = true;
            this.btnEditFlight.Location = new System.Drawing.Point(104, 14);
            this.btnEditFlight.Name = "btnEditFlight";
            this.btnEditFlight.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnEditFlight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEditFlight.Size = new System.Drawing.Size(86, 25);
            this.btnEditFlight.TabIndex = 4;
            this.btnEditFlight.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnEditFlight.Values.Image")));
            this.btnEditFlight.Values.Text = "&Edytuj";
            this.btnEditFlight.Click += new System.EventHandler(this.btnEditFlight_Click);
            // 
            // kryptonPanelEx1
            // 
            this.kryptonPanelEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonPanelEx1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanelEx1.Controls.Add(this.btnDatRefresh);
            this.kryptonPanelEx1.Controls.Add(this.datTo);
            this.kryptonPanelEx1.Controls.Add(this.datSince);
            this.kryptonPanelEx1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanelEx1.Controls.Add(this.grdFlights);
            this.kryptonPanelEx1.Controls.Add(this.pictureBox1);
            this.kryptonPanelEx1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.kryptonPanelEx1.GradientToogleColors = false;
            this.kryptonPanelEx1.GradientUseBlend = false;
            this.kryptonPanelEx1.Image = null;
            this.kryptonPanelEx1.ImageLocation = new System.Drawing.Point(4, 4);
            this.kryptonPanelEx1.Location = new System.Drawing.Point(-1, -3);
            this.kryptonPanelEx1.Name = "kryptonPanelEx1";
            this.kryptonPanelEx1.PersistentColors = false;
            this.kryptonPanelEx1.Size = new System.Drawing.Size(1023, 543);
            this.kryptonPanelEx1.TabIndex = 0;
            // 
            // btnDatRefresh
            // 
            this.btnDatRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDatRefresh.Location = new System.Drawing.Point(947, 512);
            this.btnDatRefresh.Name = "btnDatRefresh";
            this.btnDatRefresh.Size = new System.Drawing.Size(64, 22);
            this.btnDatRefresh.TabIndex = 5;
            this.btnDatRefresh.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnDatRefresh.Values.Image")));
            this.btnDatRefresh.Values.Text = "";
            this.btnDatRefresh.Click += new System.EventHandler(this.btnDatRefresh_Click);
            // 
            // datTo
            // 
            this.datTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.datTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datTo.Location = new System.Drawing.Point(854, 512);
            this.datTo.Name = "datTo";
            this.datTo.Size = new System.Drawing.Size(86, 21);
            this.datTo.TabIndex = 4;
            // 
            // datSince
            // 
            this.datSince.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.datSince.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datSince.Location = new System.Drawing.Point(762, 512);
            this.datSince.Name = "datSince";
            this.datSince.Size = new System.Drawing.Size(86, 21);
            this.datSince.TabIndex = 3;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel1.Location = new System.Drawing.Point(761, 485);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(70, 20);
            this.kryptonLabel1.TabIndex = 2;
            this.kryptonLabel1.Values.Text = "Zakres dat:";
            // 
            // grdFlights
            // 
            this.grdFlights.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFlights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFlights.Location = new System.Drawing.Point(0, 3);
            this.grdFlights.Name = "grdFlights";
            this.grdFlights.Size = new System.Drawing.Size(755, 537);
            this.grdFlights.TabIndex = 1;
            this.grdFlights.DoubleClick += new System.EventHandler(this.btnEditFlight_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(761, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 230);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 15000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel2.Location = new System.Drawing.Point(762, 252);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(240, 148);
            this.kryptonLabel2.TabIndex = 6;
            this.kryptonLabel2.Values.Text = resources.GetString("kryptonLabel2.Values.Text");
            // 
            // FlightsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 619);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Name = "FlightsForm";
            this.Text = "FlightsForm";
            this.Shown += new System.EventHandler(this.FlightsForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            this.kryptonPanelEx2.ResumeLayout(false);
            this.kryptonPanelEx2.PerformLayout();
            this.kryptonPanelEx1.ResumeLayout(false);
            this.kryptonPanelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFlights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx2;
        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView grdFlights;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDeleteFlight;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddFlight;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEditFlight;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDatRefresh;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker datTo;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker datSince;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.Timer timer1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
    }
}