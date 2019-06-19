using MagGestion.DataServices;
using MagGestion.DataServices.Interface;
using MagGestion.Forms;
using MagGestion.Helper.Interface;
using MagGestion.Model;
using MagGestion.Model.Client;
using RestSharp.Deserializers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace MagGestion.Controls
{
    public partial class ClientsControl : UserControl
    {
        private readonly ICacheService _cache;
        private readonly IErrorLogger _errorLogger;
        private readonly IDeserializer _serializer;

        public ClientsControl(ICacheService cache, IErrorLogger errorLogger, IDeserializer serializer)
        {
            _cache = cache;
            _errorLogger = errorLogger;
            _serializer = serializer;
            InitializeComponent();
            Initiialize();
        }

        private void DGVClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BTClient.Enabled = true;
        }

        private void BTClient_Click(object sender, System.EventArgs e)
        {
            var id = DGVClients.SelectedRows[0].Cells["Id"].Value;
            new ClientForm(id.ToString(), this, _cache, _errorLogger, _serializer).Show();
        }

        private void DGVClients_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DGVClients.ClearSelection();
        }

        private void Initiialize()
        {
            List<DGVClients> Clients = new ClientDataService(_cache, _serializer, _errorLogger).GetClients();
          /*  List<Client> Clients = new List<Client>();
            Clients.Add(new Client(1, "Steven", "Jeanne"));
            Clients.Add(new Client(2, "Steven", "Jeanne"));
            Clients.Add(new Client(3, "Steven", "Jeanne"));
            Clients.Add(new Client(4, "Steven", "Jeanne"));
            Clients.Add(new Client(5, "Steven", "Jeanne"));
            Clients.Add(new Client(6, "Steven", "Jeanne"));
            Clients.Add(new Client(2, "Steven", "Jeanne"));
            Clients.Add(new Client(3, "Steven", "Jeanne"));
            Clients.Add(new Client(4, "Steven", "Jeanne"));
            Clients.Add(new Client(5, "Steven", "Jeanne"));
            Clients.Add(new Client(6, "Steven", "Jeanne"));
            */
            var c = new BindingList<DGVClients>(Clients);
            var source = new BindingSource(c, null);
            DGVClients.DataSource = source;
            DGVClients.Columns["Id"].Visible = false;
        }
    }
}
