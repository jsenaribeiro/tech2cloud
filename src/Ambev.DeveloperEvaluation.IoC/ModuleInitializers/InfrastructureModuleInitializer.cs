using Ambev.DeveloperEvaluation.Common.Broker;
using Ambev.DeveloperEvaluation.Domain;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers;

public class InfrastructureModuleInitializer : IModuleInitializer
{
   public void Initialize(WebApplicationBuilder builder)
   {
      builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<PostgreContext>());
      builder.Services.AddScoped<IProductRepository, ProductRepository>();
      builder.Services.AddScoped<ICartRepository, CartRepository>();
      builder.Services.AddScoped<IUserRepository, UserRepository>();
      builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

      AddMongoContext(builder);
      AddPostgreContext(builder);
      AddRedisCache(builder);
   }

   private void AddPostgreContext(WebApplicationBuilder builder)
   {
      builder.Services.AddDbContext<PostgreContext>(options =>
         options.UseNpgsql(
            builder.Configuration.GetConnectionString("PostgreSQL"),
            b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.ORM")
         )
      );
   }

   private void AddMongoContext(WebApplicationBuilder builder)
   {
      builder.Services.AddSingleton(sp =>
      {
         var configuration = sp.GetRequiredService<IConfiguration>();
         var connection = configuration.GetConnectionString("MongoDB");
         var database = connection!.Split('/').LastOrDefault() ?? "admin";
         var domain = connection.Replace('/' + database, string.Empty);
         
         return new MongoContext(domain, database);
      });
   }

   private void AddRedisCache(WebApplicationBuilder builder)
   {
      builder.Services.AddStackExchangeRedisCache(options =>
         options.Configuration = builder.Configuration.GetConnectionString("Redis"));

      builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
         ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis")!));

      builder.Services.AddSingleton<IRedisPublisher, RedisPublisher>();
   }
}