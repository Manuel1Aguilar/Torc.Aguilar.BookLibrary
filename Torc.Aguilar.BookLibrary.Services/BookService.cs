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

        public async Task<Result<PaginatedResult<BookGridModel>>> GetFiltered(BookFilter filter, int page, int pageSize)
        {
            try
            {

                int skip = pageSize * page;
                List<BookGridModel> values = _mapper.Map<List<BookGridModel>>(await _bookRepository.GetFiltered(filter.Author, filter.ISBN, filter.Status, skip, pageSize));
                int count = await _bookRepository.GetFilteredCount(filter.Author, filter.ISBN, filter.Status);
                return Result<PaginatedResult<BookGridModel>>.Success(new PaginatedResult<BookGridModel>(page, pageSize, count, values));
            }
            catch (Exception ex)
            {
                return Result<PaginatedResult<BookGridModel>>.Fail($"Error filtering books: {ex.Message}");
            }
        }
    }
}
