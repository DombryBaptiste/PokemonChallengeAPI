using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Challenge
    {
        public int Id { get; set; }
        public int UserCreatorId { get; set; }
        public List<User> ?Users { get; set;}
    }
}