using Newtonsoft.Json;
using System;

namespace MagGestion.Model.Client
{
    public class Client
    {

        public Client() { }

        public Client(int id, string nom, string prenom)
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

        [JsonProperty(PropertyName = "cliMail")]
        public string Mail { get; set; }

        [JsonProperty(PropertyName = "cliPhone")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "cliDateNaissance")]
        public DateTime Birthday { get; set; }
    }
}
