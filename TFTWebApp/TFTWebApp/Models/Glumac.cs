namespace TFTWebApp.Models
{
    public class Glumac : Person
    {
        public decimal OcekivaniHonorar { get; set; }

        public ICollection<FilmGlumac> FilmGlumci { get; set; }

        public Glumac(Person person) : this(person, 0) { }

        public Glumac(Person person, decimal ocekivaniHonorar) : base(person.Ime, person.Prezime, person.Email)
        {
            OcekivaniHonorar = ocekivaniHonorar;
            FilmGlumci = new List<FilmGlumac>();
        }

        public Glumac(string ime, string prezime, string email, decimal ocekivaniHonorar) : base(ime, prezime, email)
        {
            OcekivaniHonorar = ocekivaniHonorar;
            FilmGlumci = new List<FilmGlumac>();
        }
    }
}
