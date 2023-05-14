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
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IMapper _mapper;

        public ReviewController(IReviewRepository reviewRepository, 
            IPokemonRepository pokemonRepository, 
            IReviewerRepository reviewerRepository,
            IMapper mapper)
        {
            this._reviewRepository = reviewRepository;
            this._pokemonRepository = pokemonRepository;
            this._reviewerRepository = reviewerRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = (typeof(IEnumerable<Review>)))]
        public IActionResult GetReviews()
        {
            var review = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviews());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(review);
        }

        [HttpGet("{reviewId}")]
        [ProducesResponseType(200, Type = (typeof(Review)))]
        [ProducesResponseType(400)]
        public IActionResult GetReview(int reviewId)
        {
            if (!_reviewRepository.ReviewExists(reviewId))
                return NotFound();

            var review = _mapper.Map<ReviewDto>(_reviewRepository.GetReview(reviewId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(review);
        }

        [HttpGet("pokemon/{pokeID}")]
        [ProducesResponseType(200, Type = (typeof(Review)))]
        [ProducesResponseType(400)]

        public IActionResult GetReviewsForAPokemon(int pokeID)
        {
            var review = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviewOfAPokemnon(pokeID));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(review);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateReview([FromQuery] int reviewerId, [FromQuery] int pokeId, [FromBody] ReviewDto reviewCreate)
        {
            if (reviewCreate == null)
                return BadRequest(ModelState);

            var review = _reviewRepository.GetReviews()
                .Where(c => c.Text.Trim().ToUpper() == reviewCreate.Text.ToUpper())
                .FirstOrDefault();

            if (review != null)
            {
                ModelState.AddModelError("", "Review Already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewMap = _mapper.Map<Review>(reviewCreate);
            reviewMap.Pokemon = _pokemonRepository.GetPokemon(pokeId);
            reviewMap.Reviewer = _reviewerRepository.GetReviewer(reviewerId);

            if (!_reviewRepository.CreateReview(reviewMap))
            {
                ModelState.AddModelError("", "Something went wronmg while saving");
                return StatusCode(500, ModelState);
            }

            return Ok(reviewMap);
        }
    }
}
