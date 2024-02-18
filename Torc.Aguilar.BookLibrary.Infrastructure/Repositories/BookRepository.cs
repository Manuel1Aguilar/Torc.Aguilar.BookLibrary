using Microsoft.EntityFrameworkCore;
using Torc.Aguilar.BookLibrary.Core.Entities;
using Torc.Aguilar.BookLibrary.Core.Interfaces.Repositories;
using Torc.Aguilar.BookLibrary.Infrastructure.Data;

namespace Torc.Aguilar.BookLibrary.Infrastructure.Repositories
{
    public class BookRepository : BaseRepository<Book, int>, IBookRepository
    {
        public BookRepository(BookLibraryContext context) : base(context)
        {
        }

        public async Task<List<Book>?> GetFiltered(string? author, string? isbn, string? status)
        {
            var query = _context.Books.AsQueryable();
            if (!string.IsNullOrEmpty(author))
            {
                query = query.Where(x => x.FirstName.Contains(author) || x.LastName.Contains(author));
            }
            if (!string.IsNullOrEmpty(isbn))
            {
                query = query.Where(x => x.ISBN.Contains(isbn));
            }
            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(x => x.Status.Contains(status));
            }

            return await query.ToListAsync();
        }
    }
}
