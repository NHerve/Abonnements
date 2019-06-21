using Abonnements.Helpers;
using Abonnements.Helpers.Interface;
using Abonnements.Model.Users;
using Abonnements.Services.Interfaces;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abonnements.DataServices
{
    public class UserDataService : BaseClient
    {
        public UserDataService(IDeserializer serializer, IErrorLogger errorLogger, IDialogService dialogService) : base(serializer, errorLogger, dialogService)
        {
            BaseUrl = new Uri(BaseUrl, Constant.ClientUrl);
        }

        public void PostUser(UserSignUp user)
        {
            RestRequest request = new RestRequest() { Method = Method.POST };
            request.AddJsonBody(user);

            Execute(request);
        }

        public UserProfile Connection(string login)
        {
            RestRequest request = new RestRequest($"{Constant.Authenticate}/{login}") { Method = Method.GET };
            return Get<UserProfile>(request);
        }
    }
}
