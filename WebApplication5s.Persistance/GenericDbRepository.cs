using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApplication5s.Application.Interfaces.Repositories;

namespace WebApplication5s.Persistance
{
    public class GenericDbRepository<T> : IDbRepository<T> where T : class
    {
        protected AppDbContext _appDbContext;
        protected readonly DbSet<T> _dbSet;

        public GenericDbRepository(AppDbContext context)
        {
            _appDbContext = context;
            _dbSet = _appDbContext.Set<T>(); 
        }
        public async Task AddAsync(T item)
        {
            await _dbSet.AddAsync(item);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(List<T> items)
        {
           await _dbSet.AddRangeAsync(items);
           await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => _dbSet.Update(entity));
            await _appDbContext.SaveChangesAsync(); 
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefaultAsync(predicate); 
        }

        public Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T> Remove(T item)
        {
            var entity = await Task.Run(() => _dbSet.Remove(item).Entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }

        protected virtual IQueryable<T> GetAggreagteQueryable() => _dbSet;
    }
}
