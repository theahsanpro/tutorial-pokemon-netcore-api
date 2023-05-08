using Microsoft.AspNetCore.Mvc;
using PokemonTutorial.Data;
using PokemonTutorial.Interfaces;
using PokemonTutorial.Models;

namespace PokemonTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository pokemonRrepository;
        private readonly DataContext dataContext;
        public PokemonController(IPokemonRepository pokemonRepository, DataContext context)
        {
            this.pokemonRrepository = pokemonRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = (typeof(IEnumerable<Pokemon>)))]
        public IActionResult GetPokemon()
        {
            var pokemon = pokemonRrepository.GetPokemons();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemon);
        }
    }
}
