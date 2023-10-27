using AutoMapper;
using LibraryAPI.DTO;
using LibraryAPI.Interface;
using LibraryAPI.Models;
using LibraryAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BookController(IBookService bookService, IMapper mapper) 
        {
            _bookService = bookService;
            _mapper = mapper; 
        }

        [HttpPost]
        public  async Task<ActionResult> AddBook(BookDTO pBook)
        {
            var book = _mapper.Map<Book>(pBook);
            await _bookService.AddBook(book);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllBooks()
        {
            var allBooks = await _bookService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpPut]
        public async Task<ActionResult> CheckOut(int bookId) 
        {

            var isCheckOut = await _bookService.IsCheckOut(bookId);

            if (isCheckOut) 
            {
                return BadRequest("Book is already Checkout");
            }

            await _bookService.CheckOutBook(bookId);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> ReturnBook(int bookId)
        {

            var isCheckOut = await _bookService.IsCheckOut(bookId);

            if (!isCheckOut)
            {
                return BadRequest("Book is not Checkout");
            }

            await _bookService.ReturnBook(bookId);
            return Ok();
        }

      
    }
}
