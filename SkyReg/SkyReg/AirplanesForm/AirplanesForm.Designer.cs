namespace SkyReg
{
    partial class AirplanesForm
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
            this.kryptonPanelEx1 = new AC.ExtendedRenderer.Toolkit.KryptonPanelEx();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonPanelEx3 = new AC.ExtendedRenderer.Toolkit.KryptonPanelEx();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.grdAirplanes = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.btnAdd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnEdit = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnDelete = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonPanelEx2 = new AC.ExtendedRenderer.Toolkit.KryptonPanelEx();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kryptonPanelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            this.kryptonPanelEx3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAirplanes)).BeginInit();
            this.kryptonPanelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanelEx1
            // 
            this.kryptonPanelEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonPanelEx1.Controls.Add(this.kryptonHeaderGroup1);
            this.kryptonPanelEx1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.kryptonPanelEx1.GradientToogleColors = false;
            this.kryptonPanelEx1.GradientUseBlend = false;
            this.kryptonPanelEx1.Image = null;
            this.kryptonPanelEx1.ImageLocation = new System.Drawing.Point(4, 4);
            this.kryptonPanelEx1.Location = new System.Drawing.Point(-1, 0);
            this.kryptonPanelEx1.Name = "kryptonPanelEx1";
            this.kryptonPanelEx1.PersistentColors = false;
            this.kryptonPanelEx1.Size = new System.Drawing.Size(944, 486);
            this.kryptonPanelEx1.TabIndex = 0;
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonHeaderGroup1.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonPanelEx3);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(944, 475);
            this.kryptonHeaderGroup1.TabIndex = 0;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Samoloty";
            // 
            // kryptonPanelEx3
            // 
            this.kryptonPanelEx3.Controls.Add(this.kryptonLabel1);
            this.kryptonPanelEx3.Controls.Add(this.grdAirplanes);
            this.kryptonPanelEx3.Controls.Add(this.pictureBox1);
            this.kryptonPanelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanelEx3.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.kryptonPanelEx3.GradientToogleColors = false;
            this.kryptonPanelEx3.GradientUseBlend = false;
            this.kryptonPanelEx3.Image = null;
            this.kryptonPanelEx3.ImageLocation = new System.Drawing.Point(4, 4);
            this.kryptonPanelEx3.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanelEx3.Name = "kryptonPanelEx3";
            this.kryptonPanelEx3.PersistentColors = false;
            this.kryptonPanelEx3.Size = new System.Drawing.Size(942, 443);
            this.kryptonPanelEx3.TabIndex = 0;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel1.Location = new System.Drawing.Point(626, 220);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(211, 84);
            this.kryptonLabel1.TabIndex = 7;
            this.kryptonLabel1.Values.Text = "Kartoteka zawierająca listę informacji\r\no dostępnych samolotach\r\n- nazwa samolotu" +
    "\r\n- numer rejestracyjny samolotu\r\n- liczba miejsc w samolocie\r\n";
            // 
            // grdAirplanes
            // 
            this.grdAirplanes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAirplanes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAirplanes.Location = new System.Drawing.Point(0, 0);
            this.grdAirplanes.Name = "grdAirplanes";
            this.grdAirplanes.Size = new System.Drawing.Size(625, 443);
            this.grdAirplanes.TabIndex = 6;
            this.grdAirplanes.DoubleClick += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(3, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 25);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Values.Text = "&Dodaj";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Location = new System.Drawing.Point(99, 8);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 25);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Values.Text = "&Edytuj";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(195, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 25);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Values.Text = "&Usuń";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(842, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 25);
            this.btnClose.TabIndex = 4;
            this.btnClose.Values.Text = "&Zamknij";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // kryptonPanelEx2
            // 
            this.kryptonPanelEx2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonPanelEx2.Controls.Add(this.btnClose);
            this.kryptonPanelEx2.Controls.Add(this.btnAdd);
            this.kryptonPanelEx2.Controls.Add(this.btnDelete);
            this.kryptonPanelEx2.Controls.Add(this.btnEdit);
            this.kryptonPanelEx2.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.kryptonPanelEx2.GradientToogleColors = false;
            this.kryptonPanelEx2.GradientUseBlend = false;
            this.kryptonPanelEx2.Image = null;
            this.kryptonPanelEx2.ImageLocation = new System.Drawing.Point(4, 4);
            this.kryptonPanelEx2.Location = new System.Drawing.Point(-1, 476);
            this.kryptonPanelEx2.Name = "kryptonPanelEx2";
            this.kryptonPanelEx2.PersistentColors = false;
            this.kryptonPanelEx2.Size = new System.Drawing.Size(944, 42);
            this.kryptonPanelEx2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::SkyReg.Properties.Resources.airplane;
            this.pictureBox1.Location = new System.Drawing.Point(631, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 192);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // AirplanesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 518);
            this.Controls.Add(this.kryptonPanelEx2);
            this.Controls.Add(this.kryptonPanelEx1);
            this.MaximizeBox = false;
            this.Name = "AirplanesForm";
            this.Text = "AirplanesForm";
            this.Load += new System.EventHandler(this.AirplanesForm_Load);
            this.Shown += new System.EventHandler(this.AirplanesForm_Shown);
            this.kryptonPanelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            this.kryptonPanelEx3.ResumeLayout(false);
            this.kryptonPanelEx3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAirplanes)).EndInit();
            this.kryptonPanelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDelete;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEdit;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAdd;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx2;
        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx3;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView grdAirplanes;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}