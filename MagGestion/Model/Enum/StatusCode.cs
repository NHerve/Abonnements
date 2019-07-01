using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagGestion.Model
{
    public enum StatusCode
    {
        [Description("Expiré")]
        Expired = 0,
        [Description("En cours")]
        OnGoing = 1,
        [Description("En attente")]
        Pending = 2,
        [Description("En pause")]
        Paused = 3
    }
}
