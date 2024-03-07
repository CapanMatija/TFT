using TFTWebApp.Models.DTOs;

namespace TFTWebApp.Interfaces.Services
{
    public interface IZanrService
    {
        Task<IEnumerable<ZanrDTO>> GetGenresAsync();
        Task<ZanrDTO> GetGenreByIdAsync(int id);
        Task<ZanrDTO> CreateGenreAsync(ZanrDTO zanrDTO);
        Task<bool> UpdateGenreAsync(int id, ZanrDTO zanrDTO);
        Task<bool> DeleteGenreAsync(int id);
    }
}
