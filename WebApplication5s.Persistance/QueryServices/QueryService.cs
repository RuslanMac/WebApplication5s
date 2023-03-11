using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebApplication5s.Persistance;
using WebApplication5s.Application.Interfaces.Queries;

namespace Gaslighter.PERSISTENCE.Services.Queries
{
    public class QueryService<TEntity, T> : IQueryService<TEntity, T> where TEntity : class
    {
        protected readonly AppDbContext _context;
        protected readonly IMapper _mapper;
        protected readonly DbSet<TEntity> _dbSet;

        public QueryService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbSet = _context.Set<TEntity>();
        }

        public async virtual Task<T> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await GetAggreagteQueryable().FirstOrDefaultAsync(predicate);
            return _mapper.Map<TEntity, T>(entity);
        }

      
        public async Task<List<T>> GetAllAsync()
        {
           
            var somes = await GetAggreagteQueryable().AsNoTracking().ToListAsync();
            var result = somes.Select(some => _mapper.Map<TEntity, T>(some)).ToList();
            return result;
        }

        protected virtual IQueryable<TEntity> GetAggreagteQueryable() => _dbSet;

       
    }
}
