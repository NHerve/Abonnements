using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abonnements.Helpers.Interface
{
    public interface IErrorLogger
    {
        void LogError(Exception ex, string infoMessage);
    }
}
