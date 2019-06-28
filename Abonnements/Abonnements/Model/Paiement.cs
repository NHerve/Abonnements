using Abonnements.Helpers;
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

        public Paiement(string cardNumber, string cardMonth, string cardYear, decimal amount)
        {
            this.uuid = Constant.UUID;
            this.cid = Guid.NewGuid().ToString();
            this.cardNumber = cardNumber;
            this.cardMonth = cardMonth;
            this.cardYear = cardYear;
            this.amount = amount;
        }

        [JsonProperty("uuid")]
        public string uuid { get; set; }
        [JsonProperty("cid")]
        public string cid { get; set; }
        [JsonProperty("cardNumber")]
        public string cardNumber { get; set; }
        [JsonProperty("cardMonth")]
        public string cardMonth { get; set; }
        [JsonProperty("cardYear")]
        public string cardYear { get; set; }
        [JsonProperty("amount")]
        public decimal amount { get; set; }
        [JsonProperty("transaction")]
        public string transaction { get; set; }
        [JsonProperty("paiFKAbo")]
        public int paiFKAbo { get; set; }

        [JsonIgnore]
        public string Titre { get; set; }

        [JsonIgnore]
        public int IdMagazine { get; set; }
    }
}
