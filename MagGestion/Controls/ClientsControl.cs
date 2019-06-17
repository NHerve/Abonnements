using MagGestion.Forms;
using MagGestion.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace MagGestion.Controls
{
    public partial class ClientsControl : UserControl
    {
        public ClientsControl()
        {
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
            new ClientForm(this).Show();
        }

        private void DGVClients_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DGVClients.ClearSelection();
        }

        private void Initiialize()
        {
            List<Client> Clients = new List<Client>();
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

            var c = new BindingList<Client>(Clients);
            var source = new BindingSource(c, null);
            DGVClients.DataSource = source;
            DGVClients.Columns["Id"].Visible = false;
        }
    }
}
