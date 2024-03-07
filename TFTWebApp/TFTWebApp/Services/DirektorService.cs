using TFTWebApp.Interfaces.Repositories;
using TFTWebApp.Interfaces.Services;
using TFTWebApp.Models;
using TFTWebApp.Models.DTOs;

namespace TFTWebApp.Services
{
    public class DirektorService : IDirektorService
    {
        private readonly IDirektorRepository _direktorRepository;

        public DirektorService(IDirektorRepository direktorRepository)
        {
            _direktorRepository = direktorRepository;
        }

        public async Task<IEnumerable<DirektorDTO>> GetDirectorsAsync()
        {
            var direktori = await _direktorRepository.GetDirectorsAsync();
            var direktoriDTOs = new List<DirektorDTO>();

            foreach (var direktor in direktori)
            {
                direktoriDTOs.Add(new DirektorDTO
                {
                    Id = direktor.Id,
                    Ime = direktor.Ime,
                    Prezime = direktor.Prezime
                });
            }

            return direktoriDTOs;
        }

        public async Task<DirektorDTO> GetDirectorByIdAsync(int id)
        {
            var direktor = await _direktorRepository.GetDirectorByIdAsync(id);
            if (direktor == null)
                return null;

            return new DirektorDTO
            {
                Id = direktor.Id,
                Ime = direktor.Ime,
                Prezime = direktor.Prezime
            };
        }

        public async Task<DirektorDTO> CreateDirectorAsync(DirektorDTO direktorDTO)
        {
            var person = new Person(direktorDTO.Ime, direktorDTO.Prezime, direktorDTO.Email);
            var direktor = new Direktor(person);

            var createdDirektor = await _direktorRepository.CreateDirectorAsync(direktor);

            return new DirektorDTO
            {
                Id = createdDirektor.Id,
                Ime = createdDirektor.Ime,
                Prezime = createdDirektor.Prezime,
                Email = createdDirektor.Email
            };
        }

        public async Task<bool> UpdateDirectorAsync(int id, DirektorDTO direktorDTO)
        {
            var existingDirektor = await _direktorRepository.GetDirectorByIdAsync(id);

            if (existingDirektor == null)
                return false;

            existingDirektor.Ime = direktorDTO.Ime;
            existingDirektor.Prezime = direktorDTO.Prezime;

            return await _direktorRepository.UpdateDirectorAsync(id, existingDirektor);
        }

        public async Task<bool> DeleteDirectorAsync(int id)
        {
            return await _direktorRepository.DeleteDirectorAsync(id);
        }
    }
}
