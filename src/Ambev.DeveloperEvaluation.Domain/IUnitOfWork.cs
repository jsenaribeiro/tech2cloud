using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Domain;

/// <summary>
/// Unit of Work interface for managing repositories and saving changes
/// </summary>
public interface IUnitOfWork
{

   /// <summary>
   /// Gets the repository for managing users
   /// </summary>
   IUserRepository Users { get; }

   /// <summary>
   /// Gets the repository for managing sales
   /// </summary>
   ISaleRepository Sales { get; }

   /// <summary>
   /// Gets the repository for managing carts
   /// </summary>
   ICartRepository Carts { get; }

   /// <summary>
   /// Gets the repository for managing products
   /// </summary>
   IProductRepository Products { get; }

   // Task<int> CommitAsync(CancellationToken cancellationToken = default);

   // Task<int> RollbackAsync(CancellationToken cancellationToken = default);
}
