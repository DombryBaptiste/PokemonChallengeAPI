using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos.User
{
    public class AddUserDto
    {
        public required string ?Pseudo { get; set; }
        public required string ?PasswordHash { get; set; }
    }
}