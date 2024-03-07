using TFTWebApp.Models.DTOs;

namespace TFTWebApp.Interfaces.Services
{
    public interface IPersonService
    {
        Task<PersonDTO> CreatePersonAsync(PersonDTO personDTO);
    }
}
