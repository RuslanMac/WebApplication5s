using AutoMapper;

using System.Linq;
using WebApplication5s.Application.Dtos.Queries;
using WebApplication5s.Application.Interfaces.Mappings;
using WebApplication5s.Domain.Models;

namespace WebApplication5s.Application.Infrasctructure
{
    public class AutoMapperConfigurations : IHaveCustomMapping
    {
        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Product, ProductDto>();
            configuration.CreateMap<Category, CategoryDto>();
            configuration.CreateMap<ProductImage, ProductImageDto>(); 
          
         
        }
    }
}
