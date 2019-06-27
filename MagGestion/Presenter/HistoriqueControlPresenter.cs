using MagGestion.Controls.Interface;
using MagGestion.DataServices;
using MagGestion.DataServices.Interface;
using MagGestion.Forms;
using MagGestion.Helper;
using MagGestion.Helper.Interface;
using MagGestion.Model.Client;
using MagGestion.Model.Historique;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace MagGestion.Presenter
{
    public class HistoriqueControlPresenter : BasePresenter
    {
        public readonly IHistoriqueControl _control;

        public HistoriqueControlPresenter(IHistoriqueControl control, ICacheService cache, IErrorLogger errorLogger, IDeserializer serializer) : base(cache, errorLogger, serializer)
        {
            _control = control;
            _control.OnShowClientForm += OnShowClientForm;
            _control.HistoriqueSelected += OnCellSelected;
        }

        private void OnShowClientForm(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(_control.DataGridViewHistorique.SelectedRows[0].Cells["ClientId"].Value);
            new ClientForm(id, _control, _cache, _errorLogger, _serializer).Show();
        }
        private void OnCellSelected(object sender, EventArgs e)
        {
            _control.ButtonClient.Enabled = true;
        }

        public void FillDGV()
        {
            List<DGVHistorique> Historiques = new HistoriqueDataService(_cache, _serializer, _errorLogger).GetAllHistoriquesOfEmp(Constant.CurrentEmploye.Id) ?? new List<DGVHistorique>();
            ClientDataService clientDataService = new ClientDataService(_cache, _serializer, _errorLogger);
            foreach (DGVHistorique his in Historiques)
            {
                Client cli = clientDataService.GetClient(his.ClientId);
                if(cli != null)
                {
                    his.Prenom = cli.Prenom;
                    his.Nom = cli.Nom;
                }
            }
            var h = new BindingList<DGVHistorique>(Historiques);
            _control.DataGridViewHistorique.DataSource = new BindingSource(h, null);
            if(Historiques.Count > 0)
                _control.DataGridViewHistorique.Columns["ClientId"].Visible = false;
        }
    }
}
