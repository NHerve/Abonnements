using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbonnementsAPi.Models
{
    public class Log
    {
        [Key]
        public int logId { get; set; }
        [Required]
        public string logDescription { get; set; }
        [Required]
        public DateTime logDate { get; set; }
    }
}
