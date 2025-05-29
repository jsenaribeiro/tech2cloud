using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class UserConfiguration : BaseConfiguration<User, int>
{
   public override void Configure(EntityTypeBuilder<User> builder)
   {
      base.Configure(builder);

      builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
      builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
      builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
      builder.Property(u => u.Phone).HasMaxLength(20);

      builder.Property(u => u.Status)
          .HasConversion<string>()
          .HasMaxLength(20);

      builder.Property(u => u.Role)
          .HasConversion<string>()
          .HasMaxLength(20);

      builder.Property(u => u.CreatedAt).IsRequired();
      builder.Property(u => u.UpdatedAt).IsRequired(false);

      builder.HasIndex(u => u.Username).IsUnique();
      builder.HasIndex(u => u.Email).IsUnique();
      builder.HasIndex(u => u.Phone).IsUnique();

      builder.OwnsOne(u => u.Name, n =>
      {
         n.Property(x => x.FirstName).IsRequired().HasMaxLength(50).HasColumnName("FirstName");
         n.Property(x => x.LastName).IsRequired().HasMaxLength(50).HasColumnName("LastName");
      });   

      builder.OwnsOne(u => u.Address, a =>
      {
         a.Property(x => x.Number).IsRequired().HasColumnName("AddressNumber");
         a.Property(x => x.Street).IsRequired().HasMaxLength(50).HasColumnName("AddressStreet");
         a.Property(x => x.City).IsRequired().HasMaxLength(50).HasColumnName("AddressCity");
         a.Property(x => x.State).IsRequired().HasMaxLength(50).HasColumnName("AddressState");
         a.Property(x => x.Country).IsRequired().HasMaxLength(50).HasColumnName("AddressCountry");
         a.Property(x => x.ZipCode).IsRequired().HasMaxLength(10).HasColumnName("AddressZipCode")
          .HasConversion(v => v, v => Regex.Replace(v, @"[^\d]", string.Empty)); // Remove non-numeric characters
          
         a.OwnsOne(x => x.Geolocation, geo =>
         {
            geo.Property(g => g.Latitude).HasColumnName("AddressGeolocationLatitude");
            geo.Property(g => g.Longitude).HasColumnName("AddressGeolocationLongitude");
         });
      });
   }
}
