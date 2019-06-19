using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp.Deserializers;

namespace MagGestion.Model.Magazine
{
    public class DGVMagazine
    {
        private string prixAnnuel;

        public DGVMagazine()
        {

        }
        public DGVMagazine(int id, string titre, string numeroAnnée, string prixAnnuel)
        {
            Id = id;
            Titre = titre;
            NumeroAnnée = numeroAnnée;
            PrixAnnuel = prixAnnuel+"€";
        }
        [JsonProperty("magId")]
        public int Id { get; set; }

        [JsonProperty("magTitre")]
        public string Titre { get; set; }

        [JsonProperty("magNbVolumeAnnee")]
        public string NumeroAnnée { get; set; }

        [JsonProperty("magPrixAnnuel")]
        public string PrixAnnuel { get { return $"{prixAnnuel}€"; } set
            {
                prixAnnuel = value;
            }
        }

    }
}
