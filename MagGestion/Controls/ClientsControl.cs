using MagGestion.Controls.Interface;
using MagGestion.DataServices.Interface;
using MagGestion.Helper.Interface;
using MagGestion.Presenter;
using RestSharp.Deserializers;
using System;
using System.Windows.Forms;

namespace MagGestion.Controls
{
    public partial class ClientsControl : UserControl, IClientControl
    {
        public ClientControlPresenter Presenter { private get; set; }
        public DataGridView DataGridViewClient { get => DGVClients; set => DGVClients = value; }
        public Button ButtonClient { get => BTClient; set => BTClient = value; }
        
        private readonly ICacheService _cache;
        private readonly IErrorLogger _errorLogger;
        private readonly IDeserializer _serializer;
        public ClientsControl(ICacheService cache, IErrorLogger errorLogger, IDeserializer serializer)
        {
            _cache = cache;
            _errorLogger = errorLogger;
            _serializer = serializer;
            InitializeComponent();
        }

        public event EventHandler ClientSelected;
        public event EventHandler OnShowClientForm;

        private void DGVClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClientSelected(this, EventArgs.Empty);
        }

        private void BTClient_Click(object sender, System.EventArgs e)
        {
            OnShowClientForm(this, EventArgs.Empty);
        }

        private void DGVClients_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DGVClients.ClearSelection();
        }
        private void ClientsControl_Load(object sender, EventArgs e)
        {
            Presenter = new ClientControlPresenter(this, _cache, _errorLogger, _serializer);
            Presenter.FillDGV();

        }

        public bool Equals(ClientsControl other)
        {
            throw new NotImplementedException();
        }

        void IControl.Load()
        {
            throw new NotImplementedException();
        }
    }
}
