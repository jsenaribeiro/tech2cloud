using System.Linq.Expressions;
using Ambev.DeveloperEvaluation.Common.Pagination;
using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.Domain.Common;

/// <summary>
///  Shared repository interface
/// </summary>
/// <typeparam name="E">The entity type</typeparam>
/// <typeparam name="I">The identity type</typeparam>
public interface IRepository<E, I> where E : BaseEntity<I> where I : struct, IComparable
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
   /// Retrieves a entity list by query linQ
   /// </summary>
   /// <param name="filter">Query linq</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The entity list</returns>
   Task<List<E>> ListAsync(Expression<Func<E, bool>> filter, CancellationToken cancellationToken = default);

   /// <summary>
   /// Retrieves a entity list by paging and ordering filters
   /// </summary>
   /// <param name="filter">The filter parameters</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The entity list</returns>
   Task<PageList<E>> ListAsync(QueryFilter filter, CancellationToken cancellationToken = default);

   /// <summary>
   /// Retrieves a entity by their unique identifier
   /// </summary>
   /// <param name="id">The unique identifier of the T</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The entity if found, null otherwise</returns>
   Task<E?> GetByIdAsync(I id, CancellationToken cancellationToken = default);

   /// <summary>
   /// Deletes a entity from the repository
   /// </summary>
   /// <param name="id">The unique identifier of the entity to delete</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>True if the entity was deleted, false if not found</returns>
   Task<bool> DeleteAsync(I id, CancellationToken cancellationToken = default);
}