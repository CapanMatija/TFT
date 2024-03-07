namespace TFTWebApp.Models.DTOs
{
    public class FilmDTO
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Opis { get; set; }
        public int Trajanje {  get; set; }
        public decimal Budzet { get; set; }
        public DateTime PocetakSnimanja { get; set; }
        public DateTime KrajSnimanja { get; set; }
        public int DirektorId { get; set; }
        public List<ZanrDTO> Zanrovi { get; set; }
    }
}
