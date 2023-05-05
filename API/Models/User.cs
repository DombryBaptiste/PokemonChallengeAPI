using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enum;

namespace Models
{
    public class User
    {
        public int Id { get; set; }
        public string ?Pseudo { get; set; } = string.Empty;
        public string ?PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public EnumRoles Role { get; set; }
        public int ChallengeCreated { get; set; }
        public List<Challenge> ?Challenges { get; set; }        
    }
}