using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM;

using ContextOptions = DbContextOptions<PostgreContext>;

public class PostgreContext : DbContext
{
   public DbSet<User> Users { get; set; }

   public DbSet<Cart> Carts { get; set; }

   public DbSet<Sale> Sales { get; set; }

   public DbSet<Product> Products { get; set; }

   public DbSet<CartProduct> CartProducts { get; set; }

   public PostgreContext(ContextOptions options) : base(options) { }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

      base.OnModelCreating(modelBuilder);
   }
}
public class YourDbContextFactory : IDesignTimeDbContextFactory<PostgreContext>
{
   public PostgreContext CreateDbContext(string[] args)
   {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<PostgreContext>();
      var connectionString = configuration.GetConnectionString("PostgreSQL");

      builder.UseNpgsql(
             connectionString,
             b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.ORM")
      );

      return new PostgreContext(builder.Options);
   }
}