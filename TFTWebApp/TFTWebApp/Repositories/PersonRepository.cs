using Microsoft.EntityFrameworkCore;
using TFTWebApp.Data;
using TFTWebApp.Interfaces.Repositories;
using TFTWebApp.Models;

namespace TFTWebApp.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly TFTDbContext _context;

        public PersonRepository(TFTDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetPersonsAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await _context.Persons.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Person> CreatePersonAsync(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<bool> UpdatePersonAsync(int id, Person updatedPerson)
        {
            var existingPerson = await _context.Persons.FirstOrDefaultAsync(d => d.Id == id);

            if (existingPerson == null)
            {
                return false;
            }

            existingPerson.Ime = updatedPerson.Ime;
            existingPerson.Prezime = updatedPerson.Prezime;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePersonAsync(int id)
        {
            var existingPerson = await _context.Persons.FirstOrDefaultAsync(d => d.Id == id);

            if (existingPerson == null)
            {
                return false;
            }

            _context.Persons.Remove(existingPerson);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
