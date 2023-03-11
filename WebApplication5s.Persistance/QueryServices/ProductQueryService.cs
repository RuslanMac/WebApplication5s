using AutoMapper;

using Gaslighter.PERSISTENCE.Services.Queries;
using Microsoft.EntityFrameworkCore;
using System;

using System.Linq;

using System.Threading.Tasks;
using WebApplication5s.Application.Dtos.Queries;
using WebApplication5s.Application.Interfaces.Queries;
using WebApplication5s.Domain.Models;
using WebApplication5s.Persistance;

namespace Gaslighter.PERSISTENCE.QueryServices
{
    public class ProductQueryService : QueryService<Product, ProductDto>, IProductQueryService
    {
        public ProductQueryService(AppDbContext context, IMapper mapper)
             : base(context, mapper) { }

  

        protected override IQueryable<Product> GetAggreagteQueryable()
        {

            return _dbSet.Include(product => product.Images);
        } 

    }
}
