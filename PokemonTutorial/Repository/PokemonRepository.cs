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

        public bool CreatePokemon(int ownerID, int categoryID, Pokemon pokemon)
        {
            var pokemonOwnerEntity = _context.Owners.Where(a => a.ID == ownerID).FirstOrDefault();
            var category = _context.Categories.Where(c => c.ID == categoryID).FirstOrDefault();

            var pokemonOwner = new PokemonOwner()
            {
                Owner = pokemonOwnerEntity,
                Pokemon = pokemon
            };

            _context.Add(pokemonOwner);

            var pokemonCategory = new PokemonCategory()
            {
                Category = category,
                Pokemon = pokemon
            };

            _context.Add(pokemonCategory);
            _context.Add(pokemon);

            return Save();
        }

        public Pokemon GetPokemon(int pokeId)
        {
            return _context.Pokemon.Where(p => p.ID == pokeId).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemon.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int id)
        {
            var review = _context.Reviews.Where(p => p.ID == id);

            if (review.Count() < 1)
                return 0;

            return((decimal)review.Sum(r => r.Rating)/review.Count());
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemon.OrderBy(p => p.ID).ToList();
        }

        public bool PokemonExist(int id)
        {
            return _context.Pokemon.Any(p => p.ID == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            
            return saved > 0 ?true : false;
        }
    }
}
