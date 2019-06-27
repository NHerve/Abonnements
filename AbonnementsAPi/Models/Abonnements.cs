using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbonnementsAPi.Models
{
    public class Abonnements
    {

        [Key]
        public int aboId { get; set; }
        [ForeignKey("aboFKCli")]
        public int aboFKCli { get; set; }
        [ForeignKey("aboFKMag")]
        public int aboFKMag { get; set; }
        [Required]
        public DateTime aboDateDebut { get; set; }
        [Required]
        public DateTime aboDateFin { get; set; }
        public int aboStatus { get; set; }

        public Abonnements()
        {

        }
        public Abonnements(int idclient, int idmagazine)
        {
            aboFKCli = idclient;
            aboFKMag = idmagazine;
            aboDateDebut = DateTime.Now;
            aboDateFin = aboDateDebut.AddYears(1);
            aboStatus = 2;
        }

    }
}
