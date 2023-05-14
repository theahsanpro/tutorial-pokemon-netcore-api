using PokemonTutorial.Models;

namespace PokemonTutorial.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int id);
        ICollection<Review> GetReviewOfAPokemnon(int pokeID);
        bool ReviewExists(int reviewID);
    }
}
