using System.Linq.Expressions;

namespace Destrix.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        Task<T> GetByAsync(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> ListByAsync(Expression<Func<T, bool>> where);
        Task<decimal> SumByAsync(Expression<Func<T, bool>> where, Expression<Func<T, decimal>> field);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> where);
        Task<(bool, int)> InsertAsync(T entity);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        Task<bool> Commit();

    }
}
