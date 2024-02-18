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
    }
}
