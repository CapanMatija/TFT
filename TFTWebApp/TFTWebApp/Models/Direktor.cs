namespace TFTWebApp.Models
{
    public class Direktor : Person
    {
        public ICollection<Film> Filmovi { get; set; }

        public Direktor(Person person) : base(person.Ime, person.Prezime, person.Email) 
        {
            Filmovi = new List<Film>();
        }

        public Direktor(string ime, string prezime, string email) : base(ime, prezime, email)
        {
            Filmovi = new List<Film>();
        }
    }
}
