using PokemonTutorial.Data;
using PokemonTutorial.Interfaces;
using PokemonTutorial.Models;

namespace PokemonTutorial.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context)
        {
            this._context = context;
        }

        public bool CreateOwner(Owner owner)
        {
            _context.Add(owner);
            return Save();
        }

        public Owner GetOwner(int ownerID)
        {
            return _context.Owners.Where(o => o.ID == ownerID).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerOfAPokemon(int pokeID)
        {
            return _context.PokemonOwners.Where(p => p.Pokemon.ID == pokeID).Select(o => o.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.ToList();    
        }

        public ICollection<Pokemon> GetPokemonByOwner(int ownerID)
        {
            return _context.PokemonOwners.Where(p => p.Owner.ID == ownerID).Select(p => p.Pokemon).ToList();
        }

        public bool OwnerExists(int ownerID)
        {
            return _context.Owners.Any(o => o.ID == ownerID);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
