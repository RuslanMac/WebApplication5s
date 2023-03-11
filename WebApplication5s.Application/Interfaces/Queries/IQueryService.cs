using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WebApplication5s.Application.Interfaces.Queries
{
    public interface IQueryService<TEntity, T>
    {
        Task<T> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<T>> GetAllAsync();

    }
}
