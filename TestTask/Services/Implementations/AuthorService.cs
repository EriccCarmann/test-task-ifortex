using TestTask.Models;
using TestTask.Services.Interfaces;
using TestTask.Data;
using Microsoft.EntityFrameworkCore;

namespace TestTask.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDbContext _context;

        private DateTime DATE_CLAUSE = new DateTime(2012, 05, 25);

        public AuthorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Author> GetAuthor()
        {
            var titles = await _context.Books.Select(b => b.Title).ToListAsync();

            var books = _context.Books
                .Where(title => title.Title.Length == titles.Max().Length);

            var author = _context.Authors
                .Where(a => books.Any(b => b.AuthorId == a.Id))
                .OrderByDescending(s => s.Id)
                .Last();

            return author;
        }

        public async Task<List<Author>> GetAuthors()
        {
            var authorsBooks = await _context.Books
               .Where(b => b.PublishDate > DATE_CLAUSE)
               .GroupBy(b => b.AuthorId)
               .Where(b => b.Count() % 2 == 0)
               .Select(b => b.Key)
               .ToListAsync();

            var authors = await _context.Authors
               .Where(a => authorsBooks.Contains(a.Id))
               .ToListAsync();

            return authors;
        }
    }
}
