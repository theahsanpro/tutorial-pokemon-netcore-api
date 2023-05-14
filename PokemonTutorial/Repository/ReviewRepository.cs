using PokemonTutorial.Data;
using PokemonTutorial.Interfaces;
using PokemonTutorial.Models;

namespace PokemonTutorial.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;

        public ReviewRepository(DataContext context)
        {
            this._context = context;
        }

        public Review GetReview(int id)
        {
            return _context.Reviews.Where(r => r.ID == id).FirstOrDefault();
        }

        public ICollection<Review> GetReviewOfAPokemnon(int pokeID)
        {
            return _context.Reviews.Where(r => r.Pokemon.ID == pokeID).ToList();
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public bool ReviewExists(int reviewID)
        {
            return _context.Reviews.Any(r => r.ID == reviewID);
        }
    }
}
