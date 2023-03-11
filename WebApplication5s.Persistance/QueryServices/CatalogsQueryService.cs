using AutoMapper;
using Gaslighter.PERSISTENCE.Services.Queries;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApplication5s.Application;
using WebApplication5s.Application.Dtos.Queries;
using WebApplication5s.Application.Interfaces.Queries;
using WebApplication5s.Domain.Models;

namespace WebApplication5s.Persistance.QueryServices
{
    public class CatalogsQueryService : QueryService<Category, CategoryDto>, ICategoryQueryService
    {
         public CatalogsQueryService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }

       
    }
}
