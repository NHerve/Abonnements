using MagGestion.Controls.Interface;
using MagGestion.DataServices;
using MagGestion.DataServices.Interface;
using MagGestion.Forms;
using MagGestion.Helper.Interface;
using MagGestion.Model.Magazine;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace MagGestion.Presenter
{
    public class MagazineControlPresenter : BasePresenter
    {
        public readonly IMagazineControl _control;

        //private readonly IClientView _view;
        //private readonly ClientDataService _clientDataService;
        //private readonly HistoriqueDataService _historiqueDataService;

        //private int IdClient;
        //public ClientPresenter(IClientView view, ICacheService cache, IErrorLogger errorLogger, IDeserializer serializer) : base(cache, errorLogger, serializer)
        //{
        //    _view = view;
        //    _view.CloseRequested += OnCloseRequested;
        //    _view.CreationHistoriqueRequested += OnCreationHistoriqueRequested;
        //    _clientDataService = new ClientDataService(_cache, _serializer, _errorLogger);
        //    _historiqueDataService = new HistoriqueDataService(_cache, _serializer, _errorLogger);
        //}


        public MagazineControlPresenter(IMagazineControl control, ICacheService cache, IErrorLogger errorLogger, IDeserializer serializer) : base(cache, errorLogger, serializer)
        {
            _control = control;
            _control.OnShowMagazineForm += OnShowMagazineForm;
            _control.MagazineSelected += OnCellSelected;
        }

        private void OnShowMagazineForm(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(_control.DataGridViewMagazine.SelectedRows[0].Cells["Id"].Value);
            new MagazineForm( (IControl)_control,_cache,_errorLogger, _serializer, id).Show();
        }
        private void OnCellSelected(object sender, EventArgs e)
        {
            _control.BTMag.Enabled = true;
        }

        public void FillDGV()
        {
            List<DGVMagazine> Magazines = new MagazineDataService(_cache, _serializer, _errorLogger).GetMagazines() ?? new List<DGVMagazine>();

            var h = new BindingList<DGVMagazine>(Magazines);
            _control.DataGridViewMagazine.DataSource = new BindingSource(h, null);
            _control.DataGridViewMagazine.Columns["Id"].Visible = false;
            _control.DataGridViewMagazine.Columns["NumeroAnnée"].HeaderText = "Numéro année";
            _control.DataGridViewMagazine.Columns["PrixAnnuel"].HeaderText = "Prix annuel";
        }
    }
}
