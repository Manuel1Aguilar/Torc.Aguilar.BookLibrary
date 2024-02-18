using AutoMapper;
using Torc.Aguilar.BookLibrary.Core.Entities;
using Torc.Aguilar.BookLibrary.Core.Interfaces.Repositories;
using Torc.Aguilar.BookLibrary.Core.Interfaces.Services;
using Torc.Aguilar.BookLibrary.Models;
using Torc.Aguilar.BookLibrary.Models.DTOs;
using Torc.Aguilar.BookLibrary.Models.Filters;

namespace Torc.Aguilar.BookLibrary.Services
{
    public class BookService : BaseService<Book, int, BookDto>, IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository repo, IMapper mapper) : base(repo, mapper)
        {
            _bookRepository = repo;
        }

        public async Task<Result<List<BookDto>>> GetFiltered(BookFilter filter)
        {
            try
            {
                return Result<List<BookDto>>.Success(_mapper.Map<List<BookDto>>(await _bookRepository.GetFiltered(filter.Author, filter.ISBN, filter.Status)));
            }
            catch (Exception ex)
            {
                return Result<List<BookDto>>.Fail($"Error filtering books: {ex.Message}");
            }
        }
    }
}
