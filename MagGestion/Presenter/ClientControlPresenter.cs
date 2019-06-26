using MagGestion.Controls.Interface;
using MagGestion.DataServices;
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
            int id = Convert.ToInt32(_control.DataGridViewClient.SelectedRows[0].Cells["Id"].Value);
            try
            {

                new ClientForm(id, _control, _cache, _errorLogger, _serializer).Show();
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
            List<DGVClients> Clients = new ClientDataService(_cache, _serializer, _errorLogger).GetClients() ?? new List<DGVClients>();

            var c = new BindingList<DGVClients>(Clients);
            _control.DataGridViewClient.DataSource = new BindingSource(c, null);
            _control.DataGridViewClient.Columns["Id"].Visible = false;
        }
    }
}
