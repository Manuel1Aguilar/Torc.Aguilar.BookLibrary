using Torc.Aguilar.BookLibrary.Core.Entities;
using Torc.Aguilar.BookLibrary.Models;
using Torc.Aguilar.BookLibrary.Models.Book;
using Torc.Aguilar.BookLibrary.Models.DTOs;
using Torc.Aguilar.BookLibrary.Models.Utilities;

namespace Torc.Aguilar.BookLibrary.Core.Interfaces.Services
{
    public interface IBookService : IBaseService<Book, int, BookDto>
    {
        Task<Result<PaginatedResult<BookGridModel>>> GetFiltered(BookFilter filter, int page, int pageSize);
    }
}
