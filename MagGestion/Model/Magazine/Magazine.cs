using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagGestion.Model.Magazine
{
    public class Magazine
    {
        public Magazine()
        {

        }

        [JsonProperty("magTitre")]
        public string Titre { get; set; }

        [JsonProperty("magDescription")]
        public string Description { get; set; }

        [JsonProperty("magPrixAnnuel")]
        public decimal PrixAnnuel { get; set; }

        [JsonProperty("magNbVolumeAnnee")]
        public int NumeroAnnée { get; set; }

    }
}
