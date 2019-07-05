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
    public class MagazineDataService : BaseClient
    {
        public MagazineDataService (IDeserializer serializer, IErrorLogger errorLogger, IDialogService dialogService) : base(serializer, errorLogger, dialogService)
        {
            BaseUrl = new Uri(BaseUrl, Constant.MagazineUrl);
        }
        
        public Magazine GetMagazine(int id)
        {
            RestRequest request = new RestRequest($"{id}") { Method = Method.GET };
            return Get<Magazine>(request);
        }

     
    }
}
