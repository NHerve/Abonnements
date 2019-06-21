using MagGestion.DataServices.Interface;
using MagGestion.Helper.Interface;
using MagGestion.Model.Client;
using MagGestion.View.Interface;
using RestSharp.Deserializers;
using System;

namespace MagGestion.Presenter
{
    public class ClientPresenter : BasePresenter
    {
        private readonly IClientView _view;
        public ClientPresenter(IClientView view, ICacheService cache, IErrorLogger errorLogger, IDeserializer serializer) : base(cache, errorLogger, serializer)
        {
            _view = view;
            _view.CloseRequested += OnCloseRequested;
        }

        public void OnCloseRequested(object sender, EventArgs e)
        {
            _view.Close();
        }
        public void OnCreationHistoriqueRequested(object sender, EventArgs e)
        {

        }

        public void GetCustomer(string id)
        {
            Client client = new Client { Nom = "Test", Prenom = "TestPre", Mail = "Mail@mail.com", Birthday = DateTime.Now.ToShortDateString(), Phone = "0785649752" };
            //Client client = new ClientDataService(_cache, _serializer, _errorLogger).GetClient(id);
            _view.Nom = client.Nom;
            _view.Prenom = client.Prenom;
            _view.Mail = client.Mail;
            _view.Telephone = client.Phone;
            _view.BirthDay = client.Birthday;
        }
    }
}
