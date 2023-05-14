using PokemonTutorial.Models;

namespace PokemonTutorial.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerID);
        ICollection<Owner> GetOwnerOfAPokemon(int pokeID);
        ICollection<Pokemon> GetPokemonByOwner(int ownerID);
        bool OwnerExists(int ownerID);
        bool CreateOwner(Owner owner);
        bool Save();
    }
}
