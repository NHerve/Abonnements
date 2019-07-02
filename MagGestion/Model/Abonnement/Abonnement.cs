using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagGestion.Model.Abonnement
{
    public class Abonnement
    {
  
        public int aboId { get; set; }
     
        public int aboFKCli { get; set; }
      
        public int aboFKMag { get; set; }
  
        public DateTime aboDateDebut { get; set; }
    
        public DateTime aboDateFin { get; set; }

        public int aboStatus { get; set; }

    }
}
