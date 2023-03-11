using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication5s.Application.Dtos.Queries
{
    public class CategoryListQuery : IRequest<List<CategoryDto>> 
    {
    }
}
