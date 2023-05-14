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

        public bool CreateReview(Review review)
        {
            _context.Add(review);
            return Save();
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

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
