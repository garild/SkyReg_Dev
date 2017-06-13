namespace SkyReg
{
    partial class Examples2
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonPanelEx1 = new AC.ExtendedRenderer.Toolkit.KryptonPanelEx();
            this.kryptonPanelEx2 = new AC.ExtendedRenderer.Toolkit.KryptonPanelEx();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.kryptonPanelEx1.SuspendLayout();
            this.kryptonPanelEx2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.kryptonPanelEx2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.kryptonPanelEx1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(488, 316);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // kryptonPanelEx1
            // 
            this.kryptonPanelEx1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanelEx1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.kryptonPanelEx1.GradientToogleColors = false;
            this.kryptonPanelEx1.GradientUseBlend = false;
            this.kryptonPanelEx1.Image = null;
            this.kryptonPanelEx1.ImageLocation = new System.Drawing.Point(4, 4);
            this.kryptonPanelEx1.Location = new System.Drawing.Point(3, 3);
            this.kryptonPanelEx1.Name = "kryptonPanelEx1";
            this.kryptonPanelEx1.PersistentColors = false;
            this.kryptonPanelEx1.Size = new System.Drawing.Size(238, 310);
            this.kryptonPanelEx1.TabIndex = 0;
            // 
            // kryptonPanelEx2
            // 
            this.kryptonPanelEx2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanelEx2.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.kryptonPanelEx2.GradientToogleColors = false;
            this.kryptonPanelEx2.GradientUseBlend = false;
            this.kryptonPanelEx2.Image = null;
            this.kryptonPanelEx2.ImageLocation = new System.Drawing.Point(4, 4);
            this.kryptonPanelEx2.Location = new System.Drawing.Point(247, 3);
            this.kryptonPanelEx2.Name = "kryptonPanelEx2";
            this.kryptonPanelEx2.PersistentColors = false;
            this.kryptonPanelEx2.Size = new System.Drawing.Size(238, 310);
            this.kryptonPanelEx2.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(31, 54);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(47, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "panel1";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(38, 54);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(47, 20);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "panel2";
            // 
            // Examples2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 431);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Examples2";
            this.Text = "Examples2";
            this.Load += new System.EventHandler(this.Examples2_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.kryptonPanelEx1.ResumeLayout(false);
            this.kryptonPanelEx1.PerformLayout();
            this.kryptonPanelEx2.ResumeLayout(false);
            this.kryptonPanelEx2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx2;
        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}