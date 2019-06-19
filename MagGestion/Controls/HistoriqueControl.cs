using MagGestion.DataServices.Interface;
using MagGestion.Forms;
using MagGestion.Helper.Interface;
using MagGestion.Model;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace MagGestion.Controls
{
    public partial class HistoriqueControl : UserControl
    {
        private readonly ICacheService _cache;
        private readonly IErrorLogger _errorLogger;
        private readonly IDeserializer _serializer;

        public HistoriqueControl(ICacheService cache, IErrorLogger errorLogger, IDeserializer serializer)
        {
            InitializeComponent();
            _cache = cache;
            _errorLogger = errorLogger;
            _serializer = serializer;
            Initiialize();
        }

        private void BTClient_Click(object sender, EventArgs e)
        {
            var id = DGVHistorique.SelectedRows[0].Cells["Id"].Value;
            new ClientForm(id.ToString(), this, _cache, _errorLogger, _serializer).Show();
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
            Historique.Add(new HistoriqueDataGridView(1, "Steven", "Jeanne", "Mail", "Impayé", DateTime.Now.AddMonths(-2)));
            Historique.Add(new HistoriqueDataGridView(1, "Steven", "Jeanne", "Sms", "Impayé", DateTime.Now.AddMonths(-1)));
            Historique.Add(new HistoriqueDataGridView(1, "Steven", "Jeanne", "Telephone", "Proposition", DateTime.Now.AddDays(-2)));
            Historique.Add(new HistoriqueDataGridView(1, "Steven", "Jeanne", "Sms", "Technique", DateTime.Now.AddDays(-1)));
            Historique.Add(new HistoriqueDataGridView(1, "Steven", "Jeanne", "Sms", "Proposition", DateTime.Now));

            var h = new BindingList<HistoriqueDataGridView>(Historique);
            DGVHistorique.DataSource = new BindingSource(h, null);
            DGVHistorique.Columns["Id"].Visible = false;
        }
    }
}
