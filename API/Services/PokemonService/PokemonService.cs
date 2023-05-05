using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace PokémonChallenge.Services.PokemonService
{
    public class PokemonService : IPokemonService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public PokemonService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _context = dataContext;
        }
        public async Task<ServiceResponse<GetPokemonDto>> AddPokemon(AddPokemonDto addPokemon)
        {
            var serviceResponse = new ServiceResponse<GetPokemonDto>();
            var pokemon = _mapper.Map<Pokemon>(addPokemon);
            await _context.AddAsync(pokemon);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetPokemonDto>(pokemon);
            return serviceResponse;
        }
    }
}