using Torc.Aguilar.BookLibrary.Core.Entities;
using Torc.Aguilar.BookLibrary.DTOs;

namespace Torc.Aguilar.BookLibrary.Core.Interfaces.Services
{
    public interface IBookService : IBaseService<Book, int, BookDto>
    {
    }
}
