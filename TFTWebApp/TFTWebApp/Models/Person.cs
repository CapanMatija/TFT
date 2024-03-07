using System.Xml.Linq;

namespace TFTWebApp.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }

        public Person() { }
        public Person(string ime, string prezime, string email)
        {
            Ime = ime;
            Prezime = prezime;
            Email = email;
        }
    }
}
