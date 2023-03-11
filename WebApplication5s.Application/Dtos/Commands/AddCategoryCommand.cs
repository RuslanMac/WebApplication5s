using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication5s.Domain.Models;

namespace WebApplication5s.Application.Dtos.Commands
{
   public  class AddCategoryCommand : IRequest<long>
   {
        public AddCategoryCommand()
        {

        }
        public string Name { get; set; }  

        public List<string> Parameters { get; set; } 
      
   }
}
