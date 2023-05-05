using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace PokémonChallenge.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public UserService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<GetUserDto>> AddUser(AddUserDto newUser)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            var user = _mapper.Map<User>(newUser);
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            try
            {
                // var user = users.FirstOrDefault(u => u.Id == id);
                // if (user is null)
                // {
                //     throw new Exception($"user with Id '{id}' not found"); 
                // }
                
                // users.Remove(user);
                // serviceResponse.Data = users.Select(c => _mapper.Map<GetUserDto>(c)).ToList();
            }
            catch(Exception e) {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }

            return serviceResponse;
        }
        [EnableCors()]
        [HttpGet]
        public async Task<ServiceResponse<List<GetUserDto>>> GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            var dbUsers = await _context.Users.ToListAsync();
            serviceResponse.Data = dbUsers.Select(c => _mapper.Map<GetUserDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            // var user = users.FirstOrDefault(u => u.Id == id);
            //serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedUser)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            try
            {
                // var user = users.FirstOrDefault(u => u.Id == updatedUser.Id);
                // if (user is null)
                // {
                //     throw new Exception($"user with Id '{updatedUser.Id}' not found"); 
                // }

                // _mapper.Map(updatedUser, user);
                // serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            }
            catch(Exception e) {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }

            return serviceResponse;
        }
    }
}