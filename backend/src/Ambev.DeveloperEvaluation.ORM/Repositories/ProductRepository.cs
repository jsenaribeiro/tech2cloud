using Ambev.DeveloperEvaluation.Common.Pagination;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Values;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IProductRepository using Entity Framework Core
/// </summary>
public class ProductRepository : BaseRepository<Product, int>, IProductRepository
{
   /// <summary>
   /// Initializes a new instance of ProductRepository
   /// </summary>
   /// <param name="context">The database context</param>
   public ProductRepository(IServiceProvider provider) : base(provider) { }

   public Task<string[]> ListAllCategoriesAsync() =>
      dbSet.Select(x => x.Category).Distinct().ToArrayAsync();

   /// <summary>
   /// Retrieves a paginated list of products filtered by category
   /// </summary>
   /// <param name="filter">Query filter for pagination</param>
   /// <param name="category">Product category filter</param>
   /// <returns>The paginated list of products by category</returns>
   public Task<PageList<Product>> ListByCategoryAsync(QueryFilter filter, string category)
   {
      var productsByCategory = dbSet.Where(x => x.Category.ToLower() == category.ToLower());
      return QueryAsync(productsByCategory, filter);
   }
}
