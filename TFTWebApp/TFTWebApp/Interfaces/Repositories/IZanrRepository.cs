using TFTWebApp.Models;

namespace TFTWebApp.Interfaces.Repositories
{
    public interface IZanrRepository
    {
        Task<IEnumerable<Zanr>> GetGenresAsync();
        Task<Zanr> GetGenreByIdAsync(int id);
        Task<Zanr> CreateGenreAsync(Zanr zanr);
        Task<bool> UpdateGenreAsync(int id, Zanr zanr);
        Task<bool> DeleteGenreAsync(int id);
    }
}
