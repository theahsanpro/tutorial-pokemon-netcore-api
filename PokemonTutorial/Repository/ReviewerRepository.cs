using PokemonTutorial.Data;
using PokemonTutorial.Interfaces;
using PokemonTutorial.Models;

namespace PokemonTutorial.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly DataContext _context;

        public ReviewerRepository(DataContext context)
        {
            this._context = context;
        }

        public Reviewer GetReviewer(int id)
        {
            return _context.Reviewers.Where(r => r.ID == id).FirstOrDefault();
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _context.Reviewers.ToList();
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            return _context.Reviews.Where(r => r.Reviewer.ID == reviewerId).ToList();
        }

        public bool ReviewerExist(int id)
        {
            return _context.Reviewers.Any(r => r.ID == id);
        }
    }
}
