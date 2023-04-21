using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        public int Id { get; set; }
        public string ?Pseudo { get; set; } = string.Empty;
        public string ?PasswordHash { get; set; } = string.Empty;
        
    }
}