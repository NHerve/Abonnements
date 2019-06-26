using MagGestion.DataServices.Deserializer;
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
    public class ClientDataService : BaseClient
    {
        public ClientDataService(ICacheService cache, IDeserializer serializer, IErrorLogger errorLogger) : base(cache, serializer, errorLogger)
        {
            BaseUrl = new Uri(BaseUrl, Constant.ClientsUrl);
        }
        public List<DGVClients> GetClients()
        {
            RestRequest request = new RestRequest() { Method = Method.GET };
            
            return Get <List<DGVClients>>(request);
        }

        public Client GetClient(int id)
        {
            RestRequest request = new RestRequest($"{id}") { Method = Method.GET };
            return GetFromCache<Client>(request, "user"+id);
        }

      
    }
}
