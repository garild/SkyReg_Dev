namespace SkyReg.Forms.SupervisorsForm
{
    partial class SupervisorAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupervisorAddEdit));
            this.kryptonPanelEx1 = new AC.ExtendedRenderer.Toolkit.KryptonPanelEx();
            this.dtSurveyDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.dtCertificateDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtSurveyNr = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtCertificateNR = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtUserName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kryptonPanelEx2 = new AC.ExtendedRenderer.Toolkit.KryptonPanelEx();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.kryptonPanelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.kryptonPanelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanelEx1
            // 
            this.kryptonPanelEx1.Controls.Add(this.dtSurveyDate);
            this.kryptonPanelEx1.Controls.Add(this.dtCertificateDate);
            this.kryptonPanelEx1.Controls.Add(this.kryptonLabel5);
            this.kryptonPanelEx1.Controls.Add(this.kryptonLabel3);
            this.kryptonPanelEx1.Controls.Add(this.kryptonLabel4);
            this.kryptonPanelEx1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanelEx1.Controls.Add(this.txtSurveyNr);
            this.kryptonPanelEx1.Controls.Add(this.txtCertificateNR);
            this.kryptonPanelEx1.Controls.Add(this.txtUserName);
            this.kryptonPanelEx1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanelEx1.Controls.Add(this.pictureBox1);
            this.kryptonPanelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanelEx1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.kryptonPanelEx1.GradientToogleColors = false;
            this.kryptonPanelEx1.GradientUseBlend = false;
            this.kryptonPanelEx1.Image = null;
            this.kryptonPanelEx1.ImageLocation = new System.Drawing.Point(4, 4);
            this.kryptonPanelEx1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanelEx1.Name = "kryptonPanelEx1";
            this.kryptonPanelEx1.PersistentColors = false;
            this.kryptonPanelEx1.Size = new System.Drawing.Size(604, 203);
            this.kryptonPanelEx1.TabIndex = 1;
            // 
            // dtSurveyDate
            // 
            this.dtSurveyDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtSurveyDate.CalendarTodayDate = new System.DateTime(2017, 5, 25, 0, 0, 0, 0);
            this.dtSurveyDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtSurveyDate.Location = new System.Drawing.Point(366, 131);
            this.dtSurveyDate.Name = "dtSurveyDate";
            this.dtSurveyDate.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.dtSurveyDate.Size = new System.Drawing.Size(119, 21);
            this.dtSurveyDate.TabIndex = 4;
            // 
            // dtCertificateDate
            // 
            this.dtCertificateDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtCertificateDate.CalendarTodayDate = new System.DateTime(2017, 5, 25, 0, 0, 0, 0);
            this.dtCertificateDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtCertificateDate.Location = new System.Drawing.Point(366, 79);
            this.dtCertificateDate.Name = "dtCertificateDate";
            this.dtCertificateDate.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.dtCertificateDate.Size = new System.Drawing.Size(119, 21);
            this.dtCertificateDate.TabIndex = 2;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(209, 131);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(150, 20);
            this.kryptonLabel5.StateNormal.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonLabel5.TabIndex = 81;
            this.kryptonLabel5.Values.Text = "Termin ważności badania:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(199, 79);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(169, 20);
            this.kryptonLabel3.StateNormal.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonLabel3.TabIndex = 82;
            this.kryptonLabel3.Values.Text = "Termin ważności świadectwa:";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(286, 105);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(73, 20);
            this.kryptonLabel4.StateNormal.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonLabel4.TabIndex = 83;
            this.kryptonLabel4.Values.Text = "Nr badania:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(270, 53);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(92, 20);
            this.kryptonLabel2.StateNormal.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonLabel2.TabIndex = 84;
            this.kryptonLabel2.Values.Text = "Nr świadectwa:";
            // 
            // txtSurveyNr
            // 
            this.txtSurveyNr.Location = new System.Drawing.Point(365, 105);
            this.txtSurveyNr.Name = "txtSurveyNr";
            this.txtSurveyNr.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.txtSurveyNr.Size = new System.Drawing.Size(206, 20);
            this.txtSurveyNr.TabIndex = 3;
            // 
            // txtCertificateNR
            // 
            this.txtCertificateNR.Location = new System.Drawing.Point(365, 53);
            this.txtCertificateNR.Name = "txtCertificateNR";
            this.txtCertificateNR.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.txtCertificateNR.Size = new System.Drawing.Size(206, 20);
            this.txtCertificateNR.TabIndex = 1;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(365, 27);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.txtUserName.Size = new System.Drawing.Size(206, 20);
            this.txtUserName.TabIndex = 0;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(270, 27);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(98, 20);
            this.kryptonLabel1.StateNormal.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonLabel1.TabIndex = 80;
            this.kryptonLabel1.Values.Text = "Nazwisko i imię:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 189);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 76;
            this.pictureBox1.TabStop = false;
            // 
            // kryptonPanelEx2
            // 
            this.kryptonPanelEx2.Controls.Add(this.btnSave);
            this.kryptonPanelEx2.Controls.Add(this.btnClose);
            this.kryptonPanelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanelEx2.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.kryptonPanelEx2.GradientToogleColors = false;
            this.kryptonPanelEx2.GradientUseBlend = false;
            this.kryptonPanelEx2.Image = null;
            this.kryptonPanelEx2.ImageLocation = new System.Drawing.Point(4, 4);
            this.kryptonPanelEx2.Location = new System.Drawing.Point(0, 203);
            this.kryptonPanelEx2.Name = "kryptonPanelEx2";
            this.kryptonPanelEx2.PersistentColors = false;
            this.kryptonPanelEx2.Size = new System.Drawing.Size(604, 38);
            this.kryptonPanelEx2.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(388, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(93, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Values.Image")));
            this.btnSave.Values.Text = "Zapisz";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(487, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnClose.Size = new System.Drawing.Size(80, 25);
            this.btnClose.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnClose.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnClose.TabIndex = 1;
            this.btnClose.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Values.Image")));
            this.btnClose.Values.Text = "Zamknij";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SupervisorAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 241);
            this.Controls.Add(this.kryptonPanelEx1);
            this.Controls.Add(this.kryptonPanelEx2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SupervisorAddEdit";
            this.Text = "Formularz";
            this.Load += new System.EventHandler(this.SupervisorAddEdit_Load);
            this.kryptonPanelEx1.ResumeLayout(false);
            this.kryptonPanelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.kryptonPanelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx1;
        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtSurveyDate;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtCertificateDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSurveyNr;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCertificateNR;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUserName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}