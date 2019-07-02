using MagGestion.Controls.Interface;
using MagGestion.DataServices.Interface;
using MagGestion.Helper.Interface;
using MagGestion.Presenter;
using MagGestion.View.Interface;
using RestSharp.Deserializers;
using System;
using System.Windows.Forms;

namespace MagGestion.Forms
{
    public partial class ClientForm : Form, IClientView
    {
        private IControl _control;

        private readonly ICacheService _cache;
        private readonly IErrorLogger _errorLogger;
        private readonly IDeserializer _serializer;

        public event EventHandler CloseRequested;
        public event EventHandler CreationHistoriqueRequested;
        public event EventHandler OnSuspendAbonnement;
        public event EventHandler OnRepayAbonnement;

        public ClientPresenter Presenter { private get; set; }
        public string Nom { set => lbNom.Text = value; }
        public string Prenom { set => lbPrenom.Text = value; }
        public string Telephone { set => lbTelephone.Text = value; }
        public string Mail { set => lbMail.Text = value; }
        public string BirthDay { set => lbBirthday.Text = value; }
        public int Id { get; set; }
        public string Motif => TBMotif.Text;

        public DataGridView DataGridViewHistorique { get => DGVHistoriqueClient; set => DGVHistoriqueClient = value; }
        public DataGridView DataGridViewClientAbonnement { get => DGVAbonnementsClient; set => DGVAbonnementsClient = value; }

        public ClientForm(int id, IControl control, ICacheService cache, IErrorLogger errorLogger, IDeserializer serializer)
        {
            Id = id;
            _cache = cache;
            _errorLogger = errorLogger;
            _serializer = serializer;
            InitializeComponent();
            _control = control;
            _control.Parent.Parent.Enabled = false;
            this.TopMost = true;
            this.CenterToScreen();
        }

        private void BTQuit_click(object sender, System.EventArgs e)
        {
            _control.Parent.Parent.Enabled = true;
            CloseRequested(this, EventArgs.Empty);
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            Presenter = new ClientPresenter(this, _cache, _errorLogger, _serializer);
            Presenter.GetCustomer(Id);
            Presenter.FillDGV(Id);
        }

        private void BTCourrier_Click(object sender, EventArgs e)
        {
            CreationHistoriqueRequested(sender, e);
        }

        private void BTMail_Click(object sender, EventArgs e)
        {
            CreationHistoriqueRequested(sender, e);

        }

        private void BTTelephone_Click(object sender, EventArgs e)
        {
            CreationHistoriqueRequested(sender, e);

        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _control.Parent.Parent.Enabled = true;
            _control.Parent.Parent.Focus();
        }

        private void BTSuspendre_Click(object sender, EventArgs e)
        {
            OnSuspendAbonnement(sender, EventArgs.Empty);
        }

        private void BTRembourser_Click(object sender, EventArgs e)
        {
            OnRepayAbonnement(sender, EventArgs.Empty);
        }
    }
}
