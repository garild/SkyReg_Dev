namespace SkyReg.Forms.SupervisorsForm
{
    partial class FrmSupervisors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSupervisors));
            this.kryptonPanelEx1 = new AC.ExtendedRenderer.Toolkit.KryptonPanelEx();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnDeleteSupervisor = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnEditSupervisor = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAddSupervisor = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonPanelEx3 = new AC.ExtendedRenderer.Toolkit.KryptonPanelEx();
            this.grdSupervisor = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonPanelEx2 = new AC.ExtendedRenderer.Toolkit.KryptonPanelEx();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kryptonPanelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            this.kryptonPanelEx3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSupervisor)).BeginInit();
            this.kryptonPanelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanelEx1
            // 
            this.kryptonPanelEx1.Controls.Add(this.btnClose);
            this.kryptonPanelEx1.Controls.Add(this.btnDeleteSupervisor);
            this.kryptonPanelEx1.Controls.Add(this.btnEditSupervisor);
            this.kryptonPanelEx1.Controls.Add(this.btnAddSupervisor);
            this.kryptonPanelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanelEx1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.kryptonPanelEx1.GradientToogleColors = false;
            this.kryptonPanelEx1.GradientUseBlend = false;
            this.kryptonPanelEx1.Image = null;
            this.kryptonPanelEx1.ImageLocation = new System.Drawing.Point(4, 4);
            this.kryptonPanelEx1.Location = new System.Drawing.Point(0, 532);
            this.kryptonPanelEx1.Name = "kryptonPanelEx1";
            this.kryptonPanelEx1.PersistentColors = false;
            this.kryptonPanelEx1.Size = new System.Drawing.Size(939, 40);
            this.kryptonPanelEx1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(837, 8);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5);
            this.btnClose.Name = "btnClose";
            this.btnClose.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(90, 25);
            this.btnClose.TabIndex = 5;
            this.btnClose.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Values.Image")));
            this.btnClose.Values.Text = "&Zamknij";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDeleteSupervisor
            // 
            this.btnDeleteSupervisor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteSupervisor.Location = new System.Drawing.Point(198, 8);
            this.btnDeleteSupervisor.Margin = new System.Windows.Forms.Padding(5);
            this.btnDeleteSupervisor.Name = "btnDeleteSupervisor";
            this.btnDeleteSupervisor.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnDeleteSupervisor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDeleteSupervisor.Size = new System.Drawing.Size(90, 25);
            this.btnDeleteSupervisor.TabIndex = 4;
            this.btnDeleteSupervisor.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteSupervisor.Values.Image")));
            this.btnDeleteSupervisor.Values.Text = "U&suń";
            this.btnDeleteSupervisor.Click += new System.EventHandler(this.btnDeleteSupervisor_Click);
            // 
            // btnEditSupervisor
            // 
            this.btnEditSupervisor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditSupervisor.Location = new System.Drawing.Point(102, 8);
            this.btnEditSupervisor.Margin = new System.Windows.Forms.Padding(5);
            this.btnEditSupervisor.Name = "btnEditSupervisor";
            this.btnEditSupervisor.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnEditSupervisor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEditSupervisor.Size = new System.Drawing.Size(90, 25);
            this.btnEditSupervisor.TabIndex = 3;
            this.btnEditSupervisor.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnEditSupervisor.Values.Image")));
            this.btnEditSupervisor.Values.Text = "&Edytuj";
            this.btnEditSupervisor.Click += new System.EventHandler(this.btnEditSupervisor_Click);
            // 
            // btnAddSupervisor
            // 
            this.btnAddSupervisor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddSupervisor.Location = new System.Drawing.Point(6, 8);
            this.btnAddSupervisor.Margin = new System.Windows.Forms.Padding(5);
            this.btnAddSupervisor.Name = "btnAddSupervisor";
            this.btnAddSupervisor.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnAddSupervisor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAddSupervisor.Size = new System.Drawing.Size(90, 25);
            this.btnAddSupervisor.TabIndex = 2;
            this.btnAddSupervisor.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnAddSupervisor.Values.Image")));
            this.btnAddSupervisor.Values.Text = "D&odaj  ";
            this.btnAddSupervisor.Click += new System.EventHandler(this.btnAddSupervisor_Click);
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
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonPanelEx3);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonPanelEx2);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(939, 532);
            this.kryptonHeaderGroup1.TabIndex = 4;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Instruktorzy";
            // 
            // kryptonPanelEx3
            // 
            this.kryptonPanelEx3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonPanelEx3.Controls.Add(this.grdSupervisor);
            this.kryptonPanelEx3.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.kryptonPanelEx3.GradientToogleColors = false;
            this.kryptonPanelEx3.GradientUseBlend = false;
            this.kryptonPanelEx3.Image = null;
            this.kryptonPanelEx3.ImageLocation = new System.Drawing.Point(4, 4);
            this.kryptonPanelEx3.Location = new System.Drawing.Point(-1, 0);
            this.kryptonPanelEx3.Name = "kryptonPanelEx3";
            this.kryptonPanelEx3.PersistentColors = false;
            this.kryptonPanelEx3.Size = new System.Drawing.Size(642, 501);
            this.kryptonPanelEx3.TabIndex = 1;
            // 
            // grdSupervisor
            // 
            this.grdSupervisor.AllowUserToAddRows = false;
            this.grdSupervisor.AllowUserToDeleteRows = false;
            this.grdSupervisor.AllowUserToResizeRows = false;
            this.grdSupervisor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.grdSupervisor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSupervisor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSupervisor.Location = new System.Drawing.Point(0, 0);
            this.grdSupervisor.MultiSelect = false;
            this.grdSupervisor.Name = "grdSupervisor";
            this.grdSupervisor.ReadOnly = true;
            this.grdSupervisor.RowHeadersVisible = false;
            this.grdSupervisor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSupervisor.ShowCellErrors = false;
            this.grdSupervisor.ShowCellToolTips = false;
            this.grdSupervisor.ShowEditingIcon = false;
            this.grdSupervisor.ShowRowErrors = false;
            this.grdSupervisor.Size = new System.Drawing.Size(642, 501);
            this.grdSupervisor.TabIndex = 0;
            this.grdSupervisor.DoubleClick += new System.EventHandler(this.grdSupervisor_DoubleClick);
            // 
            // kryptonPanelEx2
            // 
            this.kryptonPanelEx2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonPanelEx2.Controls.Add(this.pictureBox1);
            this.kryptonPanelEx2.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.kryptonPanelEx2.GradientToogleColors = false;
            this.kryptonPanelEx2.GradientUseBlend = false;
            this.kryptonPanelEx2.Image = null;
            this.kryptonPanelEx2.ImageLocation = new System.Drawing.Point(4, 4);
            this.kryptonPanelEx2.Location = new System.Drawing.Point(638, 0);
            this.kryptonPanelEx2.Name = "kryptonPanelEx2";
            this.kryptonPanelEx2.PersistentColors = false;
            this.kryptonPanelEx2.Size = new System.Drawing.Size(300, 502);
            this.kryptonPanelEx2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FrmSupervisors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 572);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Controls.Add(this.kryptonPanelEx1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSupervisors";
            this.Text = "Lista Instruktorów";
            this.Load += new System.EventHandler(this.FrmSupervisors_Load);
            this.kryptonPanelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            this.kryptonPanelEx3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSupervisor)).EndInit();
            this.kryptonPanelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDeleteSupervisor;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEditSupervisor;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddSupervisor;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx3;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView grdSupervisor;
        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}