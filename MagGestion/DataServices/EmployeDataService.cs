using MagGestion.DataServices.Deserializer;
using MagGestion.DataServices.Interface;
using MagGestion.Helper;
using MagGestion.Helper.Interface;
using MagGestion.Model.Employe;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagGestion.DataServices
{
    public class EmployeDataService : BaseClient
    {
        public EmployeDataService(ICacheService cache, IDeserializer serializer, IErrorLogger errorLogger) : base(cache, serializer, errorLogger)
        {
            BaseUrl = new Uri(BaseUrl, Constant.EmployersUrl);
        }

        public void PostEmploye(Employe employe)
        {
            RestRequest request = new RestRequest() { Method = Method.POST };
            request.AddJsonBody(employe);

            Execute(request);
        }

        public Employe Authenticate(Employe employe)
        {
            RestRequest request = new RestRequest($"{Constant.LoginUrl}") { Method = Method.POST };
            request.AddJsonBody(employe);
            return Get<Employe>(request);
        }
    }
}
