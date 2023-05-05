using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enum;

namespace Dtos.User
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public required string ?Pseudo { get; set; }
        public required string ?PasswordHash { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required EnumRoles Role { get; set; }
        public required int ChallengeCreated { get; set; }
    }
}