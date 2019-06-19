using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbonnementsAPi.Models
{
    public class Historique
    {
        [Key]
        public int hisId { get; set; }
        [ForeignKey("hisFKCli")]
        public int hisFKCli { get; set; }
        [ForeignKey("hisFKEmp")]
        public int hisFKEmp { get; set; }
        [Required]
        public DateTime hisDate { get; set; }
        [Required]
        public string hisMoyen { get; set; }
        [Required]
        public string hisMotif { get; set; }
    }
}
