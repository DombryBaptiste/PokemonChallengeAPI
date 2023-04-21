using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace PokémonChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("register")]
        public ActionResult<User> Register(GetUserDto request)
        {
            string PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash);
            User newUser = new User();
            user.Pseudo = request.Pseudo;
            user.PasswordHash = PasswordHash;

            return Ok(user);
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