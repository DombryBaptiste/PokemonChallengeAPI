using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokémonChallenge.Services.PokemonService
{
    public interface IPokemonService
    {
        Task<ServiceResponse<GetPokemonDto>> AddPokemon(AddPokemonDto addPokemon);
    }
}