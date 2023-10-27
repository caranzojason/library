using LibraryAPI.Models;

namespace LibraryAPI.Interface
{
    public interface IBookService
    {
        Task<int> AddBook(Book book);
        Task<List<Book>> GetAllBooks();
        Task<int> CheckOutBook(int id);
        Task<int> ReturnBook(int id);
        Task<bool> IsCheckOut(int id);
    }
}
