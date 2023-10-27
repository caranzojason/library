using AutoMapper;
using LibraryAPI.DTO;
using LibraryAPI.Interface;
using LibraryAPI.Interfaces;
using LibraryAPI.Models;
using LibraryAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public async Task<ActionResult> AddBook(Review review)
        {
            await _reviewService.AddReview(review);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetReview(int bookId)
        {
            var reviews = await _reviewService.GetReviewByBookId(bookId);
            return Ok(reviews);
        }
    }
}
