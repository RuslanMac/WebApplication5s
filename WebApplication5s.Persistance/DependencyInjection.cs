using Gaslighter.PERSISTENCE.QueryServices;
using Gaslighter.PERSISTENCE.Services.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication5s.Application.Dtos.Queries;
using WebApplication5s.Application.Interfaces.Queries;
using WebApplication5s.Application.Interfaces.Repositories;

using WebApplication5s.Domain.Models;
using WebApplication5s.Persistance.QueryServices;

namespace WebApplication5s.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ICategoryQueryService, CatalogsQueryService>();
            services.AddScoped<IProductQueryService, ProductQueryService>();
            services.AddScoped(typeof(IQueryService<,>), typeof(QueryService<,>));
            services.AddScoped(typeof(IDbRepository<>), typeof(GenericDbRepository<>));
            services.AddScoped<IDbRepository<Category>, CategoryDbRepository>(); 
            services.AddScoped<IQueryService<Product, ProductDto>, ProductQueryService>();

           
           // _migrateDb(configuration);


            return services; 

        }

        private static void _migrateDb(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            using (var context = new AppDbContext(optionsBuilder.Options))
            {
                context.Database.Migrate();
            }
        }
    }
}
