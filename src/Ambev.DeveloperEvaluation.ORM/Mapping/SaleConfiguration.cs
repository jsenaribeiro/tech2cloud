using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : BaseConfiguration<Sale, int>
{
   public override void Configure(EntityTypeBuilder<Sale> builder)
   {
      base.Configure(builder);
      builder.ToTable("Sales");
      builder.HasKey(s => s.Id);

      builder.Property(s => s.Id)
             .HasColumnName("Id")
             .IsRequired();

      builder.Property(s => s.CartId)
             .HasColumnName("CartId")
             .IsRequired();

      builder.Property(s => s.Date)
             .HasColumnName("Date")
             .IsRequired();

      builder.Property(s => s.Amount)
             .HasColumnName("Amount")
             .IsRequired()
             .HasColumnType("decimal(18,2)");

      builder.Property(s => s.Discounts)
             .HasColumnName("Discounts")
             .IsRequired()
             .HasColumnType("decimal(18,2)");
             
      builder.Property(s => s.FullPrice)
             .HasColumnName("FullPrice")
             .IsRequired()
             .HasColumnType("decimal(18,2)");
   }
}
