namespace TFTWebApp.Models.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string InitPassword { get; set; }
        public string Ime { get; set; }
        public string Prezime {  get; set; }
    }
}
