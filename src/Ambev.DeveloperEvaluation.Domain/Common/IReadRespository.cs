using System.Linq.Expressions;
using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.Domain.Common;

/// <summary>
///  Shared read repository interface
/// </summary>
/// <typeparam name="E">The entity type</typeparam>
/// <typeparam name="I">The identity type</typeparam>
public interface IReadRespository<E, I> where E : Entity<I> where I : struct, IComparable
{
   /// <summary>
   /// Retrieves a entity by their unique identifier
   /// </summary>
   /// <param name="id">The unique identifier of the T</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The entity if found, null otherwise</returns>
   Task<E?> GetAsync(I id, CancellationToken cancellationToken = default);

   /// <summary>
   /// Retrieves a entity list by query linQ
   /// </summary>
   /// <param name="filter">Query linq</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The entity list</returns>
   Task<List<E>> ListAsync(Expression<Func<E, bool>> query, CancellationToken cancellationToken = default);

   /// <summary>
   /// Retrieves a entity list by paging and ordering filters
   /// </summary>
   /// <param name="filter">The filter parameters</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The entity list</returns>
   Task<PageList<E>> ListAsync(QueryFilter filter, CancellationToken cancellationToken = default);

   /// <summary>
   /// It counts the number of entities that match the provided filter expression
   /// </summary>
   /// <param name="filter">Query linq for counting entity</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The entity list</returns>
   Task<long> CountAsync(Expression<Func<E, bool>> query, CancellationToken cancellationToken = default);
}