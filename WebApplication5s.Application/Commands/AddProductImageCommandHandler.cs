using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using WebApplication5s.Application.Dtos.Commands;
using WebApplication5s.Domain.Models;
using WebApplication5s.Application.Interfaces.Repositories;

namespace WebApplication5s.Application.Commands
{
    public class AddImageProductCommandHandler : IRequestHandler<AddImageProductCommand, long>
    {
        private readonly IDbRepository<Product> _dbProductRepository;
        public AddImageProductCommandHandler(IDbRepository<Product> dbProductRepository)
        {
            _dbProductRepository = dbProductRepository ?? throw new ArgumentNullException(nameof(dbProductRepository));
        }
        public async Task<long> Handle(AddImageProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _dbProductRepository.GetAsync(x => x.Id == request.ProductId);
            product.AddImage(new ProductImage(request.Image, request.ProductId));
            await _dbProductRepository.UpdateAsync(product);
            return product.Id;
        }
    }
}
