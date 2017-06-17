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
using DataLayer.Result.Repository;
using SkyReg.Common.Extensions;

namespace SkyReg
{
    public partial class ParachutesForm : KryptonForm
    {
        #region Konstruktory

        public ParachutesForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Metody prywatne

        //private void ParentFormSizeFromParentsWorkSpaceSize()
        //{
        //    Size s = new Size();
        //    s.Height = this.Parent.Size.Height - 10;
        //    s.Width = this.Parent.Size.Width - 10;
        //    this.Size = s;
        //    this.StartPosition = FormStartPosition.Manual;
        //}

        private void SetParachuteListView()
        {
            grdParachute.Columns["Id"].Visible = false;
            grdParachute.Columns["IdNr"].Visible = true;
            grdParachute.Columns["Name"].Visible = true;
            grdParachute.Columns["RentValue"].Visible = true;
            grdParachute.Columns["AssemblyValue"].Visible = true;
            grdParachute.Columns["OwnerName"].Visible = true;
            grdParachute.Columns["UserId"].Visible = false;

            grdParachute.Columns["IdNr"].Width = 150;
            grdParachute.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grdParachute.Columns["RentValue"].Width = 150;
            grdParachute.Columns["AssemblyValue"].Width = 150;
            grdParachute.Columns["OwnerName"].Width = 300;

            grdParachute.Columns["IdNr"].HeaderText = "Numer idetyfikacyjny";
            grdParachute.Columns["Name"].HeaderText = "Nazwa spadochronu";
            grdParachute.Columns["RentValue"].HeaderText = "Koszt wypożyczenia";
            grdParachute.Columns["AssemblyValue"].HeaderText = "Koszt układania";
            grdParachute.Columns["OwnerName"].HeaderText = "Nazwisko i imię właściciela";

            grdParachute.Columns["RentValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdParachute.Columns["AssemblyValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grdParachute.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdParachute.AllowUserToResizeRows = false;
            grdParachute.ReadOnly = true;
        }

        private void RefreshParachuteList()
        {
            using (var _context = new SkyRegContextRepository<Parachute>())
            {
                grdParachute.DataSource = _context
                    .GetAll(Tuple.Create(nameof(User),"","")).Value
                    .Select(p => new
                    {
                        Id = p.Id,
                        IdNr = p.IdNr,
                        Name = p.Name,
                        AssemblyValue = p.AssemblyValue.Value,
                        RentValue = p.RentValue.Value,
                        OwnerName = p.User != null ? p.User.Name : string.Empty,
                        UserId = p.User != null ? p.User.Id : -1
                    })
                    .OrderBy(p => p.IdNr)
                    .ToList();

                grdParachute.Refresh();
            }
        }

        #endregion

        #region Zdarzenia

        private void ParachutesForm_Load(object sender, EventArgs e)
        {
            RefreshParachuteList();
            SetParachuteListView();
        }

        private void btnAdd_Click(object sender, EventArgs e) //TODO Kod Janusza
        {
            _parachuteFormAddEdit = FormsOpened<ParachuteFormAddEdit>.IsShowDialog(_parachuteFormAddEdit);
            _parachuteFormAddEdit.FormClosed += _parachuteFormAddEdit_FormClosed;
            _parachuteFormAddEdit._formState = FormState.Add;
            _parachuteFormAddEdit._parachuteId = 0;
            if (_parachuteFormAddEdit.ShowDialog() == DialogResult.OK)
                RefreshParachuteList();
        }
       
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grdParachute.SelectedRows.Count > 0)
            {
                int parId = (int)grdParachute.SelectedRows[0].Cells["Id"].Value;
                _parachuteFormAddEdit = FormsOpened<ParachuteFormAddEdit>.IsShowDialog(_parachuteFormAddEdit);
                _parachuteFormAddEdit.FormClosed += _parachuteFormAddEdit_FormClosed;
                _parachuteFormAddEdit._formState = FormState.Edit;
                _parachuteFormAddEdit._parachuteId = parId;
               
                if (_parachuteFormAddEdit.ShowDialog() == DialogResult.OK)
                    RefreshParachuteList();
            }
        }

        private void _parachuteFormAddEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parachuteFormAddEdit = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grdParachute.SelectedRows.Count > 0)
            {
                int parId = (int)grdParachute.SelectedRows[0].Cells["Id"].Value;
                using (var _parachute = new SkyRegContextRepository<Parachute>())
                {
                    if (KryptonMessageBox.Show("Usunąć zaznaczoną pozycję?", "Usunąć?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var par = _parachute.GetAll().Value.Where(p => p.Id == parId).FirstOrDefault();
                        if (par != null)
                        {
                            _parachute.Delete(par);
                            RefreshParachuteList();
                        }
                    }
                }
            }
        }

        #endregion

        private ParachuteFormAddEdit _parachuteFormAddEdit = null;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
