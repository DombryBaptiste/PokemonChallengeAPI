using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    [Keyless]
    public class PokemonsOwnedUsers
    {
        public int userId { get; set; }
        public int ChallengeId { get; set; }
        public int PkmId { get; set; }
        public DateTime AddDate { get; set; }
    }
}