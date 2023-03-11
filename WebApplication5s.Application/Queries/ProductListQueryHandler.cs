using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApplication5s.Application.Dtos.Queries;
using WebApplication5s.Application.Interfaces.Queries;

namespace WebApplication5s.Application.Queries
{
    public class ProductListQueryHandler : IRequestHandler<ProductListQuery, List<ProductDto>>
    {
        private readonly IProductQueryService _service;
        public ProductListQueryHandler(IProductQueryService service)
        {
            _service = service;
        }

        public async Task<List<ProductDto>> Handle(ProductListQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync();
        }
    }
}
