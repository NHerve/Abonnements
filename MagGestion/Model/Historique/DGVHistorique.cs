using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MagGestion.Model.Historique
{
    public class DGVHistorique
    {
        public DGVHistorique()
        {

        }
        public DGVHistorique(int id, string nom, string prenom, string moyen, string motif, DateTime date)
        {
            ClientId = id;
            Nom = nom;
            Prenom = prenom;
            Moyen = moyen;
            Motif = motif;
            Date = date;
        }

        [JsonProperty(PropertyName = "hisFKCli")]
        public int ClientId { get; set; }
        
        public string Nom { get; set; }

        public string Prenom { get; set; }

        [JsonProperty("hisMoyen")]
        public string Moyen { get; set; }

        [JsonProperty("hisMotif")]
        public string Motif { get; set; }

        [JsonProperty("hisDate")]
        public DateTime Date { get; set; }
    }
}
