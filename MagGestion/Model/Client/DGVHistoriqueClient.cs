using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagGestion.Model.Client
{
    public class DGVHistoriqueClient
    {
        public DGVHistoriqueClient()
        {

        }

        [JsonProperty("hisMoyen")]
        public string Moyen { get; set; }

        [JsonProperty("hisMotif")]
        public string Motif { get; set; }

        [JsonProperty("hisDate")]
        public DateTime Date { get; set; }
    }
}
