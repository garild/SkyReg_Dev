namespace SkyReg
{
    partial class FrmPaymentAdd
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
            this.kryptonPanelEx1 = new AC.ExtendedRenderer.Toolkit.KryptonPanelEx();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.numCount = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.numPrice = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbBoxTypes = new AC.ExtendedRenderer.Toolkit.KryptonComboBox();
            this.txtBoxName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.kryptonPanelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanelEx1
            // 
            this.kryptonPanelEx1.Controls.Add(this.btnCancel);
            this.kryptonPanelEx1.Controls.Add(this.btnOK);
            this.kryptonPanelEx1.Controls.Add(this.kryptonLabel4);
            this.kryptonPanelEx1.Controls.Add(this.numCount);
            this.kryptonPanelEx1.Controls.Add(this.kryptonLabel3);
            this.kryptonPanelEx1.Controls.Add(this.numPrice);
            this.kryptonPanelEx1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanelEx1.Controls.Add(this.cmbBoxTypes);
            this.kryptonPanelEx1.Controls.Add(this.txtBoxName);
            this.kryptonPanelEx1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanelEx1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.kryptonPanelEx1.GradientToogleColors = false;
            this.kryptonPanelEx1.GradientUseBlend = false;
            this.kryptonPanelEx1.Image = null;
            this.kryptonPanelEx1.ImageLocation = new System.Drawing.Point(4, 4);
            this.kryptonPanelEx1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanelEx1.Name = "kryptonPanelEx1";
            this.kryptonPanelEx1.PersistentColors = false;
            this.kryptonPanelEx1.Size = new System.Drawing.Size(371, 184);
            this.kryptonPanelEx1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(253, 139);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Values.Text = "&Anuluj";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(157, 139);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 25);
            this.btnOK.TabIndex = 4;
            this.btnOK.Values.Text = "&Dodaj";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(12, 95);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(42, 20);
            this.kryptonLabel4.TabIndex = 7;
            this.kryptonLabel4.Values.Text = "Skoki:";
            // 
            // numCount
            // 
            this.numCount.Location = new System.Drawing.Point(60, 93);
            this.numCount.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numCount.Name = "numCount";
            this.numCount.Size = new System.Drawing.Size(146, 22);
            this.numCount.TabIndex = 3;
            this.numCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(12, 67);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(41, 20);
            this.kryptonLabel3.TabIndex = 5;
            this.kryptonLabel3.Values.Text = "Cena:";
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new System.Drawing.Point(60, 65);
            this.numPrice.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(146, 22);
            this.numPrice.TabIndex = 2;
            this.numPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 39);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(33, 20);
            this.kryptonLabel2.TabIndex = 3;
            this.kryptonLabel2.Values.Text = "Typ:";
            // 
            // cmbBoxTypes
            // 
            this.cmbBoxTypes.DisableBorderColor = false;
            this.cmbBoxTypes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbBoxTypes.FormattingEnabled = true;
            this.cmbBoxTypes.Items.AddRange(new object[] {
            "Wpłata",
            "Wypłata",
            "Pakiet"});
            this.cmbBoxTypes.Location = new System.Drawing.Point(60, 38);
            this.cmbBoxTypes.Name = "cmbBoxTypes";
            this.cmbBoxTypes.PersistentColors = false;
            this.cmbBoxTypes.Size = new System.Drawing.Size(146, 21);
            this.cmbBoxTypes.TabIndex = 1;
            this.cmbBoxTypes.UseStyledColors = false;
            this.cmbBoxTypes.SelectedIndexChanged += new System.EventHandler(this.cmbBoxTypes_SelectedIndexChanged);
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(60, 9);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(283, 20);
            this.txtBoxName.TabIndex = 0;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(50, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Nazwa:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmPaymentAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 184);
            this.Controls.Add(this.kryptonPanelEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IsMdiContainer = true;
            this.Name = "FrmPaymentAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dodaj płatność / pakiet";
            this.Load += new System.EventHandler(this.FrmPaymentAdd_Load);
            this.kryptonPanelEx1.ResumeLayout(false);
            this.kryptonPanelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown numCount;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown numPrice;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private AC.ExtendedRenderer.Toolkit.KryptonComboBox cmbBoxTypes;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtBoxName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}