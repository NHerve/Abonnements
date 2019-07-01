using MagGestion.Controls.Interface;
using MagGestion.DataServices.Interface;
using MagGestion.Helper.Interface;
using MagGestion.Presenter;
using RestSharp.Deserializers;
using System;
using System.Windows.Forms;

namespace MagGestion.Controls
{
    public partial class HistoriqueControl : UserControl, IHistoriqueControl
    {
        private readonly ICacheService _cache;
        private readonly IErrorLogger _errorLogger;
        private readonly IDeserializer _serializer;
        public HistoriqueControl(ICacheService cache, IErrorLogger errorLogger, IDeserializer serializer)
        {
            _cache = cache;
            _errorLogger = errorLogger;
            _serializer = serializer;
            InitializeComponent();
        }

        public HistoriqueControlPresenter Presenter { private get; set; }
        public DataGridView DataGridViewHistorique { get => DGVHistorique; set => DGVHistorique = value; }
        public Button ButtonClient { get => BTClient; set => BTClient = value; }

        public event EventHandler HistoriqueSelected;
        public event EventHandler OnShowClientForm;

        private void BTClient_Click(object sender, EventArgs e)
        {
            OnShowClientForm(this, EventArgs.Empty);
        }

        private void DGVHistorique_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HistoriqueSelected(this, EventArgs.Empty);

        }

        private void DGVHistorique_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DGVHistorique.ClearSelection();
        }

        private void HistoriqueControl_Load(object sender, EventArgs e)
        {
            Presenter = new HistoriqueControlPresenter(this, _cache, _errorLogger, _serializer);
            Presenter.FillDGV();
        }

        void IControl.Load()
        {
            throw new NotImplementedException();
        }
    }
}
