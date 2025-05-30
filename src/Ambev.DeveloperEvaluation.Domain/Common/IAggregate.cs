namespace Ambev.DeveloperEvaluation.Domain.Common;

public interface IAggregate<T> where T : Entity<int>
{
   /// <summary>
   /// Adds an entity to the aggregate.
   /// </summary>
   /// <param name="entity">The entity to add.</param>
   void Append(T entity);

   /// <summary>
   /// Removes an entity from the aggregate.
   /// </summary>
   /// <param name="entity">The entity to remove.</param>
   void Remove(T entity);
}