using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication5s.Application.Dtos.Queries
{
    public class ProductQuery :IRequest<ProductDto>
    {
        public long Id { get; set; } 
    }
}
