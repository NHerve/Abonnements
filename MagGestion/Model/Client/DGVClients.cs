using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagGestion.Model.Client
{
    public class DGVClients
    {
        public DGVClients() { }

        public DGVClients(int id, string nom, string prenom)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
        }

        [JsonProperty(PropertyName = "cliId")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "cliNom")]
        public string Nom { get; set; }

        [JsonProperty(PropertyName = "cliPrenom")]
        public string Prenom { get; set; }
    }
}
