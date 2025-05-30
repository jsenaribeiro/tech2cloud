using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for product entity operations
/// </summary>
public interface IProductRepository : IRepository<Product, int>
{
   Task<string[]> ListAllCategoriesAsync();

   Task<PageList<Product>> ListByCategoryAsync(QueryFilter query, string category);
}
