using System.Linq.Expressions;

namespace ZepterTask.Infrastructure.Repositories;

public interface IGenericRepository<T> where T : class
{
   Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
   Task<IEnumerable<T>> GetAllAsync();
   Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate);

   Task AddAsync(T item);
   Task UpdateAsync(T item);
   Task RemoveAsync(T item);
}