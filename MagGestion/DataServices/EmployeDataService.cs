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
            BaseUrl = new Uri(BaseUrl, Constant.EmployerUrl);
        }

        public void PostEmploye(Employe employe)
        {
            RestRequest request = new RestRequest() { Method = Method.POST };
            request.AddJsonBody(employe);

            Execute(request);
        }

        public Employe GetEmploye(string login)
        {
            RestRequest request = new RestRequest($"{Constant.LoginUrl}/{login}") { Method = Method.GET };
            return Get<Employe>(request);
        }
    }
}
