using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SkyReg
{
    public partial class ScheduleForm : KryptonForm
    {
        public ScheduleForm()
        {
            InitializeComponent();
        }


        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            GetLoadData();
        }

        #region Test



        private void GetLoadData()
        {
            grdOrders.Columns.Add("name", "Name");
            grdPlaner.Columns.Add("name", "Name");
            grdOrders.Rows.Add(5);
            grdOrders.Rows[0].Cells[0].Value = "Garib";
            grdOrders.Rows[1].Cells[0].Value = "Paweł";
            grdOrders.Rows[2].Cells[0].Value = "Wojtek";
            grdOrders.Rows[3].Cells[0].Value = "Aneta";
            grdOrders.Rows[4].Cells[0].Value = "Jasio";
        }


      

        int rowToDelete;
        List<DataGridViewRow> rw = new List<DataGridViewRow>();

        private void grdPlaner_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<DataGridViewRow>)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void grdPlaner_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<DataGridViewRow>)))
            {
                int rowCount = 0;
                rw.ForEach(p =>
                {
                    rowCount = grdPlaner.Rows.Count;
                    grdPlaner.Rows.Insert(rowCount > 0 ? rowCount - 1: rowCount, p.Cells[0].Value); //TODO otworzyć formatkę i dodać dane
                    grdOrders.Rows.RemoveAt(p.Index);

                });

            }
        }

        private void grdOrders_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            rowToDelete = (int)e.RowIndex;
            rw = new List<DataGridViewRow>();
            foreach (DataGridViewRow item in grdOrders.SelectedRows)
            {
                rw.Add(grdOrders.Rows[item.Index]);

            }
            grdOrders.DoDragDrop(rw, DragDropEffects.Copy);
        }

        #endregion

        private void btnCopyRecord_Click(object sender, EventArgs e)
        {
            if(grdOrders.SelectedRows.Count > 0)
            {
                int rowCount = 0;
                foreach (DataGridViewRow p in grdOrders.SelectedRows)
                {
                    rowCount = grdPlaner.Rows.Count;
                    grdPlaner.Rows.Insert(rowCount > 0 ? rowCount - 1 : rowCount, p.Cells[0].Value);
                    grdOrders.Rows.RemoveAt(p.Index);
                }
                    

            }
        }

        private void btnRightCopyRecord_Click(object sender, EventArgs e)
        {
            if (grdPlaner.SelectedRows.Count > 0)
            {
                int rowCount = 0;
                foreach (DataGridViewRow p in grdPlaner.SelectedRows)
                {
                    rowCount = grdOrders.Rows.Count;
                    grdOrders.Rows.Insert(rowCount > 0 ? rowCount - 1 : rowCount, p.Cells[0].Value);
                    grdPlaner.Rows.RemoveAt(p.Index);
                }


            }
        }
    }
}
