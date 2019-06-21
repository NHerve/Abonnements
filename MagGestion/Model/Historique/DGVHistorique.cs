using Newtonsoft.Json;
using System;

namespace MagGestion.Model.Historique
{
    public class DGVHistorique
    {
        public DGVHistorique(int id, string nom, string prenom, string moyen, string motif, DateTime date)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Moyen = moyen;
            Motif = motif;
            Date = date;
        }

        [JsonProperty(PropertyName = "cliId")]
        public int Id { get; set; }  // Id Client used to see fiche client

        [JsonProperty("cliNom")]
        public string Nom { get; set; }

        [JsonProperty(PropertyName = "cliPrenom")]
        public string Prenom { get; set; }

        [JsonProperty("")]
        public string Moyen { get; set; }

        [JsonProperty("")]
        public string Motif { get; set; }

        [JsonProperty("")]
        public DateTime Date { get; set; }
    }
}
