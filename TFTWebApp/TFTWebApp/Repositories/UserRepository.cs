using Microsoft.EntityFrameworkCore;
using TFTWebApp.Data;
using TFTWebApp.Interfaces.Repositories;
using TFTWebApp.Models;

namespace TFTWebApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TFTDbContext _context;

        public UserRepository(TFTDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ApplicationUser>> GetApplicationUserAsync()
        {
            return await _context.Set<ApplicationUser>().ToListAsync();
        }

        public async Task<ApplicationUser> GetApplicationUserByIdAsync(string id)
        {
            return await _context.Set<ApplicationUser>().FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<ApplicationUser> GetApplicationUserByPersonIdAsync(int personId)
        {
            return await _context.Set<ApplicationUser>().FirstOrDefaultAsync(f => f.PersonId == personId);
        }

        public async Task<ApplicationUser> CreateApplicationUserAsync(ApplicationUser applicationUser)
        {
            _context.Set<ApplicationUser>().Add(applicationUser);
            await _context.SaveChangesAsync();
            return applicationUser;
        }

        public async Task<bool> UpdateApplicationUserAsync(string id, ApplicationUser applicationUser)
        {
            var existingApplicationUser = await GetApplicationUserByIdAsync(id);

            if (existingApplicationUser == null)
            {
                return false;
            }

            existingApplicationUser.Email = applicationUser.Email;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteApplicationUserAsync(string id)
        {
            var applicationUserToDelete = await GetApplicationUserByIdAsync(id);

            if (applicationUserToDelete == null)
            {
                return false;
            }

            _context.Set<ApplicationUser>().Remove(applicationUserToDelete);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
