using Destrix.Domain.Interfaces.Repositories.Base;
using Destrix.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace Destrix.Infra.Data.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DestrixPostgreContext _context;
        protected readonly DbSet<T> _db;

        public BaseRepository(DestrixPostgreContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task<T> GetByAsync(Expression<Func<T, bool>> where)
        {
            return await _db.Where(where).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> ListByAsync(Expression<Func<T, bool>> where)
        {
            return await _db.Where(where).ToListAsync();
        }

        public async Task<decimal> SumByAsync(Expression<Func<T, bool>> where, Expression<Func<T, decimal>> field)
        {
            return await _db.Where(where).SumAsync(field);
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> where) => await _db.AnyAsync(where);

        public bool Add(T entity)
        {
            _db.Add(entity);
            return true;
        }

        public async Task<(bool, int)> InsertAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            int id = 0;
            PropertyInfo prop = entity.GetType().GetProperty("Id");

            if (prop != null)
            {
                id = Convert.ToInt32(prop.GetValue(entity, null));
            }

            return (true, id);
        }

        public bool Update(T entity)
        {
            _db.Update(entity);
            return true;
        }

        public bool Delete(T entity)
        {
            _db.Remove(entity);
            return true;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
