using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ICartRepository using Entity Framework Core
/// </summary>
public class CartRepository : BaseRepository<Cart, int>, ICartRepository
{
   /// <summary>
   /// Initializes a new instance of CartRepository
   /// </summary>
   /// <param name="context">The database context</param>
   public CartRepository(IServiceProvider provider) : base(provider) { }
}
