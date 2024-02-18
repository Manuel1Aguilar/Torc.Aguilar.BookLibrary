using Torc.Aguilar.BookLibrary.Core.Entities;

namespace Torc.Aguilar.BookLibrary.Core.Interfaces.Repositories
{
    public interface IBookRepository : IBaseRepository<Book, int>
    {
        Task<List<Book>?> GetFiltered(string? author, string? isbn, string? status, int skip, int take);
        Task<int> GetFilteredCount(string? author, string? isbn, string? status);
    }
}
