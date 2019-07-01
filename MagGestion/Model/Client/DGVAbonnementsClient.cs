using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagGestion.Model.Client
{
    public class DGVAbonnementsClient
    {
        [JsonProperty("aboId")]
        public int AbonnementId { get; set; }


        [JsonProperty("aboFKMag")]
        public int MagId { get; set; }

        public string MagazineName { get; set; }

        [JsonProperty("aboStatus")]
        public StatusCode Status { get; set; }

        public string StatusFriendly { get; set; }

        public string Price { get; set; }

        [JsonProperty("aboDateFin")]
        public DateTime DateFin { get; set; }
    }
}
