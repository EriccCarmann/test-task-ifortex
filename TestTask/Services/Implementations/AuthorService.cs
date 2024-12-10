using TestTask.Models;
using TestTask.Services.Interfaces;
using TestTask.Data;
using Microsoft.EntityFrameworkCore;

namespace TestTask.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDbContext _context;

        public AuthorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Author> GetAuthor()
        {
            var titles = await _context.Books.Select(b => b.Title).ToListAsync();

            var books = _context.Books.
                Where(title => title.Title.Length == titles.OrderByDescending(s => s.Length).First().Length);

            var authors = await _context.Authors
                .Where(a => books.Any(b => b.AuthorId == a.Id))
                .ToListAsync();

            var author = authors.OrderByDescending(s => s.Id).Last();

            Console.WriteLine(author.Name);

            return author;
        }

        public async Task<List<Author>> GetAuthors()
        {
            var authorsBooks = await _context.Books
               .Where(b => b.PublishDate > new DateTime(2016, 01, 01))
               .GroupBy(b => b.AuthorId)
               .Where(g => g.Count() % 2 == 0)
               .Select(g => g.Key)
               .ToListAsync();

            var authors = await _context.Authors
                .Where(a => authorsBooks.Contains(a.Id))
                .ToListAsync();

            return authors;
        }
    }
}
