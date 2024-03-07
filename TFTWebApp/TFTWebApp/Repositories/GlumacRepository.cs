using Microsoft.EntityFrameworkCore;
using TFTWebApp.Data;
using TFTWebApp.Interfaces.Repositories;
using TFTWebApp.Models;

namespace TFTWebApp.Repositories
{
    public class GlumacRepository : IGlumacRepository
    {
        private readonly TFTDbContext _context;

        public GlumacRepository(TFTDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Glumac>> GetActorsAsync()
        {
            return await _context.Glumci.ToListAsync();
        }

        public async Task<Glumac> GetActorByIdAsync(int id)
        {
            return await _context.Glumci.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Glumac> CreateActorAsync(Glumac glumac)
        {
            _context.Glumci.Add(glumac);
            await _context.SaveChangesAsync();
            return glumac;
        }

        public async Task<bool> UpdateActorAsync(int id, Glumac updatedGlumac)
        {
            var existingGlumac = await _context.Glumci.FirstOrDefaultAsync(g => g.Id == id);

            if (existingGlumac == null)
            {
                return false;
            }

            existingGlumac.Ime = updatedGlumac.Ime;
            existingGlumac.Prezime = updatedGlumac.Prezime;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteActorAsync(int id)
        {
            var existingGlumac = await _context.Glumci.FirstOrDefaultAsync(g => g.Id == id);

            if (existingGlumac == null)
            {
                return false;
            }

            _context.Glumci.Remove(existingGlumac);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
