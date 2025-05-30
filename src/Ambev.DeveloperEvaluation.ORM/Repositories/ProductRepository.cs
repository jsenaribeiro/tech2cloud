using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Values;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IProductRepository using Entity Framework Core
/// </summary>
public class ProductRepository : Repository<Product, int>, IProductRepository
{
   /// <summary>
   /// Initializes a new instance of ProductRepository
   /// </summary>
   /// <param name="context">The database context</param>
   public ProductRepository(IServiceProvider provider) : base(provider) { }

   /// <summary>
   /// Retrieves all categories of products
   /// </summary>
   /// <returns>Product categories</returns>
   public async Task<string[]> ListAllCategoriesAsync()
   {
      var categories = await collection.Select(x => x.Category).ToListAsync();
      return categories.Distinct().ToArray();
   }

   /// <summary>
   /// Retrieves a paginated list of products filtered by category
   /// </summary>
   /// <param name="filter">Query filter for pagination</param>
   /// <param name="category">Product category filter</param>
   /// <returns>The paginated list of products by category</returns>
   public async Task<PageList<Product>> ListByCategoryAsync(QueryFilter filter, string category)
   {
      var productsByCategory = collection.Where(x => x.Category.ToLower() == category.ToLower());

      return await QueryAsync(productsByCategory, filter);
   }
}
