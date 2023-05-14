using PokemonTutorial.Models;

namespace PokemonTutorial.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int id);
        ICollection<Review> GetReviewsByReviewer(int reviewerId);
        bool ReviewerExist(int id);
        bool CreateReview(Reviewer reviewer);
        bool Save();
    }
}
