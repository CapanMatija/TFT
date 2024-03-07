using TFTWebApp.Models.DTOs;

namespace TFTWebApp.Interfaces.Services
{
    public interface IDirektorService
    {
        Task<IEnumerable<DirektorDTO>> GetDirectorsAsync();
        Task<DirektorDTO> GetDirectorByIdAsync(int id);
        Task<DirektorDTO> CreateDirectorAsync(DirektorDTO direktorDTO);
        Task<bool> UpdateDirectorAsync(int id, DirektorDTO direktorDTO);
        Task<bool> DeleteDirectorAsync(int id);
    }
}
