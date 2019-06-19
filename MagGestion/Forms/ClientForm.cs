using MagGestion.DataServices;
using MagGestion.DataServices.Interface;
using MagGestion.Helper.Interface;
using MagGestion.Model;
using MagGestion.Model.Client;
using RestSharp.Deserializers;
using System.Windows.Forms;

namespace MagGestion.Forms
{
    public partial class ClientForm : Form
    {
        private Control _control;

        private readonly string _id;
        private readonly ICacheService _cache;
        private readonly IErrorLogger _errorLogger;
        private readonly IDeserializer _serializer;

        public ClientForm(string id, Control control, ICacheService cache, IErrorLogger errorLogger, IDeserializer serializer)
        {
            _id = id;
            _cache = cache;
            _errorLogger = errorLogger;
            _serializer = serializer;
            InitializeComponent();
            _control = control;
            _control.Parent.Parent.Enabled = false;
            this.TopMost = true;
            this.CenterToScreen();
            Initialize();
        }

        private void BTQuit_click(object sender, System.EventArgs e)
        {
            _control.Parent.Parent.Enabled = true;

            this.Close();
        }

        private void Initialize()
        {
            Client client = new ClientDataService(_cache, _serializer, _errorLogger).GetClient(_id);
            lbNom.Text = client.Nom;
            lbPrenom.Text = client.Prenom;
            lbTelephone.Text = client.Phone;
            lbMail.Text = client.Mail;
            lbBirthday.Text = client.Birthday;
        }
    }
}
