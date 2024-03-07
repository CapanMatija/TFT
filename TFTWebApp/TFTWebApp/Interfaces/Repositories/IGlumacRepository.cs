using TFTWebApp.Models;

namespace TFTWebApp.Interfaces.Repositories
{
    public interface IGlumacRepository
    {
        Task<IEnumerable<Glumac>> GetActorsAsync();
        Task<Glumac> GetActorByIdAsync(int id);
        Task<Glumac> CreateActorAsync(Glumac glumac);
        Task<bool> UpdateActorAsync(int id, Glumac glumac);
        Task<bool> DeleteActorAsync(int id);
    }
}
