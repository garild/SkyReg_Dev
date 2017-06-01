namespace SkyReg
{
    partial class FrmOperatorAdd
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
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonPanelEx1 = new AC.ExtendedRenderer.Toolkit.KryptonPanelEx();
            this.cmbName = new System.Windows.Forms.ComboBox();
            this.btnOperatorAdd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOperatorCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cmbTypes = new AC.ExtendedRenderer.Toolkit.KryptonComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.kryptonPanelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(14, 11);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(98, 20);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Nazwisko i imię:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(79, 39);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(33, 20);
            this.kryptonLabel2.TabIndex = 3;
            this.kryptonLabel2.Values.Text = "Typ:";
            // 
            // kryptonPanelEx1
            // 
            this.kryptonPanelEx1.Controls.Add(this.cmbName);
            this.kryptonPanelEx1.Controls.Add(this.btnOperatorAdd);
            this.kryptonPanelEx1.Controls.Add(this.btnOperatorCancel);
            this.kryptonPanelEx1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanelEx1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanelEx1.Controls.Add(this.cmbTypes);
            this.kryptonPanelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanelEx1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.kryptonPanelEx1.GradientToogleColors = false;
            this.kryptonPanelEx1.GradientUseBlend = false;
            this.kryptonPanelEx1.Image = null;
            this.kryptonPanelEx1.ImageLocation = new System.Drawing.Point(4, 4);
            this.kryptonPanelEx1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanelEx1.Name = "kryptonPanelEx1";
            this.kryptonPanelEx1.PersistentColors = false;
            this.kryptonPanelEx1.Size = new System.Drawing.Size(440, 127);
            this.kryptonPanelEx1.TabIndex = 5;
            // 
            // cmbName
            // 
            this.cmbName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbName.FormattingEnabled = true;
            this.cmbName.Location = new System.Drawing.Point(119, 11);
            this.cmbName.Name = "cmbName";
            this.cmbName.Size = new System.Drawing.Size(309, 21);
            this.cmbName.TabIndex = 0;
            // 
            // btnOperatorAdd
            // 
            this.btnOperatorAdd.Location = new System.Drawing.Point(242, 87);
            this.btnOperatorAdd.Name = "btnOperatorAdd";
            this.btnOperatorAdd.Size = new System.Drawing.Size(90, 25);
            this.btnOperatorAdd.TabIndex = 2;
            this.btnOperatorAdd.Values.Text = "&Dodaj";
            this.btnOperatorAdd.Click += new System.EventHandler(this.btnOperatorAdd_Click);
            // 
            // btnOperatorCancel
            // 
            this.btnOperatorCancel.Location = new System.Drawing.Point(338, 87);
            this.btnOperatorCancel.Name = "btnOperatorCancel";
            this.btnOperatorCancel.Size = new System.Drawing.Size(90, 25);
            this.btnOperatorCancel.TabIndex = 3;
            this.btnOperatorCancel.Values.Text = "&Anuluj";
            this.btnOperatorCancel.Click += new System.EventHandler(this.btnOperatorCancel_Click);
            // 
            // cmbTypes
            // 
            this.cmbTypes.DisableBorderColor = false;
            this.cmbTypes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypes.FormattingEnabled = true;
            this.cmbTypes.Items.AddRange(new object[] {
            "Operator",
            "Rejestrujący"});
            this.cmbTypes.Location = new System.Drawing.Point(118, 38);
            this.cmbTypes.Name = "cmbTypes";
            this.cmbTypes.PersistentColors = false;
            this.cmbTypes.Size = new System.Drawing.Size(179, 21);
            this.cmbTypes.TabIndex = 1;
            this.cmbTypes.UseStyledColors = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmOperatorAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 127);
            this.Controls.Add(this.kryptonPanelEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOperatorAdd";
            this.Text = "Dodaj";
            this.Load += new System.EventHandler(this.FrmOperatorAdd_Load);
            this.kryptonPanelEx1.ResumeLayout(false);
            this.kryptonPanelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOperatorAdd;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOperatorCancel;
        private System.Windows.Forms.ComboBox cmbName;
        private AC.ExtendedRenderer.Toolkit.KryptonComboBox cmbTypes;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}