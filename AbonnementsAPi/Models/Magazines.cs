using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AbonnementsAPi.Models
{
    public class Magazines
    {
        [Key]
        public int magId { get; set; }
        [Required]
        public string magTitre { get; set; }
        [Required]
        public int magNbVolumeAnnee { get; set; }
        public string magPhotoCouverture { get; set; }
        [Required]
        public string magDescription { get; set; }
        [Required]
        public decimal magPrixAnnuel { get; set; }
    }
}
