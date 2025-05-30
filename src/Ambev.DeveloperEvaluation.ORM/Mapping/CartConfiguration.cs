using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class CartConfiguration : BaseConfiguration<Cart, int>
{
   public override void Configure(EntityTypeBuilder<Cart> builder)
   {
      base.Configure(builder);

      builder.Property(p => p.UserId).IsRequired();
      builder.Property(p => p.Date).IsRequired();
   }
}
