using Abonnements.DataServices.Base;
using Abonnements.DataServices.Interface;
using Abonnements.Helpers;
using Abonnements.Model.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Abonnements.DataServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRequestProvider _requestProvider;

        public bool IsAuthenticated => !string.IsNullOrEmpty(Settings.AccessToken);

        public AuthenticationService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<bool> LoginAsync(string userMail, string password)
        {
           var auth = new AuthenticationRequest
            {
                UserMail = userMail,
                Credentials = password,
                GrantType = "password"
            };

            UriBuilder builder = new UriBuilder(Settings.AuthUrl);
            builder.Path = "api/login";

            string uri = builder.ToString();

            AuthenticationResponse authenticationInfo = await _requestProvider.PostAsync<AuthenticationRequest, AuthenticationResponse>(uri, auth);
            Settings.UserId = authenticationInfo.UserId;
            Settings.ProfileId = authenticationInfo.ProfileId;
            Settings.AccessToken = authenticationInfo.AccessToken;
            
            return true;
        }

        public Task LogoutAsync()
        {
            Settings.RemoveUserId();
            Settings.RemoveProfileId();
            Settings.RemoveAccessToken();

            return Task.FromResult(false);
        }

        public int GetCurrentUserId()
        {
            return Settings.UserId;
        }
    }
}
