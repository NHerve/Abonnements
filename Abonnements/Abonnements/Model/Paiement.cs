using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abonnements.Model
{
    public class Paiement
    {
        public Paiement()
        {

        }
        [JsonProperty("uuid")]
        public int uuid { get; set; }
        [JsonProperty("cid")]
        public string cid { get; set; }
        [JsonProperty("cardNumber")]
        public string cardNumber { get; set; }
        [JsonProperty("cardMonth")]
        public int cardMonth { get; set; }
        [JsonProperty("cardYear")]
        public int cardYear { get; set; }
        [JsonProperty("amount")]
        public decimal amount { get; set; }
        [JsonProperty("transaction")]
        public string transaction { get; set; }
        [JsonProperty("paiFKAbo")]
        public int paiFKAbo { get; set; }
    }
}
