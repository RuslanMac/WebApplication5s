using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication5s.Application.Interfaces.Repositories
{
    public interface IDbRepository<T> where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T item);
        Task AddRangeAsync(List<T> items);
        Task<T> Remove(T item);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity">entity</param>
        Task UpdateAsync(T entity);
    }
}
