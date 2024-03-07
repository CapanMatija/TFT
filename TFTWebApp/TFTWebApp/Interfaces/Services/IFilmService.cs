using TFTWebApp.Models.DTOs;

namespace TFTWebApp.Interfaces.Services
{
    public interface IFilmService
    {
        Task<IEnumerable<FilmDTO>> GetFilmsAsync();
        Task<FilmDTO> GetFilmByIdAsync(int id);
        Task<FilmDTO> CreateFilmAsync(FilmDTO filmDTO);
        Task<bool> UpdateFilmAsync(int id, FilmDTO filmDTO);
        Task<bool> DeleteFilmAsync(int id);
    }
}
