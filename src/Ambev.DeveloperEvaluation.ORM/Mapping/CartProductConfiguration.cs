using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class CartProductConfiguration : BaseConfiguration<CartProduct, int>
{
   public override void Configure(EntityTypeBuilder<CartProduct> builder)
   {
      base.Configure(builder);

      builder.Property(p => p.Quantity).IsRequired();
      builder.Property(p => p.ProductId).IsRequired();
      builder.Property(p => p.CartId).IsRequired();

      builder.HasOne<Cart>()
             .WithMany(c => c.Products)
             .HasForeignKey(cp => cp.CartId)
             .OnDelete(DeleteBehavior.Cascade);
   }
}
