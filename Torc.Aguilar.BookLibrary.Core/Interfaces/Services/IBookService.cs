using Torc.Aguilar.BookLibrary.Core.Entities;
using Torc.Aguilar.BookLibrary.Models;
using Torc.Aguilar.BookLibrary.Models.DTOs;
using Torc.Aguilar.BookLibrary.Models.Filters;

namespace Torc.Aguilar.BookLibrary.Core.Interfaces.Services
{
    public interface IBookService : IBaseService<Book, int, BookDto>
    {
        Task<Result<List<BookDto>>> GetFiltered(BookFilter filter);
    }
}
