using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApplication5s.Application.Dtos.Commands;
using WebApplication5s.Application.Interfaces.Repositories;
using WebApplication5s.Domain.Models;

namespace WebApplication5s.Application.Commands
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, long>
    {
        private IDbRepository<Category> _dbRepository; 

        public AddCategoryCommandHandler(IDbRepository<Category> dbRepository)
        {
            _dbRepository = dbRepository ?? throw new NotImplementedException();  
        }
        public async Task<long> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Name);
            foreach(var p in request.Parameters)
            {
                category.AddParameter(p);
            }

            await _dbRepository.AddAsync(category);
            return category.Id;
        }
    }
}
