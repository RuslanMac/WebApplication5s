using System;
using System.Collections.Generic;
using System.Text;
using WebApplication5s.Application.Dtos.Queries;
using WebApplication5s.Domain.Models;

namespace WebApplication5s.Application.Interfaces.Queries
{
    public interface ICategoryQueryService : IQueryService<Category, CategoryDto> 
    {
    }
}
