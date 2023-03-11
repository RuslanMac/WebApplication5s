using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApplication5s.Application.Interfaces;
using WebApplication5s.Domain.Models;

namespace WebApplication5s.Persistance
{
    public class CategoryDbRepository : GenericDbRepository<Category>
    {
        public CategoryDbRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        
    }
}
