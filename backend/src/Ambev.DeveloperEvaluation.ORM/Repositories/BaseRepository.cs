using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Ambev.DeveloperEvaluation.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.Extensions.DependencyInjection;
using Ambev.DeveloperEvaluation.Domain.Values;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Base Repository for basic CRUD operations
/// </summary>
public abstract class BaseRepository<E, I> : IRepository<E, I>
    where E : BaseEntity<I>
    where I : struct, IComparable
{
   protected readonly DefaultContext context;

   protected readonly DbSet<E> dbSet;

   /// <summary>
   /// Initializes a new instance of UserRepository
   /// </summary>
   /// <param name="context">The database context</param>
   public BaseRepository(IServiceProvider provider)
   {
      this.context = provider.GetRequiredService<DefaultContext>();
      this.dbSet = context.Set<E>();
   }

   /// <summary>
   /// Retrieves a entity by their unique identifier
   /// </summary>
   /// <param name="id">The unique identifier of the entity E</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The entity if found, null otherwise</returns>
   public async Task<E?> GetByIdAsync(I id, CancellationToken cancellationToken = default) =>
      await dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);

   /// <summary>
   /// Lists all entities that match the provided filter expression
   /// </summary>
   /// <param name="filter">Linq expression</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns></returns>
   public async Task<List<E>> ListAsync(Expression<Func<E, bool>> filter, CancellationToken cancellationToken = default)
   {
      if (filter is null) throw new ArgumentNullException(nameof(filter));
      return await dbSet.AsNoTracking().Where(filter).ToListAsync(cancellationToken);
   }

   /// <summary>
   /// Retrieves a paginated list of entities based on the provided filter
   /// </summary>
   /// <param name="filter">Query filter</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>Paged list of entities</returns>
   public async Task<PageList<E>> ListAsync(QueryFilter filter, CancellationToken cancellationToken = default) =>
      await QueryAsync(dbSet.AsNoTracking(), filter);

   protected async Task<PageList<E>> QueryAsync(IQueryable<E> query, QueryFilter filter)
   {
      var total = await query.CountAsync();
      var skip = (filter.Page - 1) * filter.Size;
      var hasOrdering = !string.IsNullOrWhiteSpace(filter.Order);
      var validOrderSyntax = @"^(\w+\s+(asc|desc))(,\s*\w+\s+(asc|desc))*$";
      var invalidOrderSyntax = hasOrdering && !Regex.IsMatch(filter.Order, validOrderSyntax);

      if (invalidOrderSyntax)
         throw new ValidationException("The order syntax is invalid. Try something like 'price desc, title asc'");

      var results = hasOrdering == false
         ? await query.Skip(skip).Take(filter.Size).ToListAsync()
         : await query.OrderBy(filter.Order).Skip(skip).Take(filter.Size).ToListAsync();

      return new PageList<E>(results, total, filter.Page, filter.Size);
   }


   /// <summary>
   /// Creates a new entity in the database
   /// /// </summary>
   /// <param name="entity">The entity to create</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The created entity</returns>
   public async Task<E> CreateAsync(E entity, CancellationToken cancellationToken = default)
   {
      if (entity is null) throw new ArgumentNullException(typeof(E).Name);

      entity.CreatedAt = DateTime.UtcNow;

      await dbSet.AddAsync(entity);
      await context.SaveChangesAsync();

      return entity;
   }

   /// <summary>
   /// Updates a new entity in the database
   /// </summary>
   /// <param name="entity">The entity to create</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The updated entity</returns>
   public async Task<E> UpdateAsync(E entity, CancellationToken cancellationToken = default)
   {
      if (entity is null) throw new ArgumentNullException(nameof(entity));

      entity.UpdatedAt = DateTime.UtcNow;
      dbSet.Update(entity);
      await context.SaveChangesAsync(cancellationToken);
      return entity;

      // var dbEntity = await GetByIdAsync(entity.Id, cancellationToken);
      // if (dbEntity is null) throw new InvalidOperationException(typeof(E).Name + " not found");

      // foreach (var prop in typeof(E).GetProperties())
      // {
      //    if (!prop.CanWrite) continue;
      //    if (prop.Name is nameof(BaseEntity<I>.Id)) continue;
      //    if (prop.Name is nameof(BaseEntity<I>.CreatedAt)) continue;
      //    if (prop.Name is nameof(BaseEntity<I>.UpdatedAt)) continue;

      //    var newValue = prop.GetValue(entity);

      //    if (!Equals(prop.GetValue(dbEntity), newValue))
      //       prop.SetValue(dbEntity, newValue);
      // }

      // dbEntity.UpdatedAt = DateTime.UtcNow;

      // await context.SaveChangesAsync(cancellationToken);
      // return dbEntity;
   }

   /// <summary>
   /// Deletes a entity from the database
   /// </summary>
   /// <param name="id">The unique identifier of the entity to delete</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>True if the entity was deleted, false if not found</returns>
   public async Task<E?> DeleteAsync(I id, CancellationToken cancellationToken = default)
   {
      var entity = await GetByIdAsync(id, cancellationToken);
      if (entity == null) return entity;

      dbSet.Remove(entity);
      await context.SaveChangesAsync(cancellationToken);
      return entity;
   }
}