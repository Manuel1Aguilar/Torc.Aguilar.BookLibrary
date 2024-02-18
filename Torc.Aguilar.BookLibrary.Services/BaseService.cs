using AutoMapper;
using Torc.Aguilar.BookLibrary.Core.Entities;
using Torc.Aguilar.BookLibrary.Core.Interfaces.Repositories;
using Torc.Aguilar.BookLibrary.Core.Interfaces.Services;
using Torc.Aguilar.BookLibrary.Models;

namespace Torc.Aguilar.BookLibrary.Services
{
    public class BaseService<T, TId, TDto> : IBaseService<T, TId, TDto> where T : BaseEntity<TId>
    {
        internal readonly IBaseRepository<T, TId> _repo;

        internal readonly IMapper _mapper;

        public BaseService(IBaseRepository<T, TId> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public virtual async Task<Result<IEnumerable<TDto>>> GetAll()
        {
            try
            {
                return Result<IEnumerable<TDto>>.Success(_mapper.Map<IEnumerable<TDto>>(await _repo.GetAll()));
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<TDto>>.Fail($"Error getting all the entities : {ex.Message}");
            }
        }

        public virtual async Task<Result<TDto>> GetById(TId id)
        {
            try
            {
                return Result<TDto>.Success(_mapper.Map<TDto>(await _repo.GetById(id)));
            }
            catch (Exception ex)
            {
                return Result<TDto>.Fail($"Error getting the entity : {ex.Message}");
            }
        }

        public virtual async Task<Result<TDto>> GetByIdDisconected(TId id)
        {
            try
            {
                return Result<TDto>.Success(_mapper.Map<TDto>(await _repo.GetByIdDisconected(id)));
            }
            catch (Exception ex)
            {
                return Result<TDto>.Fail($"Error getting the entity : {ex.Message}");
            }
        }

        public virtual async Task<Result<TId>> Add(TDto dto)
        {
            try
            {
                T t = _mapper.Map<T>(dto);
                await _repo.Add(t);
                return Result<TId>.Success(t.Id);
            }
            catch (Exception ex)
            {
                return Result<TId>.Fail($"Error adding the entity : {ex.Message}");
            }
        }

        public virtual async Task<Result<bool>> Update(TDto dto)
        {
            try
            {
                T t = _mapper.Map<T>(dto);
                await _repo.Update(t);
                return Result<bool>.Success(true);

            }
            catch (Exception ex)
            {
                return Result<bool>.Fail($"Error updating the entity : {ex.Message}");
            }
        }

        public virtual async Task<Result<bool>> Delete(TId id)
        {
            try
            {
                return Result<bool>.Success(await _repo.Delete(id));
            }
            catch (Exception ex)
            {
                return Result<bool>.Fail($"Error deleting the entity : {ex.Message}");
            }
        }
    }
}