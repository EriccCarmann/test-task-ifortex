using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;

        private DateTime DATE_CLAUSE = new DateTime(2012, 05, 25);
        private const string TITLE_CLAUSE = "Red";

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Book> GetBook()
        {
            var maxPrice = await _context.Books
                .MaxAsync(p => p.Price);

            var book = await _context.Books
                .Where(b => b.Price == maxPrice)
                .FirstAsync();

            return book;
        }

        public async Task<List<Book>> GetBooks()
        {
            var books = await _context.Books
               .Where(b => b.PublishDate > DATE_CLAUSE)
               .Where(b => b.Title.Contains(TITLE_CLAUSE))
               .ToListAsync();

            return books;
        }
    }
}
