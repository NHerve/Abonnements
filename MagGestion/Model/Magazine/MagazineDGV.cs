using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagGestion.Model.Magazine
{
    public class MagazineDGV
    {
        public MagazineDGV(int id, string titre, string numeroAnnée, string prixAnnuel)
        {
            Id = id;
            Titre = titre;
            NumeroAnnée = numeroAnnée;
            PrixAnnuel = prixAnnuel;
        }
        public int Id { get; set; }
        public string Titre { get; set; }
        public string NumeroAnnée { get; set; }
        public string PrixAnnuel { get; set; }

    }
}
