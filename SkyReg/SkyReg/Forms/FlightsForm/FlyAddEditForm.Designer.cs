namespace SkyReg
{
    partial class FlyAddEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlyAddEditForm));
            this.kryptonPanelEx1 = new AC.ExtendedRenderer.Toolkit.KryptonPanelEx();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.numAltitude = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbAirplane = new System.Windows.Forms.ComboBox();
            this.txtLastPartOfNr = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtFirtPartOfNr = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.datDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonPanelEx2 = new AC.ExtendedRenderer.Toolkit.KryptonPanelEx();
            this.btnSaveCfg = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.kryptonPanelEx1.SuspendLayout();
            this.kryptonPanelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanelEx1
            // 
            this.kryptonPanelEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonPanelEx1.Controls.Add(this.kryptonLabel4);
            this.kryptonPanelEx1.Controls.Add(this.numAltitude);
            this.kryptonPanelEx1.Controls.Add(this.kryptonLabel3);
            this.kryptonPanelEx1.Controls.Add(this.cmbAirplane);
            this.kryptonPanelEx1.Controls.Add(this.txtLastPartOfNr);
            this.kryptonPanelEx1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanelEx1.Controls.Add(this.txtFirtPartOfNr);
            this.kryptonPanelEx1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanelEx1.Controls.Add(this.datDate);
            this.kryptonPanelEx1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.kryptonPanelEx1.GradientToogleColors = false;
            this.kryptonPanelEx1.GradientUseBlend = false;
            this.kryptonPanelEx1.Image = null;
            this.kryptonPanelEx1.ImageLocation = new System.Drawing.Point(4, 4);
            this.kryptonPanelEx1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanelEx1.Name = "kryptonPanelEx1";
            this.kryptonPanelEx1.PersistentColors = false;
            this.kryptonPanelEx1.Size = new System.Drawing.Size(348, 150);
            this.kryptonPanelEx1.TabIndex = 0;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(85, 102);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(44, 16);
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kryptonLabel4.TabIndex = 8;
            this.kryptonLabel4.Values.Text = "Pułap:";
            // 
            // numAltitude
            // 
            this.numAltitude.Location = new System.Drawing.Point(135, 96);
            this.numAltitude.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numAltitude.Name = "numAltitude";
            this.numAltitude.Size = new System.Drawing.Size(145, 22);
            this.numAltitude.TabIndex = 7;
            this.numAltitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(72, 76);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(57, 16);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kryptonLabel3.TabIndex = 6;
            this.kryptonLabel3.Values.Text = "Samolot:";
            // 
            // cmbAirplane
            // 
            this.cmbAirplane.FormattingEnabled = true;
            this.cmbAirplane.Location = new System.Drawing.Point(135, 69);
            this.cmbAirplane.Name = "cmbAirplane";
            this.cmbAirplane.Size = new System.Drawing.Size(145, 21);
            this.cmbAirplane.TabIndex = 5;
            // 
            // txtLastPartOfNr
            // 
            this.txtLastPartOfNr.Location = new System.Drawing.Point(286, 40);
            this.txtLastPartOfNr.Name = "txtLastPartOfNr";
            this.txtLastPartOfNr.Size = new System.Drawing.Size(45, 23);
            this.txtLastPartOfNr.TabIndex = 4;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(44, 47);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(85, 16);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kryptonLabel2.TabIndex = 3;
            this.kryptonLabel2.Values.Text = "Numer wylotu:";
            // 
            // txtFirtPartOfNr
            // 
            this.txtFirtPartOfNr.Location = new System.Drawing.Point(135, 40);
            this.txtFirtPartOfNr.Name = "txtFirtPartOfNr";
            this.txtFirtPartOfNr.Size = new System.Drawing.Size(145, 23);
            this.txtFirtPartOfNr.TabIndex = 2;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(91, 18);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(38, 16);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Data:";
            // 
            // datDate
            // 
            this.datDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datDate.Location = new System.Drawing.Point(135, 13);
            this.datDate.Name = "datDate";
            this.datDate.Size = new System.Drawing.Size(99, 21);
            this.datDate.TabIndex = 0;
            this.datDate.ValueChanged += new System.EventHandler(this.datDate_ValueChanged);
            // 
            // kryptonPanelEx2
            // 
            this.kryptonPanelEx2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonPanelEx2.Controls.Add(this.btnClose);
            this.kryptonPanelEx2.Controls.Add(this.btnSaveCfg);
            this.kryptonPanelEx2.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.kryptonPanelEx2.GradientToogleColors = false;
            this.kryptonPanelEx2.GradientUseBlend = false;
            this.kryptonPanelEx2.Image = null;
            this.kryptonPanelEx2.ImageLocation = new System.Drawing.Point(4, 4);
            this.kryptonPanelEx2.Location = new System.Drawing.Point(0, 148);
            this.kryptonPanelEx2.Name = "kryptonPanelEx2";
            this.kryptonPanelEx2.PersistentColors = false;
            this.kryptonPanelEx2.Size = new System.Drawing.Size(348, 46);
            this.kryptonPanelEx2.TabIndex = 0;
            // 
            // btnSaveCfg
            // 
            this.btnSaveCfg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveCfg.Location = new System.Drawing.Point(172, 11);
            this.btnSaveCfg.Name = "btnSaveCfg";
            this.btnSaveCfg.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnSaveCfg.Size = new System.Drawing.Size(73, 25);
            this.btnSaveCfg.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnSaveCfg.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSaveCfg.TabIndex = 6;
            this.btnSaveCfg.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveCfg.Values.Image")));
            this.btnSaveCfg.Values.Text = "Zapisz";
            this.btnSaveCfg.Click += new System.EventHandler(this.btnSaveCfg_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(251, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnClose.Size = new System.Drawing.Size(80, 25);
            this.btnClose.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnClose.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnClose.TabIndex = 7;
            this.btnClose.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Values.Image")));
            this.btnClose.Values.Text = "Zamknij";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FlyAddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 193);
            this.Controls.Add(this.kryptonPanelEx2);
            this.Controls.Add(this.kryptonPanelEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FlyAddEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wylot";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FlyAddEditForm_Load);
            this.kryptonPanelEx1.ResumeLayout(false);
            this.kryptonPanelEx1.PerformLayout();
            this.kryptonPanelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private System.Windows.Forms.ComboBox cmbAirplane;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLastPartOfNr;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtFirtPartOfNr;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker datDate;
        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown numAltitude;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSaveCfg;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}