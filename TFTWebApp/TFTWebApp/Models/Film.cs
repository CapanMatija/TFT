namespace TFTWebApp.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Opis { get; set; }
        public DateTime PocetakSnimanja { get; set; }
        public DateTime KrajSnimanja { get; set; }
        public decimal Budzet { get; set; }
        public int Trajanje { get; set; }

        public int DirektorId { get; set; }
        public Direktor Direktor { get; set; }

        public ICollection<FilmGlumac> FilmGlumci { get; set; }

        public ICollection<FilmZanr> FilmZanrovi { get; set; }
    }
}
