using Newtonsoft.Json;
using System;

namespace MagGestion.Model.Historique
{
    public class Historique
    {
        public Historique()
        {

        }

        public Historique(int idClient, int idEmp, string moyen, string motif, DateTime date)
        {
            IdClient = idClient;
            IdEmp = idEmp;
            Moyen = moyen;
            Motif = motif;
            Date = date;
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
