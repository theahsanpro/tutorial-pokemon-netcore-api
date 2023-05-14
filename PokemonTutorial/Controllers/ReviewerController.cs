using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonTutorial.Dto;
using PokemonTutorial.Interfaces;
using PokemonTutorial.Models;

namespace PokemonTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : Controller
    {
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IMapper _mapper;

        public ReviewerController(IReviewerRepository reviewerRepository, IMapper mapper)
        {
            this._reviewerRepository = reviewerRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = (typeof(IEnumerable<Reviewer>)))]
        public IActionResult GetReviewers()
        {
            var reviewer = _mapper.Map<List<ReviewerDto>>(_reviewerRepository.GetReviewers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewer);
        }

        [HttpGet("{reviewerId}")]
        [ProducesResponseType(200, Type = (typeof(Reviewer)))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewer(int reviewerId)
        {
            if (!_reviewerRepository.ReviewerExist(reviewerId))
                return NotFound();

            var reviewer = _mapper.Map<ReviewerDto>(_reviewerRepository.GetReviewer(reviewerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewer);
        }

        [HttpGet("{reviewerID}/reviews")]
        [ProducesResponseType(200, Type = (typeof(Reviewer)))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewsByReviewer(int reviewerId)
        {
            if (!_reviewerRepository.ReviewerExist(reviewerId))
                return NotFound();

            var reviews = _mapper.Map<List<ReviewDto>>(_reviewerRepository.GetReviewsByReviewer(reviewerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviews);
        }
    }
}
