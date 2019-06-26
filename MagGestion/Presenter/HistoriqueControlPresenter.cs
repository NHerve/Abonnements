using MagGestion.Controls.Interface;
using MagGestion.DataServices;
using MagGestion.DataServices.Interface;
using MagGestion.Forms;
using MagGestion.Helper;
using MagGestion.Helper.Interface;
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
            int id = Convert.ToInt32(_control.DataGridViewHistorique.SelectedRows[0].Cells["Id"].Value);
            new ClientForm(id, _control, _cache, _errorLogger, _serializer).Show();
        }
        private void OnCellSelected(object sender, EventArgs e)
        {
            _control.ButtonClient.Enabled = true;
        }

        public void FillDGV()
        {
            List<DGVHistorique> Historique = new HistoriqueDataService(_cache, _serializer, _errorLogger).GetAllHistoriquesOfEmp(Constant.CurrentEmploye.Id) ?? new List<DGVHistorique>();

            Historique.Add(new DGVHistorique(1, "Steven", "Jeanne", "Mail", "Impayé", DateTime.Now.AddMonths(-2)));
            Historique.Add(new DGVHistorique(1, "Steven", "Jeanne", "Sms", "Impayé", DateTime.Now.AddMonths(-1)));
            Historique.Add(new DGVHistorique(1, "Steven", "Jeanne", "Telephone", "Proposition", DateTime.Now.AddDays(-2)));
            Historique.Add(new DGVHistorique(1, "Steven", "Jeanne", "Sms", "Technique", DateTime.Now.AddDays(-1)));
            Historique.Add(new DGVHistorique(1, "Steven", "Jeanne", "Sms", "Proposition", DateTime.Now));

            var h = new BindingList<DGVHistorique>(Historique);
            _control.DataGridViewHistorique.DataSource = new BindingSource(h, null);
            _control.DataGridViewHistorique.Columns["Id"].Visible = false;
        }
    }
}
