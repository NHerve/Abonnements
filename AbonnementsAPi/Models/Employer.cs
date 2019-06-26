using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbonnementsAPi.Models
{
    public class Employer
    {
        [Key]
        public int empId { get; set; }
        //[Required]
        public string empLogin { get; set; }
        //[Required]
        public string empPassword { get; set; }

        public string empAuthKey { get; set; }
    }
}
