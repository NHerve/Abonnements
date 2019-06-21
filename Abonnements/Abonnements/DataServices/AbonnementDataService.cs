using Abonnements.Helpers;
using Abonnements.Helpers.Interface;
using Abonnements.Model;
using Abonnements.Services.Interfaces;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abonnements.DataServices
{
    public class AbonnementDataService : BaseClient
    {
        public AbonnementDataService(IDeserializer serializer, IErrorLogger error, IDialogService dialogService) : base(serializer, error, dialogService)
        {
            BaseUrl = new Uri(BaseUrl, Constant.AbonnementUrl);
        }

        //Get Abonnement User
        public List<Abonnement> GetAbonnements(int id)
        {
               RestRequest request = new RestRequest(string.Format(Constant.AbonnementClientUrl, id)) { Method = Method.GET };
            // RestRequest request = new RestRequest() { Method = Method.GET };

            return Get<List<Abonnement>>(request);
        }

        //Get Non-Abonnement User
        public List<Abonnement> GetNonAbonnements(int id)
        {
            RestRequest request = new RestRequest(string.Format(Constant.NonAbonnementClientUrl, id)) { Method = Method.GET };
            return Get<List<Abonnement>>(request);
        }

        //Subscribe Abonnement

        //Delete Abonnement

        //Pause Abonnement
    }
}
