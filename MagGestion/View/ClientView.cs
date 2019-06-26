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

        public ClientPresenter Presenter { private get; set; }
        public string Nom { set => lbNom.Text = value; }
        public string Prenom { set => lbPrenom.Text = value; }
        public string Telephone { set => lbTelephone.Text = value; }
        public string Mail { set => lbMail.Text = value; }
        public string BirthDay { set => lbBirthday.Text = value; }
        public int Id { get; set; }
        public string Motif => TBMotif.Text;

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
    }
}
