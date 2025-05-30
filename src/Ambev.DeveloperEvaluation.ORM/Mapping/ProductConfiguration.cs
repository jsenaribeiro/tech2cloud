using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : BaseConfiguration<Product, int>
{
   public override void Configure(EntityTypeBuilder<Product> builder)
   {
      base.Configure(builder);
      
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
