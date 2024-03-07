using TFTWebApp.Models;

namespace TFTWebApp.Interfaces.Repositories
{
    public interface IFilmRepository
    {
        Task<IEnumerable<Film>> GetFilmsAsync();
        Task<Film> GetFilmByIdAsync(int id);
        Task<Film> CreateFilmAsync(Film film);
        Task<bool> UpdateFilmAsync(int id, Film film);
        Task<bool> DeleteFilmAsync(int id);
    }
}
