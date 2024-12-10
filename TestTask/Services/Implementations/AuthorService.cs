using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        public Task<Author> GetAuthor()
        {
            throw new NotImplementedException();
        }

        public Task<List<Author>> GetAuthors()
        {
            throw new NotImplementedException();
        }
    }
}
