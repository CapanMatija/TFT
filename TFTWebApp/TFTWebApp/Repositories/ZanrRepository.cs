using Microsoft.EntityFrameworkCore;
using TFTWebApp.Data;
using TFTWebApp.Interfaces.Repositories;
using TFTWebApp.Models;

namespace TFTWebApp.Repositories
{
    public class ZanrRepository : IZanrRepository
    {
        private readonly TFTDbContext _context;

        public ZanrRepository(TFTDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Zanr>> GetGenresAsync()
        {
            return await _context.Zanrovi.ToListAsync();
        }

        public async Task<Zanr> GetGenreByIdAsync(int id)
        {
            return await _context.Zanrovi.FirstOrDefaultAsync(z => z.Id == id);
        }

        public async Task<Zanr> CreateGenreAsync(Zanr zanr)
        {
            _context.Zanrovi.Add(zanr);
            await _context.SaveChangesAsync();
            return zanr;
        }

        public async Task<bool> UpdateGenreAsync(int id, Zanr updatedZanr)
        {
            var existingZanr = await _context.Zanrovi.FirstOrDefaultAsync(z => z.Id == id);

            if (existingZanr == null)
            {
                return false;
            }

            existingZanr.Naziv = updatedZanr.Naziv;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteGenreAsync(int id)
        {
            var existingZanr = await _context.Zanrovi.FirstOrDefaultAsync(z => z.Id == id);

            if (existingZanr == null)
            {
                return false;
            }

            _context.Zanrovi.Remove(existingZanr);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
