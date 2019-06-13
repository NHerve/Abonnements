using System;
using System.Collections.Generic;
using System.Text;

namespace Abonnements.Model
{
    public class Magazine : BaseModel
    {
        public string Titre { get; set; }
        public int NbVolumeAnnee { get; set; }
        public string PhotoCouverture { get; set; }
        public string Description { get; set; }
        public decimal PrixAnnuel { get; set; }
    }
}
