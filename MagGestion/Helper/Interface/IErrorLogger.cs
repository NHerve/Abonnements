using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagGestion.Helper.Interface
{
    public interface IErrorLogger
    {
        void LogError(Exception ex, string infoMessage);
    }
}
