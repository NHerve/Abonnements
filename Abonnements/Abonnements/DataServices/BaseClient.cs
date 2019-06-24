using Abonnements.DataServices.Deserializer;
using Abonnements.Helpers;
using Abonnements.Helpers.Interface;
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
    public class BaseClient : RestClient
    {
        protected IErrorLogger _errorLogger;
        protected readonly IDialogService _dialogService;
        public BaseClient(IDeserializer serializer, IErrorLogger errorLogger, IDialogService dialogService)
        {
            _errorLogger = errorLogger;
            _dialogService = dialogService;
            AddHandler("application/json", () => serializer);
            AddHandler("text/json", () => serializer);
            AddHandler("text/x-json", () => serializer);
            BaseUrl = new Uri(Constant.BaseUrl);
        }

        public override IRestResponse Execute(IRestRequest request)
        {
            if(Settings.CurrentUser != null)
            {
                request.AddHeader("Authorization", Settings.CurrentUser.Auth_key);
            }
            if(request.Method == Method.POST)
            {
                request.JsonSerializer = new JsonSerializer();
            }
            var response = base.Execute(request);
            TimeoutCheck(request, response);
            return response;
        }
        public override IRestResponse<T> Execute<T>(IRestRequest request)
        {
            if (Settings.CurrentUser != null)
            {
                request.AddHeader("Authorization", Settings.CurrentUser.Auth_key);
            }
            if (request.Method == Method.POST)
            {
                request.JsonSerializer = new JsonSerializer();
            }
            var response = base.Execute<T>(request);
            TimeoutCheck(request, response);
            return response;
        }

        public T Get<T>(IRestRequest request) where T : new()
        {
            var response = Execute<T>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return response.Data;
            }
            else
            {
                if (response.StatusCode != 0)
                {
                    LogError(BaseUrl, request, response);
                }
                else
                {

                _dialogService.ShowAlertAsync("Serveur inaccessible", "Problème avec le serveur", "Oups !");
                }
                return default(T);
            }
        }

        private void LogError(Uri BaseUrl, IRestRequest request, IRestResponse response)
        {
            //Get the values of the parameters passed to the API
            string parameters = string.Join(", ", request.Parameters.Select(x => x.Name.ToString() + "=" + ((x.Value == null) ? "NULL" : x.Value)).ToArray());

            //Set up the information message with the URL, the status code, and the parameters.
            string info = "Request to " + BaseUrl.AbsoluteUri + request.Resource + " failed with status code " + response.StatusCode + ", parameters: "
                + parameters + ", and content: " + response.Content;

            //Acquire the actual exception
            Exception ex;
            if (response != null && response.ErrorException != null)
            {
                ex = response.ErrorException;
            }
            else
            {
                ex = new Exception(info);
                info = string.Empty;
            }

            //Log the exception and info message
            _errorLogger.LogError(ex, info);
        }

        private void TimeoutCheck(IRestRequest request, IRestResponse response)
        {
            if (response.StatusCode == 0)
            {
                //LogError(BaseUrl, request, response);
            }
        }
    }
}
