using Abonnements.Helper;
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

        public UserSignUp SignUp(UserSignUp user)
        {
            RestRequest request = new RestRequest() { Method = Method.POST };
            request.AddJsonBody(user);

            return Get<UserSignUp>(request);
        }

        public bool Update(UserProfile profile)
        {
            RestRequest request = new RestRequest($"{profile.Id}") { Method = Method.PUT };
            request.AddJsonBody(profile);

            if (Execute(request).StatusCode == System.Net.HttpStatusCode.NoContent)
                return true;

            return false;

        }

        public UserProfile Login(UserConnection userConnection)
        {
            RestRequest request = new RestRequest($"{Constant.Authenticate}") { Method = Method.POST };
            request.AddJsonBody(userConnection);
            return Get<UserProfile>(request);
        }
    }
}
