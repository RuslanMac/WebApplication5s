using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication5s.Domain.Models;

namespace WebApplication5s.Persistance.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category > entityTypeBuilder)
        {
            entityTypeBuilder.Property(x => x.Parameters).HasJsonConversion();
        }
    }
}
