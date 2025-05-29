using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public abstract class BaseConfiguration<E, I> : IEntityTypeConfiguration<E>
    where E : BaseEntity<I>
    where I : struct, IComparable
{
   public virtual void Configure(EntityTypeBuilder<E> builder)
   {
      builder.ToTable(typeof(E).Name + "s");

      builder.HasKey(u => u.Id);
      builder.Property(u => u.Id).ValueGeneratedOnAdd();

      builder.Property(p => p.CreatedAt).IsRequired();
      builder.Property(p => p.UpdatedAt);
   }
}