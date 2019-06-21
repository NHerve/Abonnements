using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace AbonnementsAPi.Models
{
    public class Clients
    {
        [Key]
        public int cliId { get; set; }
        //[Required]
        public string cliNom { get; set; }
        //[Required]
        public string cliPrenom { get; set; }
        [Required]
        public string cliPassword { get; set; }
        [Required]
        public string cliMail { get; set; }
        //[Required]
        public string cliPhone { get; set; }
        public DateTime? cliDateNaissance { get; set; }
        public string cliLieuNaissance { get; set; }
        public string cliNumCart { get; set; }
        public string cliExpiCarte { get; set; }
        public string cliCCV { get; set; }
        public string cliAuthKey { get; set; }
    }
}
