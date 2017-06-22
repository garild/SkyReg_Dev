namespace SkyReg.Common.Prints.LoadingList
{
    partial class LoadingListForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rvLoadingList = new Microsoft.Reporting.WinForms.ReportViewer();
            this.LLHeaderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LLItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LLHeaderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LLItemsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rvLoadingList
            // 
            this.rvLoadingList.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSetLLHeader";
            reportDataSource3.Value = this.LLHeaderBindingSource;
            reportDataSource4.Name = "DataSetLLItems";
            reportDataSource4.Value = this.LLItemsBindingSource;
            this.rvLoadingList.LocalReport.DataSources.Add(reportDataSource3);
            this.rvLoadingList.LocalReport.DataSources.Add(reportDataSource4);
            this.rvLoadingList.LocalReport.ReportEmbeddedResource = "SkyReg.Common.Prints.LoadingList.reportLoadingList.rdlc";
            this.rvLoadingList.Location = new System.Drawing.Point(0, 0);
            this.rvLoadingList.Name = "rvLoadingList";
            this.rvLoadingList.ServerReport.BearerToken = null;
            this.rvLoadingList.Size = new System.Drawing.Size(732, 407);
            this.rvLoadingList.TabIndex = 0;
            // 
            // LLHeaderBindingSource
            // 
            this.LLHeaderBindingSource.DataSource = typeof(SkyReg.Common.Prints.LoadingList.LLHeader);
            // 
            // LLItemsBindingSource
            // 
            this.LLItemsBindingSource.DataSource = typeof(SkyReg.Common.Prints.LoadingList.LLItems);
            // 
            // LoadingListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 407);
            this.Controls.Add(this.rvLoadingList);
            this.Name = "LoadingListForm";
            this.Text = "LoadingListForm";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LoadingListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LLHeaderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LLItemsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvLoadingList;
        private System.Windows.Forms.BindingSource LLHeaderBindingSource;
        private System.Windows.Forms.BindingSource LLItemsBindingSource;
    }
}