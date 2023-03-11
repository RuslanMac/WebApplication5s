using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication5s.Application.Dtos.Queries
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public decimal Price { get; set; }
        public long CategoryId { get; set; }

        public List<ProductImageDto> Images { get; set; }  
    }
}
