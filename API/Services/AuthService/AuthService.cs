using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace PokémonChallenge.Services.AuthService
{ 
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public AuthService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<GetUserDto>> AddUser(AddUserDto newUser)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            string PasswordHash = BCrypt.Net.BCrypt.HashPassword(newUser.PasswordHash);
            User AddedUser = _mapper.Map<User>(newUser);
            AddedUser.PasswordHash = PasswordHash;
            await _dataContext.AddAsync(AddedUser);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data =  _mapper.Map<GetUserDto>(AddedUser);;
            return serviceResponse;
        }

        public async Task<bool> DeleteUserById(int id)
        {
            var user = await _dataContext.Users.FindAsync(id);
            if(user is null)
            {
                return false;
            }
            _dataContext.Remove(user);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<ServiceResponse<GetUserDto>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            var user = await _dataContext.Users.FindAsync(id);
            serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetUserDto>>> GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            var users = await _dataContext.Users.ToListAsync();
            serviceResponse.Data = _mapper.Map<List<GetUserDto>>(users);
            return serviceResponse;
        }
    }
}