using TFTWebApp.Interfaces.Repositories;
using TFTWebApp.Interfaces.Services;
using TFTWebApp.Models.DTOs;
using TFTWebApp.Models;

namespace TFTWebApp.Services
{
    public class ZanrService : IZanrService
    {
        private readonly IZanrRepository _zanrRepository;

        public ZanrService(IZanrRepository zanrRepository)
        {
            _zanrRepository = zanrRepository;
        }

        public async Task<IEnumerable<ZanrDTO>> GetGenresAsync()
        {
            var zanrovi = await _zanrRepository.GetGenresAsync();
            var zanroviDTOs = new List<ZanrDTO>();

            foreach (var zanr in zanrovi)
            {
                zanroviDTOs.Add(new ZanrDTO
                {
                    Id = zanr.Id,
                    Naziv = zanr.Naziv
                });
            }

            return zanroviDTOs;
        }

        public async Task<ZanrDTO> GetGenreByIdAsync(int id)
        {
            var zanr = await _zanrRepository.GetGenreByIdAsync(id);

            if (zanr == null)
                return null;

            return new ZanrDTO
            {
                Id = zanr.Id,
                Naziv = zanr.Naziv
            };
        }

        public async Task<ZanrDTO> CreateGenreAsync(ZanrDTO zanrDTO)
        {
            var zanr = new Zanr
            {
                Naziv = zanrDTO.Naziv
            };

            var createdZanr = await _zanrRepository.CreateGenreAsync(zanr);

            return new ZanrDTO
            {
                Id = createdZanr.Id,
                Naziv = createdZanr.Naziv
            };
        }

        public async Task<bool> UpdateGenreAsync(int id, ZanrDTO zanrDTO)
        {
            var existingZanr = await _zanrRepository.GetGenreByIdAsync(id);

            if (existingZanr == null)
                return false;

            existingZanr.Naziv = zanrDTO.Naziv;

            return await _zanrRepository.UpdateGenreAsync(id, existingZanr);
        }

        public async Task<bool> DeleteGenreAsync(int id)
        {
            return await _zanrRepository.DeleteGenreAsync(id);
        }
    }
}
