using TFTWebApp.Interfaces.Repositories;
using TFTWebApp.Interfaces.Services;
using TFTWebApp.Models;
using TFTWebApp.Models.DTOs;

namespace TFTWebApp.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<PersonDTO> CreatePersonAsync(PersonDTO personDTO)
        {
            var person = new Person
            {
                Ime = personDTO.Ime,
                Prezime = personDTO.Prezime,
                Email = personDTO.Email,
            };

            var createdPerson = await _personRepository.CreatePersonAsync(person);

            return new PersonDTO
            {
                Id = createdPerson.Id,
                Ime = createdPerson.Ime,
                Prezime = createdPerson.Prezime,
                Email = createdPerson.Email,
            };
        }
    }
}
