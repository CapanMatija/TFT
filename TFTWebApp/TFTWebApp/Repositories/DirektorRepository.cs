using Microsoft.EntityFrameworkCore;
using TFTWebApp.Data;
using TFTWebApp.Interfaces.Repositories;
using TFTWebApp.Models;

namespace TFTWebApp.Repositories
{
    public class DirektorRepository : IDirektorRepository
    {
        private readonly TFTDbContext _context;

        public DirektorRepository(TFTDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Direktor>> GetDirectorsAsync()
        {
            return await _context.Direktori.ToListAsync();
        }

        public async Task<Direktor> GetDirectorByIdAsync(int id)
        {
            return await _context.Direktori.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Direktor> CreateDirectorAsync(Direktor direktor)
        {
            _context.Direktori.Add(direktor);
            await _context.SaveChangesAsync();
            return direktor;
        }

        public async Task<bool> UpdateDirectorAsync(int id, Direktor updatedDirektor)
        {
            var existingDirektor = await _context.Direktori.FirstOrDefaultAsync(d => d.Id == id);

            if (existingDirektor == null)
            {
                return false;
            }

            existingDirektor.Ime = updatedDirektor.Ime;
            existingDirektor.Prezime = updatedDirektor.Prezime;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDirectorAsync(int id)
        {
            var existingDirektor = await _context.Direktori.FirstOrDefaultAsync(d => d.Id == id);

            if (existingDirektor == null)
            {
                return false;
            }

            _context.Direktori.Remove(existingDirektor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
