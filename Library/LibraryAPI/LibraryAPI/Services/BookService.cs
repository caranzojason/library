using LibraryAPI.Helper;
using LibraryAPI.Interface;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Service
{
    public class BookService : IBookService
    {
        private readonly LibraryContext _dbContext;
        public BookService(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddBook(Book book)
        {
            _dbContext.Add(book);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<int> CheckOutBook(int id)
        {
            var book = _dbContext.Books.Where(x=>x.Id ==id).FirstOrDefault();
            book.IsCheckedOut = true;
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> ReturnBook(int id)
        {
            var book = _dbContext.Books.Where(x => x.Id == id).FirstOrDefault();
            book.IsCheckedOut = false;
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsCheckOut(int id)
        {
            var book = _dbContext.Books.Where(x => x.Id == id).FirstOrDefault();
            return book.IsCheckedOut;
        }

    }
}
