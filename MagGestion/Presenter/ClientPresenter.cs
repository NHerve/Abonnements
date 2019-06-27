using MagGestion.DataServices;
using MagGestion.DataServices.Interface;
using MagGestion.Helper;
using MagGestion.Helper.Interface;
using MagGestion.Model.Client;
using MagGestion.Model.Historique;
using MagGestion.View.Interface;
using RestSharp.Deserializers;
using System;
using System.Windows.Forms;

namespace MagGestion.Presenter
{
    public class ClientPresenter : BasePresenter
    {
        private readonly IClientView _view;
        private int IdClient;
        public ClientPresenter(IClientView view, ICacheService cache, IErrorLogger errorLogger, IDeserializer serializer) : base(cache, errorLogger, serializer)
        {
            _view = view;
            _view.CloseRequested += OnCloseRequested;
            _view.CreationHistoriqueRequested += OnCreationHistoriqueRequested;
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
            }
        }

        public void GetCustomer(int id)
        {
            Client client = new ClientDataService(_cache, _serializer, _errorLogger).GetClient(id) ?? new Client { Nom = "Test", Prenom = "TestPre", Mail = "Mail@mail.com", Birthday = DateTime.Now, Phone = "0785649752" };
            IdClient = client.Id;
            _view.Nom = client.Nom;
            _view.Prenom = client.Prenom;
            _view.Mail = client.Mail;
            _view.Telephone = client.Phone;
            _view.BirthDay = client.Birthday.ToShortDateString();
        }
    }
}
