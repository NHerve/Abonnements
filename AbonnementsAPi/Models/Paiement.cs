using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbonnementsAPi.Models
{
    public class Paiement
    {
        [Key]
        public int uuid { get; set; }
        public string cid { get; set; }
        public string cardNumber { get; set; }
        public int cardMonth { get; set; }
        public int cardYear { get; set; }
        public decimal amount { get; set; }
        public string transaction { get; set; }
    }
}
