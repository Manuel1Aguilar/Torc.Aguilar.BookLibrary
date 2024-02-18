using Microsoft.EntityFrameworkCore;
using Torc.Aguilar.BookLibrary.Core.Entities;
using Torc.Aguilar.BookLibrary.Core.Interfaces.Repositories;
using Torc.Aguilar.BookLibrary.Infrastructure.Data;

namespace Torc.Aguilar.BookLibrary.Infrastructure.Repositories
{
    public class BaseRepository<T, TId> : IBaseRepository<T, TId> where T : BaseEntity<TId>
    {
        internal readonly BookLibraryContext _context;
        private DbSet<T> _entities;

        public BaseRepository(BookLibraryContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public virtual async Task<T?> GetById(TId id)
        {
            return await _entities.FindAsync(id);
        }

        public virtual async Task<T?> GetByIdDisconected(TId id)
        {
            return await _entities.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<TId> Add(T entity)
        {
            _entities.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public virtual async Task Update(T entity)
        {
                _entities.Update(entity);
                await _context.SaveChangesAsync();
        }

        public virtual async Task<bool> Delete(TId id)
        {
            T entity = await GetById(id);
            if(entity == null)
            {
                return false;
            }
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}