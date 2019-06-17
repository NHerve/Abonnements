using System;

namespace MagGestion.Model
{
    public class HistoriqueDataGridView
    {
        public HistoriqueDataGridView(int id, string nom, string prenom, string moyen, DateTime date)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Moyen = moyen;
            Date = date;
        }

        public int Id { get; set; }  // Id Client used to see fiche client

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Moyen { get; set; }

        public DateTime Date { get; set; }
    }
}
