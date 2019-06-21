using Abonnements.Helpers;
using Abonnements.Helpers.Interface;
using Abonnements.Model;
using Abonnements.Services.Interfaces;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abonnements.DataServices
{
    public class ErrorDataService : BaseClient
    {
        public ErrorDataService(IDeserializer serializer, IErrorLogger errorLogger, IDialogService dialogService) : base(serializer, errorLogger, dialogService)
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
