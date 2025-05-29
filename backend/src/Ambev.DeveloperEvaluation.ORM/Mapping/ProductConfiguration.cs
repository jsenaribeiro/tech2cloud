using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
   public void Configure(EntityTypeBuilder<Product> builder)
   {
      builder.ToTable("Products");

      builder.HasKey(u => u.Id);
      builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

      builder.Property(p => p.Title).IsRequired();
      builder.Property(p => p.Price).IsRequired();
      builder.Property(p => p.Description).IsRequired();
      builder.Property(p => p.Category).IsRequired();
      builder.Property(p => p.Image).IsRequired();
      builder.OwnsOne(p => p.Rating, x =>
      {
         x.Property(r => r.Rate).HasColumnName("RatingRate");
         x.Property(r => r.Count).HasColumnName("RatingCount");
      });
   }
}
