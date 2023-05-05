using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos.Pokemon
{
    public class AddPokemonDto
    {
        public int PkmId { get; set; }
        public string ?PkmName { get; set; }
        public string ?PkmImgUrl { get; set; }
    }
}