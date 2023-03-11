using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApplication5s.Application.Interfaces.Repositories;
using WebApplication5s.Domain.Models;

namespace WebApplication5s.Application.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, long>
    {
        private readonly IDbRepository<Category> _categoryDbRepository;
        public DeleteCategoryCommandHandler(IDbRepository<Category> categoryDbRepository)
        {
               _categoryDbRepository = categoryDbRepository;
        }
        public async Task<long> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryDbRepository.GetAsync(x => x.Id == request.Id);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            await _categoryDbRepository.Remove(category);

            return category.Id;
        }
    }
}
