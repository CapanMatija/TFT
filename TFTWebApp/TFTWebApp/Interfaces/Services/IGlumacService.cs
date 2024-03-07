using TFTWebApp.Models.DTOs;

namespace TFTWebApp.Interfaces.Services
{
    public interface IGlumacService
    {
        Task<IEnumerable<GlumacDTO>> GetActorsAsync();
        Task<GlumacDTO> GetActorByIdAsync(int id);
        Task<GlumacDTO> CreateActorAsync(GlumacDTO glumacDTO);
        Task<bool> UpdateActorAsync(int id, GlumacDTO glumacDTO);
        Task<bool> DeleteActorAsync(int id);
    }
}
