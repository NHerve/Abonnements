using MagGestion.Forms;
using MagGestion.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace MagGestion.Controls
{
    public partial class HistoriqueControl : UserControl
    {
        public HistoriqueControl()
        {
            InitializeComponent();
            Initiialize();
        }

        private void BTClient_Click(object sender, EventArgs e)
        {
            var id = DGVHistorique.SelectedRows[0].Cells["Id"].Value;
            new ClientForm(this).Show();
        }

        private void DGVHistorique_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BTClient.Enabled = true;
        }

        private void DGVHistorique_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DGVHistorique.ClearSelection();
        }

        private void Initiialize()
        {
            List<HistoriqueDataGridView> Historique = new List<HistoriqueDataGridView>();
            Historique.Add(new HistoriqueDataGridView(1, "Steven", "Jeanne", "Mail", DateTime.Now.AddMonths(-2)));
            Historique.Add(new HistoriqueDataGridView(1, "Steven", "Jeanne", "Sms", DateTime.Now.AddMonths(-1)));
            Historique.Add(new HistoriqueDataGridView(1, "Steven", "Jeanne", "Telephone", DateTime.Now.AddDays(-2)));
            Historique.Add(new HistoriqueDataGridView(1, "Steven", "Jeanne", "Sms", DateTime.Now.AddDays(-1)));
            Historique.Add(new HistoriqueDataGridView(1, "Steven", "Jeanne", "Sms", DateTime.Now));

            var h = new BindingList<HistoriqueDataGridView>(Historique);
            DGVHistorique.DataSource = new BindingSource(h, null);
            DGVHistorique.Columns["Id"].Visible = false;
        }
    }
}
