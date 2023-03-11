using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication5s.Application.Commands
{
    public class DeleteCategoryCommand : IRequest<long>
    {
        public long Id { get; set; } 
    }
}
