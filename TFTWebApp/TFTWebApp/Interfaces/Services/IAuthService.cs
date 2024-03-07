using TFTWebApp.Models;

namespace TFTWebApp.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string> AuthenticateAsync(string username, string password);
        Task<ApplicationUser> RegisterUserAsync(ApplicationUser appUser, string password);
    }
}
