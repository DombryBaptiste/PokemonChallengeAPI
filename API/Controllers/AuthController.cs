using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PokémonChallenge.Services.AuthService;

namespace PokémonChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;
        
        public AuthController(IConfiguration configuration, IAuthService authService)
        {
            _configuration = configuration;
            _authService = authService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var response = await _authService.GetUserById(id);

            if(response.Data is null){
                return BadRequest($"User with id {id} not found.");
            }
            return Ok(response);
        }
        [HttpGet("all")]
        public async Task<ActionResult<User>> GetAllUsers()
        {
            var response = await _authService.GetAllUsers();

            if(response.Data is null){
                return BadRequest($"No users found.");
            }
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(AddUserDto user)
        {
            return Ok(await _authService.AddUser(user));
        }

        [HttpPost("login")]
        public ActionResult<User> Login(GetUserDto request)
        {
           if(user.Pseudo != request.Pseudo)
           {
                return BadRequest("User not found.");
           }

           if(!BCrypt.Net.BCrypt.Verify(request.PasswordHash, user.PasswordHash))
           {
            return BadRequest("Wrong password.");
           }
            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Pseudo),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}