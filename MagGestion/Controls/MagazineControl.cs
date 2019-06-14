using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MagGestion.Model.Magazine;
using MagGestion.Forms;

namespace MagGestion.Controls
{
    public partial class MagazineControl : UserControl
    {
        public MagazineControl()
        {
            InitializeComponent();
            Initialize();
        }

        private void DGVPublication_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BTMagazine.Enabled = true;
        }

        private void DGVPublication_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DGVPublication.ClearSelection();
        }

        private void BTMagazine_Click(object sender, EventArgs e)
        {
            var id = DGVPublication.SelectedRows[0].Cells["Id"].Value;
            new MagazineForm(this).Show();
        }

        private void Initialize()
        {
            List<MagazineDGV> Magazines = new List<MagazineDGV>();
            Magazines.Add(new MagazineDGV(1, "Le monde", "12", "45€"));
            Magazines.Add(new MagazineDGV(1, "Le gorafi", "5", "34€"));
            Magazines.Add(new MagazineDGV(1, "La provence", "24", "89€"));

            var h = new BindingList<MagazineDGV>(Magazines);
            DGVPublication.DataSource = new BindingSource(h, null);
            DGVPublication.Columns["Id"].Visible = false;
            DGVPublication.Columns["NumeroAnnée"].HeaderText = "Numéro année";
            DGVPublication.Columns["PrixAnnuel"].HeaderText = "Prix annuel";
        }
    }
}
