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
               RestRequest request = new RestRequest($"{Constant.AbonnementClientUrl}{id}") { Method = Method.GET };

            return Get<List<Abonnement>>(request);
        }

        //Get Non-Abonnement User
        public List<Magazine> GetNonAbonnements(int id)
        {
            RestRequest request = new RestRequest($"{Constant.NonAbonnementClientUrl }{id}") { Method = Method.GET };
            return Get<List<Magazine>>(request);
        }

        //Delete Abonnement
        public bool Delete(Magazine magazine)
        {
            RestRequest request = new RestRequest($"{magazine.Id}") { Method = Method.PUT };
            return Execute<Magazine>(request).StatusCode == System.Net.HttpStatusCode.OK;
        }
        //Pause Abonnement
        public bool Pause(Magazine magazine)
        {
            RestRequest request = new RestRequest($"{magazine.Id}") { Method = Method.PUT };
            //change abonnement.status
            return Execute<Magazine>(request).StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}
