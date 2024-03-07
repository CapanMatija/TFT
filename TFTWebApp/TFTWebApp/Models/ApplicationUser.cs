using Microsoft.AspNetCore.Identity;

namespace TFTWebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int RoleId { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
