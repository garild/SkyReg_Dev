namespace SkyReg.Forms.ScheduleForm
{
    partial class ScheduleMoveCopyUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleMoveCopyUsers));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.kryptonPanelEx3 = new AC.ExtendedRenderer.Toolkit.KryptonPanelEx();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonPanelEx2 = new AC.ExtendedRenderer.Toolkit.KryptonPanelEx();
            this.grdFlights = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.Checked = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn();
            this.kryptonPanelEx4 = new AC.ExtendedRenderer.Toolkit.KryptonPanelEx();
            this.btnRefreshFlights = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.datToFlights = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.datSinceFlights = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonPanelEx1 = new AC.ExtendedRenderer.Toolkit.KryptonPanelEx();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.kryptonPanelEx3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            this.kryptonPanelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFlights)).BeginInit();
            this.kryptonPanelEx4.SuspendLayout();
            this.kryptonPanelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanelEx3
            // 
            this.kryptonPanelEx3.Controls.Add(this.kryptonHeaderGroup1);
            this.kryptonPanelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanelEx3.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.kryptonPanelEx3.GradientToogleColors = false;
            this.kryptonPanelEx3.GradientUseBlend = false;
            this.kryptonPanelEx3.Image = null;
            this.kryptonPanelEx3.ImageLocation = new System.Drawing.Point(4, 4);
            this.kryptonPanelEx3.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanelEx3.Name = "kryptonPanelEx3";
            this.kryptonPanelEx3.PersistentColors = false;
            this.kryptonPanelEx3.Size = new System.Drawing.Size(427, 275);
            this.kryptonPanelEx3.TabIndex = 3;
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonLowProfile;
            this.kryptonHeaderGroup1.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ButtonNavigatorStack;
            this.kryptonHeaderGroup1.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Calendar;
            this.kryptonHeaderGroup1.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            this.kryptonHeaderGroup1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparklePurple;
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonPanelEx2);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(427, 275);
            this.kryptonHeaderGroup1.TabIndex = 75;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Lista wylotów";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = ((System.Drawing.Image)(resources.GetObject("kryptonHeaderGroup1.ValuesPrimary.Image")));
            // 
            // kryptonPanelEx2
            // 
            this.kryptonPanelEx2.Controls.Add(this.grdFlights);
            this.kryptonPanelEx2.Controls.Add(this.kryptonPanelEx4);
            this.kryptonPanelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanelEx2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kryptonPanelEx2.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.kryptonPanelEx2.GradientToogleColors = false;
            this.kryptonPanelEx2.GradientUseBlend = false;
            this.kryptonPanelEx2.Image = null;
            this.kryptonPanelEx2.ImageLocation = new System.Drawing.Point(4, 4);
            this.kryptonPanelEx2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanelEx2.Name = "kryptonPanelEx2";
            this.kryptonPanelEx2.PersistentColors = false;
            this.kryptonPanelEx2.Size = new System.Drawing.Size(427, 251);
            this.kryptonPanelEx2.TabIndex = 0;
            // 
            // grdFlights
            // 
            this.grdFlights.AllowUserToAddRows = false;
            this.grdFlights.AllowUserToDeleteRows = false;
            this.grdFlights.AllowUserToResizeColumns = false;
            this.grdFlights.AllowUserToResizeRows = false;
            this.grdFlights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFlights.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Checked});
            this.grdFlights.Cursor = System.Windows.Forms.Cursors.Hand;
            this.grdFlights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFlights.Location = new System.Drawing.Point(0, 43);
            this.grdFlights.MultiSelect = false;
            this.grdFlights.Name = "grdFlights";
            this.grdFlights.ReadOnly = true;
            this.grdFlights.RowHeadersVisible = false;
            this.grdFlights.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFlights.ShowCellErrors = false;
            this.grdFlights.ShowCellToolTips = false;
            this.grdFlights.ShowEditingIcon = false;
            this.grdFlights.ShowRowErrors = false;
            this.grdFlights.Size = new System.Drawing.Size(427, 208);
            this.grdFlights.TabIndex = 6;
            this.grdFlights.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdFlights_MouseClick);
            // 
            // Checked
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = false;
            this.Checked.DefaultCellStyle = dataGridViewCellStyle2;
            this.Checked.FalseValue = "false";
            this.Checked.FillWeight = 50F;
            this.Checked.HeaderText = "Wybór";
            this.Checked.IndeterminateValue = "false";
            this.Checked.MinimumWidth = 50;
            this.Checked.Name = "Checked";
            this.Checked.ReadOnly = true;
            this.Checked.TrueValue = "true";
            this.Checked.Width = 50;
            // 
            // kryptonPanelEx4
            // 
            this.kryptonPanelEx4.Controls.Add(this.btnRefreshFlights);
            this.kryptonPanelEx4.Controls.Add(this.datToFlights);
            this.kryptonPanelEx4.Controls.Add(this.datSinceFlights);
            this.kryptonPanelEx4.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanelEx4.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.kryptonPanelEx4.GradientToogleColors = false;
            this.kryptonPanelEx4.GradientUseBlend = false;
            this.kryptonPanelEx4.Image = null;
            this.kryptonPanelEx4.ImageLocation = new System.Drawing.Point(4, 4);
            this.kryptonPanelEx4.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanelEx4.Name = "kryptonPanelEx4";
            this.kryptonPanelEx4.PersistentColors = false;
            this.kryptonPanelEx4.Size = new System.Drawing.Size(427, 43);
            this.kryptonPanelEx4.TabIndex = 5;
            // 
            // btnRefreshFlights
            // 
            this.btnRefreshFlights.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshFlights.Location = new System.Drawing.Point(317, 11);
            this.btnRefreshFlights.Name = "btnRefreshFlights";
            this.btnRefreshFlights.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnRefreshFlights.Size = new System.Drawing.Size(51, 22);
            this.btnRefreshFlights.TabIndex = 12;
            this.btnRefreshFlights.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshFlights.Values.Image")));
            this.btnRefreshFlights.Values.Text = "";
            this.btnRefreshFlights.Click += new System.EventHandler(this.btnRefreshFlights_Click);
            // 
            // datToFlights
            // 
            this.datToFlights.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datToFlights.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datToFlights.Location = new System.Drawing.Point(184, 12);
            this.datToFlights.Name = "datToFlights";
            this.datToFlights.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.datToFlights.Size = new System.Drawing.Size(113, 21);
            this.datToFlights.TabIndex = 11;
            // 
            // datSinceFlights
            // 
            this.datSinceFlights.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datSinceFlights.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datSinceFlights.Location = new System.Drawing.Point(46, 12);
            this.datSinceFlights.Name = "datSinceFlights";
            this.datSinceFlights.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.datSinceFlights.Size = new System.Drawing.Size(119, 21);
            this.datSinceFlights.TabIndex = 10;
            // 
            // kryptonPanelEx1
            // 
            this.kryptonPanelEx1.Controls.Add(this.btnSave);
            this.kryptonPanelEx1.Controls.Add(this.btnClose);
            this.kryptonPanelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanelEx1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.kryptonPanelEx1.GradientToogleColors = false;
            this.kryptonPanelEx1.GradientUseBlend = false;
            this.kryptonPanelEx1.Image = null;
            this.kryptonPanelEx1.ImageLocation = new System.Drawing.Point(4, 4);
            this.kryptonPanelEx1.Location = new System.Drawing.Point(0, 275);
            this.kryptonPanelEx1.Name = "kryptonPanelEx1";
            this.kryptonPanelEx1.PersistentColors = false;
            this.kryptonPanelEx1.Size = new System.Drawing.Size(427, 43);
            this.kryptonPanelEx1.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(68, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(100, 25);
            this.btnSave.TabIndex = 2;
            this.btnSave.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Values.Image")));
            this.btnSave.Values.Text = "Zapisz";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(193, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnClose.Size = new System.Drawing.Size(104, 25);
            this.btnClose.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnClose.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnClose.TabIndex = 1;
            this.btnClose.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Values.Image")));
            this.btnClose.Values.Text = "Zamknij";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 200;
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // ScheduleMoveCopyUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 318);
            this.Controls.Add(this.kryptonPanelEx3);
            this.Controls.Add(this.kryptonPanelEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ScheduleMoveCopyUsers";
            this.Text = "Formularz";
            this.Load += new System.EventHandler(this.ScheduleMoveCopyUsers_Load);
            this.kryptonPanelEx3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            this.kryptonPanelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFlights)).EndInit();
            this.kryptonPanelEx4.ResumeLayout(false);
            this.kryptonPanelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx3;
        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx2;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView grdFlights;
        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx4;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnRefreshFlights;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker datToFlights;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker datSinceFlights;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn Checked;
    }
}