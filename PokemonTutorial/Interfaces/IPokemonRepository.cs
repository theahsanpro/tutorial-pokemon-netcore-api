using PokemonTutorial.Models;

namespace PokemonTutorial.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
    }
}
