using MagGestion.DataServices.Interface;
using MagGestion.Helper;
using MagGestion.Helper.Interface;
using MagGestion.Model.Client;
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


        public List<DGVHistorique> GetAllHistoriquesOfEmp(int id)
        {
            RestRequest request = new RestRequest($"{Constant.EmployerUrl}{id}") { Method = Method.GET };

            return Get<List<DGVHistorique>>(request);
        }
        public List<DGVHistoriqueClient> GetAllHistoriquesOfCli(int id)
        {
            RestRequest request = new RestRequest($"{Constant.ClientUrl}{id}") { Method = Method.GET };

            return Get<List<DGVHistoriqueClient>>(request);
        }
        public bool CreateHistorique(Historique historique)
        {
            RestRequest request = new RestRequest() { Method = Method.POST };
            request.AddJsonBody(historique);

            return Execute(request).StatusCode == System.Net.HttpStatusCode.Created ? true : false;
        }
    }
}
