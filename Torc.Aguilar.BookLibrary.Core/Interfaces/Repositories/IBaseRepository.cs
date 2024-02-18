using Torc.Aguilar.BookLibrary.Core.Entities;

namespace Torc.Aguilar.BookLibrary.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T, TId> where T : BaseEntity<TId>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(TId id);
        Task<T?> GetByIdDisconected(TId id);
        Task<TId> Add(T entity);
        Task Update(T entity);
        Task<bool> Delete(TId id);
    }
}
