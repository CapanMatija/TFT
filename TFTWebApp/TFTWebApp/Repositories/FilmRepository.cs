using Microsoft.EntityFrameworkCore;
using TFTWebApp.Data;
using TFTWebApp.Interfaces.Repositories;
using TFTWebApp.Models;

namespace TFTWebApp.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly TFTDbContext _context;

        public FilmRepository(TFTDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Film>> GetFilmsAsync()
        {
            return await _context.Set<Film>().ToListAsync();
        }

        public async Task<Film> GetFilmByIdAsync(int id)
        {
            return await _context.Set<Film>().FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Film> CreateFilmAsync(Film film)
        {
            _context.Set<Film>().Add(film);
            await _context.SaveChangesAsync();
            return film;
        }

        public async Task<bool> UpdateFilmAsync(int id, Film film)
        {
            var existingFilm = await GetFilmByIdAsync(id);

            if (existingFilm == null)
            {
                return false;
            }

            existingFilm.Naslov = film.Naslov;
            existingFilm.Opis = film.Opis;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteFilmAsync(int id)
        {
            var filmToDelete = await GetFilmByIdAsync(id);

            if (filmToDelete == null)
            {
                return false;
            }

            _context.Set<Film>().Remove(filmToDelete);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
