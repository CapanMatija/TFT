using Microsoft.AspNetCore.Mvc;
using TFTWebApp.Models.DTOs;

namespace TFTWebApp.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDTO> CreateUserAsync(UserDTO userDTO);
        Task<UserDTO> GetUserByIdAsync(int userDTO);
        Task<ActionResult<IEnumerable<UserDTO>>> GetUsers();
    }
}
