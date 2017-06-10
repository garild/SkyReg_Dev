using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SkyReg.Forms
{
    public partial class Examples : KryptonForm
    {
        int rowToDelete;
        List<DataGridViewRow> rw = new List<DataGridViewRow>();

        public Examples()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            kryptonDataGridView1.Columns.Add("name", "Name");
            dataGridView2.Columns.Add("name", "Name");
            kryptonDataGridView1.Rows.Add(5);
            kryptonDataGridView1.Rows[0].Cells[0].Value = "Garib";
            kryptonDataGridView1.Rows[1].Cells[0].Value = "Paweł";
            kryptonDataGridView1.Rows[2].Cells[0].Value = "Wojtek";
            kryptonDataGridView1.Rows[3].Cells[0].Value = "Aneta";
            kryptonDataGridView1.Rows[4].Cells[0].Value = "Jasio";
        }

        private void kryptonDataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            rowToDelete = (int)e.RowIndex;
            rw = new List<DataGridViewRow>();
            foreach (DataGridViewRow item in kryptonDataGridView1.SelectedRows)
            {
                rw.Add(kryptonDataGridView1.Rows[item.Index]);
                
            }
            kryptonDataGridView1.DoDragDrop(rw, DragDropEffects.Copy);

        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<DataGridViewRow>)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void dataGridView2_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<DataGridViewRow>)))
            {
                DataRow row;
                rw.ForEach(p =>
                {  
                    dataGridView2.Rows.Insert(dataGridView2.Rows.Count - 1, p.Cells[0].Value);
                    kryptonDataGridView1.Rows.RemoveAt(p.Index);

                });
                
            }
        }

    }
}
