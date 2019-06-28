using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbonnementsAPi.Models
{
    public class Paiement
    {
        public string uuid { get; set; }
        [Key]
        public string cid { get; set; }
        public string cardNumber { get; set; }
        public string cardMonth { get; set; }
        public string cardYear { get; set; }
        public decimal amount { get; set; }
        public string transaction { get; set; }
        [ForeignKey("paiFKAbo")]
        public int paiFKAbo { get; set; }
    }
}
