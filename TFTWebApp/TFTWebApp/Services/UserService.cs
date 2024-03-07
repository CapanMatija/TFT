using Microsoft.AspNetCore.Mvc;
using TFTWebApp.Data.Enums;
using TFTWebApp.Interfaces.Repositories;
using TFTWebApp.Interfaces.Services;
using TFTWebApp.Models;
using TFTWebApp.Models.DTOs;

namespace TFTWebApp.Services
{
    public class UserService : IUserService
    {
        private readonly IDirektorRepository _direktorRepository;
        private readonly IGlumacRepository _glumacRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IAuthService _authService; 

        public UserService(
            IDirektorRepository direktorRepository, 
            IGlumacRepository glumacRepository, 
            IUserRepository userRepository,
            IPersonRepository personRepository,
            IAuthService authService
            )
        {
            _direktorRepository = direktorRepository;
            _glumacRepository = glumacRepository;
            _userRepository = userRepository;
            _personRepository = personRepository;
            _authService = authService;
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO userDTO)
        {
            var newPerson = new Person(userDTO.Ime, userDTO.Prezime, userDTO.Email);

            int? newPersonId;

            switch (userDTO.RoleId)
            {
                case (int)ApplicationRoleEnum.Direktor:
                    var newDirektor = new Direktor(newPerson);
                    var createdDirektor = await _direktorRepository.CreateDirectorAsync(newDirektor);
                    newPersonId = createdDirektor.Id;
                    break;
                case (int)ApplicationRoleEnum.Glumac:
                    var newGlumac = new Glumac(newPerson);
                    var createdGlumac = await _glumacRepository.CreateActorAsync(newGlumac);
                    newPersonId = createdGlumac.Id;
                    break;
                default:
                    throw new Exception("Neispravni podatci");
            }

            var createdPerson = await _personRepository.GetPersonByIdAsync(newPersonId.Value);

            var newUser = new ApplicationUser
            {
                UserName = userDTO.UserName,
                Email = userDTO.Email,
                RoleId = userDTO.RoleId,
                PersonId = newPersonId.Value,
                NormalizedUserName = userDTO.UserName.ToUpper()
            };

            var created = await _authService.RegisterUserAsync(newUser, userDTO.InitPassword);

            var ureturnUserDTO = MapUserToUserDTO(createdPerson, newUser);

            return ureturnUserDTO;
        }

        public async Task<UserDTO> GetUserByIdAsync(int Id)
        {
            var person = await _personRepository.GetPersonByIdAsync(Id);

            var user = await _userRepository.GetApplicationUserByPersonIdAsync(person.Id);

            var userDTO = MapUserToUserDTO(person, user);
            return userDTO;
        }

        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _userRepository.GetApplicationUserAsync();
            var persons = await _personRepository.GetPersonsAsync();
            var userDTOs = new List<UserDTO>();

            foreach (var user in users)
            {
                userDTOs.Add(MapUserToUserDTO(persons.First(x => x.Id == user.PersonId), user));
            }

            return userDTOs;
        }

        private static UserDTO MapUserToUserDTO(Person person, ApplicationUser applicationUser)
        {
            var returnValue = new UserDTO
            {
                Id = person.Id,
                Ime = person.Ime,
                Prezime = person.Prezime,
                Email = person.Email,
                UserName = applicationUser.UserName,
                InitPassword = String.Empty,
                RoleId = applicationUser.RoleId
            };

            return returnValue;
        }
    }
}
