using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public int PkmId { get; set; }
        public string ?PkmName { get; set; } = string.Empty;
        public string ?PkmImgUrl { get; set; }
    }
}