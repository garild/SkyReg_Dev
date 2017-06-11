namespace DepartureDiagram
{
    partial class Departures
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Departures));
            this.kryptonPanelEx1 = new AC.ExtendedRenderer.Toolkit.KryptonPanelEx();
            this.groupListView = new AC.ExtendedRenderer.Toolkit.GroupableKryptonListView();
            this.kryptonPanelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanelEx1
            // 
            this.kryptonPanelEx1.Controls.Add(this.groupListView);
            this.kryptonPanelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanelEx1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.kryptonPanelEx1.GradientToogleColors = false;
            this.kryptonPanelEx1.GradientUseBlend = false;
            this.kryptonPanelEx1.Image = null;
            this.kryptonPanelEx1.ImageLocation = new System.Drawing.Point(4, 4);
            this.kryptonPanelEx1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanelEx1.Name = "kryptonPanelEx1";
            this.kryptonPanelEx1.PersistentColors = false;
            this.kryptonPanelEx1.Size = new System.Drawing.Size(1147, 524);
            this.kryptonPanelEx1.TabIndex = 0;
            // 
            // groupListView
            // 
            this.groupListView.AlternateRowColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.groupListView.AlternateRowColorEnabled = true;
            this.groupListView.AutoSizeLastColumn = true;
            this.groupListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupListView.EnableDragDrop = false;
            this.groupListView.EnableHeaderGlow = false;
            this.groupListView.EnableHeaderHotTrack = false;
            this.groupListView.EnableHeaderRendering = true;
            this.groupListView.EnableSelectionBorder = false;
            this.groupListView.EnableSorting = true;
            this.groupListView.EnableVistaCheckBoxes = true;
            this.groupListView.ForceLeftAlign = false;
            this.groupListView.FullRowSelect = true;
            this.groupListView.GroupLabelText = "Group by :";
            this.groupListView.GroupsGUIs = false;
            this.groupListView.ItemHeight = 0;
            this.groupListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.groupListView.LineAfter = -1;
            this.groupListView.LineBefore = -1;
            this.groupListView.Location = new System.Drawing.Point(0, 0);
            this.groupListView.Name = "groupListView";
            this.groupListView.OwnerDraw = true;
            this.groupListView.PersistentColors = false;
            this.groupListView.SelectEntireRowOnSubItem = true;
            this.groupListView.ShowGroupLabel = true;
            this.groupListView.Size = new System.Drawing.Size(1147, 524);
            this.groupListView.TabIndex = 0;
            this.groupListView.ToolStripImage = null;
            this.groupListView.UseCompatibleStateImageBehavior = false;
            this.groupListView.UseKryptonRenderer = true;
            this.groupListView.UseStyledColors = false;
            // 
            // Departures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 524);
            this.Controls.Add(this.kryptonPanelEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonGallery;
            this.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ButtonStandalone;
            this.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Calendar;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Departures";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wyloty";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.kryptonPanelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AC.ExtendedRenderer.Toolkit.KryptonPanelEx kryptonPanelEx1;
        private AC.ExtendedRenderer.Toolkit.GroupableKryptonListView groupListView;
    }
}