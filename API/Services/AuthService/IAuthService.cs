using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokémonChallenge.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<GetUserDto>> AddUser(AddUserDto newUser);
        Task<ServiceResponse<GetUserDto>> GetUserById(int id);
        Task<ServiceResponse<List<GetUserDto>>> GetAllUsers();
    }
}