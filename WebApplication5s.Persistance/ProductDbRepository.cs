using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplication5s.Domain.Models;

namespace WebApplication5s.Persistance
{
    public class ProductDbRepository : GenericDbRepository<Product>
    {
        public ProductDbRepository(AppDbContext context) : base (context)
        {

        }

        protected override IQueryable<Product> GetAggreagteQueryable() =>
            _dbSet.Include(order => order.Images); 
                      
    }
}
