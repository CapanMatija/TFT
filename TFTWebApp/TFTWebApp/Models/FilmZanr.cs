namespace TFTWebApp.Models
{
    public class FilmZanr
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }

        public int ZanrId { get; set; }
        public Zanr Zanr { get; set; }
    }
}
