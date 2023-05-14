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
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this._categoryRepository = categoryRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = (typeof(IEnumerable<Category >)))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = (typeof(Category)))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int categoryId)
        {
            if (!_categoryRepository.CategoryExists(categoryId))
                return NotFound();

            var cat = _mapper.Map<CategoryDto>(_categoryRepository.GetCategory(categoryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cat);
        }

        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200, Type = (typeof(IEnumerable<Category>)))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByCategoryID(int categoryId)
        {
            var pokemons = _mapper.Map<List<PokemonDto>>(_categoryRepository.GetPokemonsByCategory(categoryId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemons);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategory([FromBody] CategoryDto categoryCreate)
        {
            if(categoryCreate == null)
                return BadRequest(ModelState);

            var category = _categoryRepository.GetCategories()
                .Where(c => c.Name.Trim().ToUpper() == categoryCreate.Name.ToUpper())
                .FirstOrDefault();

            if(category != null)
            {
                ModelState.AddModelError("", "Category Already exists");
                return StatusCode(422, ModelState);
            }

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryMap = _mapper.Map<Category>(categoryCreate);

            if(!_categoryRepository.CreateCategory(categoryMap))
            {
                ModelState.AddModelError("", "Something went wronmg while saving");
                return StatusCode(500, ModelState);
            }

            return Ok(categoryMap);
        }
    }
}
