using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class BookService : IBookService
    {
        public Task<Book> GetBook()
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetBooks()
        {
            throw new NotImplementedException();
        }
    }
}
