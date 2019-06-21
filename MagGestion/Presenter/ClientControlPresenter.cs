using MagGestion.Controls.Interface;
using MagGestion.DataServices.Interface;
using MagGestion.Forms;
using MagGestion.Helper.Interface;
using MagGestion.Model.Client;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace MagGestion.Presenter
{
    public class ClientControlPresenter : BasePresenter
    {
        public readonly IClientControl _control;

        public ClientControlPresenter(IClientControl control, ICacheService cache, IErrorLogger errorLogger, IDeserializer serializer) : base(cache, errorLogger, serializer)
        {
            _control = control;
            _control.OnShowClientForm += OnShowClientForm;
            _control.ClientSelected += OnCellSelected;
        }

        private void OnShowClientForm(object sender, EventArgs e)
        {
            var id = _control.DataGridViewClient.SelectedRows[0].Cells["Id"].Value;
            try
            {

                new ClientForm(id.ToString(), _control, _cache, _errorLogger, _serializer).Show();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void OnCellSelected(object sender, EventArgs e)
        {
            _control.ButtonClient.Enabled = true;
        }

        public void FillDGV()
        {
            //  List<DGVClients> Clients = new ClientDataService(_cache, _serializer, _errorLogger).GetClients();
            List<DGVClients> Clients = new List<DGVClients>();
            Clients.Add(new DGVClients(1, "Steven", "Jeanne"));
            Clients.Add(new DGVClients(2, "Steven", "Jeanne"));
            Clients.Add(new DGVClients(3, "Steven", "Jeanne"));
            Clients.Add(new DGVClients(4, "Steven", "Jeanne"));
            Clients.Add(new DGVClients(5, "Steven", "Jeanne"));
            Clients.Add(new DGVClients(6, "Steven", "Jeanne"));
            Clients.Add(new DGVClients(2, "Steven", "Jeanne"));
            Clients.Add(new DGVClients(3, "Steven", "Jeanne"));
            Clients.Add(new DGVClients(4, "Steven", "Jeanne"));
            Clients.Add(new DGVClients(5, "Steven", "Jeanne"));
            Clients.Add(new DGVClients(6, "Steven", "Jeanne"));

            var c = new BindingList<DGVClients>(Clients);
            _control.DataGridViewClient.DataSource = new BindingSource(c, null);
            _control.DataGridViewClient.Columns["Id"].Visible = false;
        }
    }
}
