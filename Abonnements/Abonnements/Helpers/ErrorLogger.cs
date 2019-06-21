using Abonnements.DataServices;
using Abonnements.DataServices.Deserializer;
using Abonnements.Helpers.Interface;
using Abonnements.Model;
using Abonnements.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abonnements.Helpers
{
    public class ErrorLogger : IErrorLogger
    {
        public void LogError(Exception ex, string infoMessage)
        {
            Error error = new Error(ex.Message);
            new ErrorDataService(new JsonSerializer(), new ErrorLogger(), new DialogService()).PostError(error);
        }
    }
}
