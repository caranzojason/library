using LibraryAPI.Models;

namespace LibraryAPI.Interfaces
{
    public interface IReviewService
    {
        Task<int> AddReview(Review review);
        Task<List<Review>> GetReviewByBookId(int id);
    }
}
