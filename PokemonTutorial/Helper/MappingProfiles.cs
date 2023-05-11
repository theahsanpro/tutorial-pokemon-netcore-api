using AutoMapper;
using PokemonTutorial.Dto;
using PokemonTutorial.Models;

namespace PokemonTutorial.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
            
        }
    }
}
