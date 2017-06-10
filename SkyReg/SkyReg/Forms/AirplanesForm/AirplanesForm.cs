using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer;
using SkyRegEnums;

namespace SkyReg
{
    public partial class AirplanesForm : KryptonForm
    {
        public AirplanesForm()
        {
            InitializeComponent();
        }

        private void AirplanesForm_Load(object sender, EventArgs e)
        {
            RefreshAirplanesList();
        }

        //private void ParentFormSizeFromParentsWorkSpaceSize()
        //{
        //    Size s = new Size();
        //    s.Height = this.Parent.Size.Height-10;
        //    s.Width = this.Parent.Size.Width-10;
        //    this.Size = s;
        //    this.StartPosition = FormStartPosition.Manual;
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)//TODO Kod Janusza
        {
            AirPlanesFormAddEdit apf = new AirPlanesFormAddEdit(FormState.Add, null);
            apf.MdiParent = this.ParentForm;
            apf.RefreshAirplanesGridEH += AddedEditedAirplane;
            apf.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e) //TODO Kod Janusza
        {
            if(grdAirplanes.SelectedRows.Count > 0)
            {
                int airplaneId = (int)grdAirplanes.SelectedRows[0].Cells["Id"].Value;
                AirPlanesFormAddEdit apf = new AirPlanesFormAddEdit(FormState.Edit, airplaneId);
                apf.MdiParent = this.ParentForm;
                apf.RefreshAirplanesGridEH += AddedEditedAirplane;
                apf.Show();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteAirplanes();
        }

        private void DeleteAirplanes()
        {
            if (grdAirplanes.SelectedRows.Count > 0)
            {
                if (KryptonMessageBox.Show("Czy chcesz usunąć zaznaczone samoloty?", "Usunąć?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (DLModelContainer model = new DLModelContainer())
                    {
                        List<int> listaId = new List<int>();
                        foreach (DataGridViewRow airplane in grdAirplanes.SelectedRows)
                            listaId.Add((int)airplane.Cells["Id"].Value);

                        List<Airplane> airplanes = model.Airplane.Where(p => listaId.Contains(p.Id)).ToList();
                        model.Airplane.RemoveRange(airplanes);
                        model.SaveChanges();
                        RefreshAirplanesList();
                    }
                }
            }
        }

        private void AddedEditedAirplane(object sender, EventArgs e)
        {
            RefreshAirplanesList();
        }

        private void RefreshAirplanesList()
        {
            using (DLModelContainer model = new DLModelContainer())
            {
                grdAirplanes.DataSource = model.Airplane.Select(p => p).OrderBy(p => p.Name).ToList();
                SetViewOfAirplanesGrid();
            }
        }

        private void SetViewOfAirplanesGrid()
        {
            grdAirplanes.Columns["Id"].Visible = false;
            grdAirplanes.Columns["Name"].Visible = true;
            grdAirplanes.Columns["RegNr"].Visible = true;
            grdAirplanes.Columns["Seats"].Visible = true;
            grdAirplanes.Columns["Flight"].Visible = false;
            grdAirplanes.Columns["RegNr"].Width = 300;
            grdAirplanes.Columns["Seats"].Width = 200;
            grdAirplanes.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grdAirplanes.Columns["RegNr"].HeaderText = "Nr rejestracyjny";
            grdAirplanes.Columns["Name"].HeaderText = "Nazwa samolotu";
            grdAirplanes.Columns["Seats"].HeaderText = "Ilość miejsc";

            grdAirplanes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdAirplanes.AllowUserToResizeRows = false;
            grdAirplanes.ReadOnly = true;
        }
    }
}
