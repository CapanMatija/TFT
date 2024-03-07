using TFTWebApp.Models;

namespace TFTWebApp.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetPersonsAsync();
        Task<Person> GetPersonByIdAsync(int id);
        Task<Person> CreatePersonAsync(Person person);
        Task<bool> UpdatePersonAsync(int id, Person person);
        Task<bool> DeletePersonAsync(int id);
    }
}
