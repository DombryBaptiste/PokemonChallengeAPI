using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokémonChallenge.Services.PokemonService;

namespace PokémonChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;
        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }
        
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetPokemonDto>>> AddPokemon(AddPokemonDto addPokemon)
        {
            return Ok(await _pokemonService.AddPokemon(addPokemon));
        }
    }
}