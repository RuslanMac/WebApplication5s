using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using WebApplication5s.Domain.Models;
using WebApplication5s.Persistance.EntityConfigurations;

namespace WebApplication5s.Persistance
{
    public class AppDbContext: DbContext
    {   
        public DbSet<Product> Products { get; set; }  
        public DbSet<Category> Categories { get; set; } 
        public DbSet<ProductImage> ProductImages { get; set; } 

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
