using LibraryAPI.Interfaces;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public class ReviewService : IReviewService
    {
        private readonly LibraryContext _dbContext;
        public ReviewService(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddReview(Review review)
        {
            _dbContext.Add(review);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Review>> GetReviewByBookId(int id)
        {
            return await _dbContext.Reviews.Where(x => x.BookId == id).ToListAsync();
        }
    }
}
