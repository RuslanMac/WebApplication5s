using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication5s.Domain.Models;

namespace WebApplication5s.Application.Dtos.Commands
{
    public class AddProductCommand : IRequest<long>
    { 
        public string Name { get; set; }   
        public string Description { get; set; } 

        public decimal Price { get; set; }   

        public long CategoryId { get; set; } 

        public Dictionary<string, string> Parameters { get; set; } 
        

    }
}
