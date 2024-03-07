using TFTWebApp.Interfaces.Repositories;
using TFTWebApp.Interfaces.Services;
using TFTWebApp.Models.DTOs;
using TFTWebApp.Models;

namespace TFTWebApp.Services
{
    public class GlumacService : IGlumacService
    {
        private readonly IGlumacRepository _glumacRepository;

        public GlumacService(IGlumacRepository glumacRepository)
        {
            _glumacRepository = glumacRepository;
        }

        public async Task<IEnumerable<GlumacDTO>> GetActorsAsync()
        {
            var glumci = await _glumacRepository.GetActorsAsync();
            var glumciDTOs = new List<GlumacDTO>();

            foreach (var glumac in glumci)
            {
                glumciDTOs.Add(new GlumacDTO
                {
                    Id = glumac.Id,
                    Ime = glumac.Ime,
                    Prezime = glumac.Prezime
                });
            }

            return glumciDTOs;
        }

        public async Task<GlumacDTO> GetActorByIdAsync(int id)
        {
            var glumac = await _glumacRepository.GetActorByIdAsync(id);

            if (glumac == null)
                return null;

            return new GlumacDTO
            {
                Id = glumac.Id,
                Ime = glumac.Ime,
                Prezime = glumac.Prezime
            };
        }

        public async Task<GlumacDTO> CreateActorAsync(GlumacDTO glumacDTO)
        {
            var person = new Person(glumacDTO.Ime, glumacDTO.Prezime, glumacDTO.Email);

            var glumac = new Glumac(person, glumacDTO.OcekivaniHonorar);

            var createdGlumac = await _glumacRepository.CreateActorAsync(glumac);

            return new GlumacDTO
            {
                Id = createdGlumac.Id,
                Ime = createdGlumac.Ime,
                Prezime = createdGlumac.Prezime,
                Email = createdGlumac.Email,
                OcekivaniHonorar = createdGlumac.OcekivaniHonorar
            };
        }

        public async Task<bool> UpdateActorAsync(int id, GlumacDTO glumacDTO)
        {
            var existingGlumac = await _glumacRepository.GetActorByIdAsync(id);

            if (existingGlumac == null)
                return false;

            existingGlumac.Ime = glumacDTO.Ime;
            existingGlumac.Prezime = glumacDTO.Prezime;

            return await _glumacRepository.UpdateActorAsync(id, existingGlumac);
        }

        public async Task<bool> DeleteActorAsync(int id)
        {
            return await _glumacRepository.DeleteActorAsync(id);
        }
    }
}
