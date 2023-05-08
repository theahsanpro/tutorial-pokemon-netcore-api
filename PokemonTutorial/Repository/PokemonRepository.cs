using PokemonTutorial.Data;
using PokemonTutorial.Interfaces;
using PokemonTutorial.Models;

namespace PokemonTutorial.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;
        public PokemonRepository(DataContext context)
        {
            this._context = context;
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemon.OrderBy(p => p.ID).ToList();
        }
    }
}
