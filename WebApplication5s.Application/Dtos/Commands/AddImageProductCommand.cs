using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication5s.Application.Dtos.Commands
{
    public class AddImageProductCommand : IRequest<long> 
    {
        public long ProductId { get; set; }
        public byte[] Image { get; set; }
    }
}
