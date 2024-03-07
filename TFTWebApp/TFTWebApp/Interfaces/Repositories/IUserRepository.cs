using TFTWebApp.Models;

namespace TFTWebApp.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetApplicationUserAsync();
        Task<ApplicationUser> GetApplicationUserByIdAsync(string id);
        Task<ApplicationUser> GetApplicationUserByPersonIdAsync(int personId);
        Task<ApplicationUser> CreateApplicationUserAsync(ApplicationUser applicationUser);
        Task<bool> UpdateApplicationUserAsync(string id, ApplicationUser applicationUser);
        Task<bool> DeleteApplicationUserAsync(string id);
    }
}
