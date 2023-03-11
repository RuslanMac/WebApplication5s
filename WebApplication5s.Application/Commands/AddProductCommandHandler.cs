using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApplication5s.Application.Dtos.Commands;
using WebApplication5s.Application.Dtos.Queries;
using WebApplication5s.Application.Interfaces.Queries;
using WebApplication5s.Application.Interfaces.Repositories;
using WebApplication5s.Domain.Models;

namespace WebApplication5s.Application.Commands
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, long>
    {
        private readonly IDbRepository<Product> _dbProductRepository;
        private readonly ICategoryQueryService _service;
        
        public AddProductCommandHandler(IDbRepository<Product> dbProductRepository, ICategoryQueryService service)
        {
            _dbProductRepository = dbProductRepository;
            _service = service;
        }
        public async Task<long> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Price, request.CategoryId);
            var category = await _service.GetAsync(x => x.Id == request.CategoryId);

            if (category == null)
                throw new Exception("Category not found");

            foreach(var parameter in request.Parameters)
            {
                if (category.Parameters.Contains(parameter.Key))
                {
                    product.Parameters.Add(parameter.Key, parameter.Value);
                }
                else
                {
                    throw new Exception($"The parameter {parameter} is not presented in this category {category.Name}");
                }

            }

            await _dbProductRepository.AddAsync(product);
            return product.Id;
        }
    }
}
