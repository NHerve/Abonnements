using MagGestion.DataServices;
using MagGestion.DataServices.Deserializer;
using MagGestion.Helper.Interface;
using MagGestion.Model.LogError;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagGestion.Helper
{
    public class ErrorLogger : IErrorLogger
    {
        public void LogError(Exception ex, string infoMessage)
        {
            Error error = new Error(ex.Message);
            new ErrorDataService(new InMemoryCache(), new JsonSerializer(), new ErrorLogger()).PostError(error);
        }
    }
}
