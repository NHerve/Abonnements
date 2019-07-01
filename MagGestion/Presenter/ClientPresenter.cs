using MagGestion.DataServices;
using MagGestion.DataServices.Interface;
using MagGestion.Helper;
using MagGestion.Helper.Interface;
using MagGestion.Model;
using MagGestion.Model.Client;
using MagGestion.Model.Historique;
using MagGestion.Model.Magazine;
using MagGestion.View.Interface;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace MagGestion.Presenter
{
    public class ClientPresenter : BasePresenter
    {
        private readonly IClientView _view;
        private readonly ClientDataService _clientDataService;
        private readonly HistoriqueDataService _historiqueDataService;
        private readonly AbonnementDataService _abonnementDataService;

        private int IdClient;
        public ClientPresenter(IClientView view, ICacheService cache, IErrorLogger errorLogger, IDeserializer serializer) : base(cache, errorLogger, serializer)
        {
            _view = view;
            _view.CloseRequested += OnCloseRequested;
            _view.CreationHistoriqueRequested += OnCreationHistoriqueRequested;
            _clientDataService = new ClientDataService(_cache, _serializer, _errorLogger);
            _abonnementDataService = new AbonnementDataService(_cache, _serializer, _errorLogger);
            _historiqueDataService= new HistoriqueDataService(_cache, _serializer, _errorLogger);


        }

        public void OnCloseRequested(object sender, EventArgs e)
        {
            _view.Close();
        }
        public void OnCreationHistoriqueRequested(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            HistoriqueDataService historiqueDataService = new HistoriqueDataService(_cache, _serializer, _errorLogger);
            string moyen = "";
            switch (bt.Name)
            {
                case "BTCourrier":
                    moyen = "Courrier";
                    break;
                case "BTTelephone":
                    moyen = "Telephone";
                    break;
                case "BTMail":
                    moyen = "Mail";
                    break;
                default:
                    MessageBox.Show("Erreur lors de la tentative");
                    break;
            }
            if (!string.IsNullOrEmpty(moyen))
            {
               bool insert = historiqueDataService.CreateHistorique(new Historique(_view.Id, Constant.CurrentEmploye.Id, moyen, _view.Motif, DateTime.Now));
                if (insert)
                    MessageBox.Show("Insertion réussie");
                _view.Close();
            }
        }

        public void GetCustomer(int id)
        {
            Client client = _clientDataService.GetClient(id) ?? new Client { Nom = "Test", Prenom = "TestPre", Mail = "Mail@mail.com", Birthday = DateTime.Now, Phone = "0785649752" };
            IdClient = client.Id;
            _view.Nom = client.Nom;
            _view.Prenom = client.Prenom;
            _view.Mail = client.Mail;
            _view.Telephone = client.Phone;
            _view.BirthDay = client.Birthday.ToShortDateString();
        }

        public void FillDGV(int id)
        {
            List<DGVHistoriqueClient> HistoriquesClient = _historiqueDataService.GetAllHistoriquesOfCli(id) ?? new List<DGVHistoriqueClient>();

            var h = new BindingList<DGVHistoriqueClient>(HistoriquesClient);
            _view.DataGridViewHistorique.DataSource = new BindingSource(h, null);

            List<DGVAbonnementsClient> AbonnementsClients = _abonnementDataService.GetAllAbonnementsOfCli(id) ?? new List<DGVAbonnementsClient>();
            var magDataService = new MagazineDataService(_cache, _serializer, _errorLogger);
            foreach (DGVAbonnementsClient abo in AbonnementsClients)
            {
                Magazine mag = magDataService.GetMagazine(abo.MagId);
                abo.Price = mag.PrixAnnuel.ToString();
                abo.MagazineName = mag.Titre;
                abo.StatusFriendly = ((StatusCode)abo.Status).GetDescription();
            }
            var a = new BindingList<DGVAbonnementsClient>(AbonnementsClients);
            _view.DataGridViewClient.DataSource = new BindingSource(a, null);
            _view.DataGridViewClient.Columns["AbonnementId"].Visible = false;
            _view.DataGridViewClient.Columns["Status"].Visible = false;

            _view.DataGridViewClient.Columns["MagId"].Visible = false;

            _view.DataGridViewClient.Columns["MagazineName"].HeaderText = "Titre";
            _view.DataGridViewClient.Columns["StatusFriendly"].HeaderText = "Etat";

            _view.DataGridViewClient.Columns["Price"].HeaderText = "Prix";
            _view.DataGridViewClient.Columns["DateFin"].HeaderText = "Date de fin";
        }

        private void StatusCodeToString(int code)
        {

        }
    }
}
