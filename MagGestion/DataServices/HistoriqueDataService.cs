using MagGestion.DataServices.Interface;
using MagGestion.Helper;
using MagGestion.Helper.Interface;
using MagGestion.Model.Historique;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;

namespace MagGestion.DataServices
{
    public class HistoriqueDataService : BaseClient
    {
        public HistoriqueDataService(ICacheService cache, IDeserializer serializer, IErrorLogger errorLogger) : base(cache, serializer, errorLogger)
        {
            BaseUrl = new Uri(BaseUrl, Constant.HistoriqueUrl);
        }


        public List<DGVHistorique> GetHistoriques()
        {
            RestRequest request = new RestRequest() { Method = Method.GET };
            request.AddHeader("content-type", "application/json");
            return Get<List<DGVHistorique>>(request);
        }

        public void CreateHistorique(Historique historique)
        {
            RestRequest request = new RestRequest() { Method = Method.POST };
            request.AddJsonBody(historique);

            Execute(request);
        }
    }
}
