using AutoMapper;
using Torc.Aguilar.BookLibrary.Core.Entities;
using Torc.Aguilar.BookLibrary.Core.Interfaces.Repositories;
using Torc.Aguilar.BookLibrary.Core.Interfaces.Services;
using Torc.Aguilar.BookLibrary.DTOs;

namespace Torc.Aguilar.BookLibrary.Services
{
    public class BookService : BaseService<Book, int, BookDto>, IBookService
    {
        public BookService(IBookRepository repo, IMapper mapper) : base(repo, mapper)
        {
        }
    }
}
