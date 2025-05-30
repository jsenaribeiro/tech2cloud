using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM;

using ContextOptions = DbContextOptions<DefaultContext>;

public class DefaultContext : DbContext
{
   public DbSet<User> Users { get; set; }

   public DbSet<Cart> Carts { get; set; }

   public DbSet<Product> Products { get; set; }

   public DefaultContext(ContextOptions options) : base(options) { }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

      base.OnModelCreating(modelBuilder);
   }
}
public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
{
   public DefaultContext CreateDbContext(string[] args)
   {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<DefaultContext>();
      var connectionString = configuration.GetConnectionString("PostgreSQL");

      builder.UseNpgsql(
             connectionString,
             b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.ORM")
      );

      return new DefaultContext(builder.Options);
   }
}