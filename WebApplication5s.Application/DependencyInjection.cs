using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using WebApplication5s.Application.Commands;
using WebApplication5s.Application.Dtos.Commands;
using WebApplication5s.Application.Infrasctructure;
using WebApplication5s.Application.Infrasctructure.Behaviours;
using WebApplication5s.Application.Middleware;

namespace WebApplication5s.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            serviceCollection.AddTransient<ExceptionHandlingMiddleware>();
            serviceCollection.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });
            AssemblyScanner.FindValidatorsInAssembly(typeof(AddProductCommand).Assembly)
            .ForEach(item => serviceCollection.AddScoped(item.InterfaceType, item.ValidatorType));
            serviceCollection.AddMediatR((MediatRServiceConfiguration configuration) => configuration.RegisterServicesFromAssembly(typeof(AddProductCommandHandler).GetTypeInfo().Assembly));
            serviceCollection.AddMediatR((MediatRServiceConfiguration configuration) => configuration.RegisterServicesFromAssembly(typeof(AddImageProductCommand).GetTypeInfo().Assembly));
        }
    }
}
