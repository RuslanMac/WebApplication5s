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

    public class ProductQueryHandler : IRequestHandler<ProductQuery, ProductDto>
    {
        private readonly IQueryService<Product, ProductDto> _queryService;

        public ProductQueryHandler(IQueryService<Product, ProductDto> queryService)
        {
            _queryService = queryService ?? throw new ArgumentNullException(nameof(queryService));
        }

        public async Task<ProductDto> Handle(ProductQuery request, CancellationToken cancellationToken)
        {
            ProductDto product;
            product = await _queryService.GetAsync(o => o.Id == request.Id);
            return product;
        }
    }
}
