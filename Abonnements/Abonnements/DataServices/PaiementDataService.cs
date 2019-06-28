using Abonnements.Helpers;
using Abonnements.Helpers.Interface;
using Abonnements.Model;
using Abonnements.Services.Interfaces;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

namespace Abonnements.DataServices
{
    public class PaiementDataService : BaseClient
    {
        public PaiementDataService(IDeserializer serializer, IErrorLogger errorLogger, IDialogService dialogService) : base(serializer, errorLogger, dialogService)
        {
            BaseUrl = new Uri(BaseUrl, Constant.PaiementUrl);
        }

        public bool RequestPaiement(Paiement paiement, int idMagazine)
        {
            RestRequest request = new RestRequest($"{Constant.PaiementRequestUrl}{Settings.CurrentUser.Id}/{idMagazine}") { Method = Method.POST };
            request.AddJsonBody(paiement);

            return Execute(request).StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}
