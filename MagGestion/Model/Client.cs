namespace MagGestion.Model
{
    public class Client
    {

        public Client() { }

        public Client(int id, string nom, string prenom)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
    }
}
