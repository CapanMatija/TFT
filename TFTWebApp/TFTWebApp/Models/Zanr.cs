namespace TFTWebApp.Models
{
    public class Zanr
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<FilmZanr> FilmZanrovi { get; set; }
    }
}