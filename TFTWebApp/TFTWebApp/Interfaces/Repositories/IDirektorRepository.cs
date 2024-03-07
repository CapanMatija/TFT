using TFTWebApp.Models;

namespace TFTWebApp.Interfaces.Repositories
{
    public interface IDirektorRepository
    {
        Task<IEnumerable<Direktor>> GetDirectorsAsync();
        Task<Direktor> GetDirectorByIdAsync(int id);
        Task<Direktor> CreateDirectorAsync(Direktor direktor);
        Task<bool> UpdateDirectorAsync(int id, Direktor direktor);
        Task<bool> DeleteDirectorAsync(int id);
    }
}
