using AutoMapper;
using Torc.Aguilar.BookLibrary.Core.Entities;
using Torc.Aguilar.BookLibrary.Core.Interfaces.Repositories;
using Torc.Aguilar.BookLibrary.Core.Interfaces.Services;
using Torc.Aguilar.BookLibrary.Models;
using Torc.Aguilar.BookLibrary.Models.Book;
using Torc.Aguilar.BookLibrary.Models.DTOs;
using Torc.Aguilar.BookLibrary.Models.Utilities;

namespace Torc.Aguilar.BookLibrary.Services
{
    public class BookService : BaseService<Book, int, BookDto>, IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository repo, IMapper mapper) : base(repo, mapper)
        {
            _bookRepository = repo;
        }

        public async Task<Result<PaginatedResult<BookDto>>> GetFiltered(BookFilter filter, int page, int pageSize)
        {
            try
            {

                int skip = pageSize * page;
                List<BookDto> values = _mapper.Map<List<BookDto>>(await _bookRepository.GetFiltered(filter.Author, filter.ISBN, filter.Status, skip, pageSize));
                int count = await _bookRepository.GetFilteredCount(filter.Author, filter.ISBN, filter.Status);
                return Result<PaginatedResult<BookDto>>.Success(new PaginatedResult<BookDto>(page, pageSize, count, values));
            }
            catch (Exception ex)
            {
                return Result<PaginatedResult<BookDto>>.Fail($"Error filtering books: {ex.Message}");
            }
        }
    }
}
