using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace PokémonChallenge.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<GetUserDto>>> GetAllUsers();
        Task<ServiceResponse<GetUserDto>> GetUserById(int id);
        Task<ServiceResponse<GetUserDto>> AddUser(AddUserDto newUser);
        Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedUser);
        Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id);
        
    }
}