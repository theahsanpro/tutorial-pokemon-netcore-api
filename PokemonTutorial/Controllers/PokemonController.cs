using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonTutorial.Dto;
using PokemonTutorial.Interfaces;
using PokemonTutorial.Models;
using PokemonTutorial.Repository;

namespace PokemonTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonRrepository;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            this._pokemonRrepository = pokemonRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = (typeof(IEnumerable<Pokemon>)))]
        public IActionResult GetPokemons()  
        {
            var pokemon = _mapper.Map<List<PokemonDto>>(_pokemonRrepository.GetPokemons());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemon);
        }

        [HttpGet("{pokeId}")]
        [ProducesResponseType(200, Type = (typeof(Pokemon)))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int pokeId)
        {
            if (!_pokemonRrepository.PokemonExist(pokeId))
                return NotFound();

            var pokemon = _mapper.Map<PokemonDto>(_pokemonRrepository.GetPokemon(pokeId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemon);
        }

        [HttpGet("{pokeId}/rating")]
        [ProducesResponseType(200, Type = (typeof(decimal)))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int pokeId)
        {
            if (!_pokemonRrepository.PokemonExist(pokeId))
                return NotFound();

            var rating = _pokemonRrepository.GetPokemonRating(pokeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(rating);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePokemon([FromQuery] int ownerId, [FromQuery] int catId, [FromBody] PokemonDto pokemonCreate)
        {
            if (pokemonCreate == null)
                return BadRequest(ModelState);

            var pokemons = _pokemonRrepository.GetPokemons()
                .Where(p => p.Name.Trim().ToUpper() == pokemonCreate.Name.Trim().ToUpper())
                .FirstOrDefault();

            if (pokemons != null)
            {
                ModelState.AddModelError("", "Pokemon Already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pokemonMap = _mapper.Map<Pokemon>(pokemonCreate);

            if (!_pokemonRrepository.CreatePokemon(ownerId, catId, pokemonMap))
            {
                ModelState.AddModelError("", "Something went wronmg while saving");
                return StatusCode(500, ModelState);
            }

            return Ok(pokemonMap);
        }
    }
}
