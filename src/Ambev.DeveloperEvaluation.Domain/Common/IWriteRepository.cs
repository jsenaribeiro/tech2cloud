namespace Ambev.DeveloperEvaluation.Domain.Common;

/// <summary>
///  Shared write repository interface
/// </summary>
/// <typeparam name="E">The entity type</typeparam>
/// <typeparam name="I">The identity type</typeparam>
public interface IWriteRepository<E, I> where E : Entity<I> where I : struct, IComparable
{

   /// <summary>
   /// Creates a new entity in the repository
   /// </summary>
   /// <param name="entity">The entity to create</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The created entity</returns>
   Task<E> CreateAsync(E entity, CancellationToken cancellationToken = default);

   /// <summary>
   /// Creates a entity in the repository
   /// </summary>
   /// <param name="entity">The entity to update</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>True if the entity is updated, false if it fails</returns>
   Task<E> UpdateAsync(E entity, CancellationToken cancellationToken = default);

   /// <summary>
   /// Deletes a entity from the repository
   /// </summary>
   /// <param name="id">The unique identifier of the entity to delete</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>True if the entity was deleted, false if not found</returns>
   Task<E?> DeleteAsync(I id, CancellationToken cancellationToken = default);
}
