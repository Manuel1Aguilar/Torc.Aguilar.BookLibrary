using Torc.Aguilar.BookLibrary.Core.Entities;
using Torc.Aguilar.BookLibrary.Models;

namespace Torc.Aguilar.BookLibrary.Core.Interfaces.Services
{
    public interface IBaseService<T, TId, TDto> where T : BaseEntity<TId>
    {
        Task<Result<IEnumerable<TDto>>> GetAll();
        Task<Result<TDto>> GetById(TId id);
        Task<Result<TDto>> GetByIdDisconected(TId id);
        Task<Result<TId>> Add(TDto dto);
        Task<Result<bool>> Update(TDto dto);
        Task<Result<bool>> Delete(TId id);
    }
}
