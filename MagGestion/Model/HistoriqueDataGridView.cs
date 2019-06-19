using System;

namespace MagGestion.Model
{
    public class HistoriqueDataGridView
    {
        public HistoriqueDataGridView(int id, string nom, string prenom, string moyen, string motif, DateTime date)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Moyen = moyen;
            Motif = motif;
            Date = date;
        }

        public int Id { get; set; }  // Id Client used to see fiche client

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Moyen { get; set; }

        public string Motif { get; set; }

        public DateTime Date { get; set; }
    }
}
