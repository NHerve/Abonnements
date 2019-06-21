using Newtonsoft.Json;
using System;

namespace MagGestion.Model.Historique
{
    public class Historique
    {
        public Historique()
        {

        }

        [JsonProperty("hisFKCli")]
        public int IdClient { get; set; }

        [JsonProperty("hisFKEmp")]
        public int IdEmp { get; set; }

        [JsonProperty("hisMoyen")]
        public string Moyen { get; set; }

        [JsonProperty("hisMotif")]
        public string Motif { get; set; }

        [JsonProperty("hisDate")]
        public DateTime Date { get; set; }
    }
}
