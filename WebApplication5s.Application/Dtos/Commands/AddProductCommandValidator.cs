using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication5s.Application.Dtos.Commands
{
    public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Price).GreaterThan(0);
        }
    }
}
