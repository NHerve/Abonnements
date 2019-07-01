using MagGestion.DataServices.Interface;
using MagGestion.Helper;
using MagGestion.Helper.Interface;
using MagGestion.Model.Client;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagGestion.DataServices
{
    public class AbonnementDataService : BaseClient
    {
        public AbonnementDataService(ICacheService cache, IDeserializer serializer, IErrorLogger errorLogger) : base(cache, serializer, errorLogger)
        {
            BaseUrl = new Uri(BaseUrl, Constant.AbonnementUrl);
        }


        public List<DGVAbonnementsClient> GetAllAbonnementsOfCli(int id)
        {
            RestRequest request = new RestRequest($"{Constant.ClientUrl}{id}") { Method = Method.GET };

            return Get<List<DGVAbonnementsClient>>(request);
        }
    }
}
