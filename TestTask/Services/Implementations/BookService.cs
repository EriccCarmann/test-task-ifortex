using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Book> GetBook()
        {
            var books = await _context.Books.FirstOrDefaultAsync();

            return books;
        }

        public Task<List<Book>> GetBooks()
        {
            throw new NotImplementedException();
        }
    }
}
