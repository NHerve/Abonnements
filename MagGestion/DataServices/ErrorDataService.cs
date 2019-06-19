using MagGestion.DataServices.Deserializer;
using MagGestion.DataServices.Interface;
using MagGestion.Helper;
using MagGestion.Helper.Interface;
using MagGestion.Model.LogError;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagGestion.DataServices
{
    public class ErrorDataService : BaseClient
    {
        public ErrorDataService(ICacheService cache, IDeserializer serializer, IErrorLogger errorLogger) : base(cache, serializer, errorLogger)
        {
            BaseUrl = new Uri(BaseUrl, Constant.ErrorUrl);
        }

        public void PostError(Error error)
        {
            RestRequest request = new RestRequest() { Method = Method.POST };
            request.AddJsonBody(error);
            Execute(request);
        }
    }
}
