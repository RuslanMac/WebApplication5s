using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApplication5s.Application.Dtos.Queries;
using WebApplication5s.Application.Interfaces.Queries;
using WebApplication5s.Domain.Models;

namespace WebApplication5s.Application
{

    public class CategoryListQueryHandler : IRequestHandler<CategoryListQuery, List<CategoryDto>>
    {
        private readonly IQueryService<Category, CategoryDto> _queryService;

        public CategoryListQueryHandler(IQueryService<Category, CategoryDto> queryService)
        {
            _queryService = queryService ?? throw new ArgumentNullException(nameof(queryService));
        }

        public async Task<List<CategoryDto>> Handle(CategoryListQuery request, CancellationToken cancellationToken)
        {
            List<CategoryDto> categories = new List<CategoryDto>();
            categories = await _queryService.GetAllAsync();
            return categories;
        }
    }
}
