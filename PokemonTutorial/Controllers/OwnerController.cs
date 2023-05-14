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
    public class OwnerController : Controller
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerRepository ownerRepository, IMapper mapper)
        {
            this._ownerRepository = ownerRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = (typeof(IEnumerable<Owner>)))]
        public IActionResult GetOwners()
        {
            var owner = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwners());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(owner);
        }

        [HttpGet("{ownerId}")]
        [ProducesResponseType(200, Type = (typeof(Owner)))]
        [ProducesResponseType(400)]
        public IActionResult GetOwner(int ownerId)
        {
            if (!_ownerRepository.OwnerExists(ownerId))
                return NotFound();

            var owner = _mapper.Map<PokemonDto>(_ownerRepository.OwnerExists(ownerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(owner);
        }

        [HttpGet("{ownerID}/pokemon")]
        [ProducesResponseType(200, Type = (typeof(Owner)))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByOwner(int ownerID)
        {
            if(!_ownerRepository.OwnerExists(ownerID)) 
                return NotFound();

            var owner = _mapper.Map<List<PokemonDto>>(_ownerRepository.GetPokemonByOwner(ownerID));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(owner);
        }   
    } 
}
