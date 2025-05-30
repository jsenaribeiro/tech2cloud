using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Ambev.DeveloperEvaluation.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.Extensions.DependencyInjection;
using Ambev.DeveloperEvaluation.Domain.Values;
using System.Linq.Expressions;
using MongoDB.Driver;
using SharpCompress.Common;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Base Repository for basic CRUD operations
/// </summary>
public abstract class Repository<E, I> : IRepository<E, I>
    where I : struct, IComparable
    where E : Entity<I>
{
   const string INVALID_ORDER_SYNTAX = "The order syntax is invalid. Try something like 'price desc, title asc'";
   const string INVALID_ID = "Must have a valid Id assigned before being saved in ";


   private readonly PostgreContext pgContext;
   private readonly MongoContext mongoContext;
   private readonly DbSet<E> dbSet;

   protected IMongoCollection<E> collection => mongoContext.GetCollection<E, I>();

   protected IMongoCollection<T> GetCollection<T, U>()
      where T : Entity<U>
      where U : struct, IComparable
      => mongoContext.GetCollection<T, U>();

   /// <summary>
   /// Initializes a new instance of UserRepository
   /// </summary>
   /// <param name="context">The database context</param>
   public Repository(IServiceProvider provider)
   {
      this.pgContext = provider.GetRequiredService<PostgreContext>();
      this.mongoContext = provider.GetRequiredService<MongoContext>();
      this.dbSet = pgContext.Set<E>();
   }

   /// <summary>
   /// Retrieves a entity by their unique identifier
   /// </summary>
   /// <param name="id">The unique identifier of the entity E</param>
   /// <param name="cancel">Cancellation token</param>
   /// <returns>The entity if found, null otherwise</returns>
   public async Task<E?> GetAsync(I id, CancellationToken cancel = default) =>
      await mongoContext
         .GetCollection<E, I>()
         .Find(e => e.Id.Equals(id))
         .FirstOrDefaultAsync(cancel);

   /// <summary>
   /// Lists all entities that match the provided filter expression
   /// </summary>
   /// <param name="filter">Linq expression</param>
   /// <param name="cancel">Cancellation token</param>
   /// <returns>List of entities</returns>
   public async Task<List<E>> ListAsync(Expression<Func<E, bool>> filter, CancellationToken cancel = default) =>
      filter is not null ? await mongoContext.GetCollection<E, I>().Where(filter).ToListAsync(cancel)
                         : throw new ArgumentNullException(nameof(filter));

   /// <summary>
   /// Retrieves a paginated list of entities based on the provided filter
   /// </summary>
   /// <param name="filter">Query filter</param>
   /// <param name="cancel">Cancellation token</param>
   /// <returns>Paged list of entities</returns>
   public async Task<PageList<E>> ListAsync(QueryFilter filter, CancellationToken cancel = default) =>
      await QueryAsync(mongoContext.GetCollection<E, I>().Find(Builders<E>.Filter.Empty), filter);

   /// <summary>
   /// Executes a query against the database and returns a paginated list of entities
   /// </summary>
   /// <param name="query">The query to execute</param>
   /// <param name="filter">The pagination and filtering options</param>
   /// <returns>A paginated list of entities</returns>
   /// <exception cref="ValidationException"></exception>
   protected async Task<PageList<E>> QueryAsync(IFindFluent<E, E> query, QueryFilter filter)
   {
      var total = await query.CountDocumentsAsync();
      var skip = (filter.Page - 1) * filter.Size;
      var hasOrdering = !string.IsNullOrWhiteSpace(filter.Order);
      var validOrderSyntax = @"^(\w+\s+(asc|desc))(,\s*\w+\s+(asc|desc))*$";
      var invalidOrderSyntax = hasOrdering && !Regex.IsMatch(filter.Order, validOrderSyntax);

      if (invalidOrderSyntax) throw new ValidationException(INVALID_ORDER_SYNTAX);
      if (hasOrdering) query = query.OrderBy(filter.Order);

      var results = await query.Skip(skip).Limit(filter.Size).ToListAsync();

      return new PageList<E>(results, (int)total, filter.Page, filter.Size);
   }

   public async Task<long> CountAsync(Expression<Func<E, bool>> query, CancellationToken cancellationToken = default)
   {
      return query is not null
         ? await mongoContext.GetCollection<E, I>().CountAsync(query, cancellationToken)
         : throw new ArgumentNullException(nameof(query));
   }

   /// <summary>
   /// Creates a new entity in the database
   /// </summary>
   /// <param name="entity">The entity to create</param>
   /// <param name="cancel">Cancellation token</param>
   /// <returns>The created entity</returns>
   public async Task<E> CreateAsync(E entity, CancellationToken cancel = default)
   {
      if (entity is null) throw new ArgumentNullException(typeof(E).Name);

      using var transaction = await pgContext.Database.BeginTransactionAsync();

      try
      {
         entity.CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);

         pgContext.Entry(entity).State = EntityState.Added;

         await dbSet.AddAsync(entity);
         await pgContext.SaveChangesAsync();

         // synchronize creation with MongoDB (reading database)

         if (entity.Id.Equals(default(I))) throw new InvalidOperationException($"{INVALID_ID} {typeof(E).Name} entity.");
         await mongoContext.GetCollection<E, I>().InsertOneAsync(entity, cancellationToken: cancel);

         await transaction.CommitAsync();
      }
      catch (System.Exception exception)
      {
         Console.WriteLine($"Error creating entity: {exception.Message}");
         await transaction.RollbackAsync();
         throw;
      }

      return entity;
   }

   /// <summary>
   /// Updates a new entity in the database
   /// </summary>
   /// <param name="entity">The entity to create</param>
   /// <param name="cancel">Cancellation token</param>
   /// <returns>The updated entity</returns>
   public async Task<E> UpdateAsync(E entity, CancellationToken cancel = default)
   {
      if (entity is null) throw new ArgumentNullException(nameof(entity));

      using var transaction = await pgContext.Database.BeginTransactionAsync();

      try
      {
         entity.UpdatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);

         var result = dbSet.Update(entity);
         if (result == null || result.Entity == null)
            throw new InvalidOperationException($"Entity with Id {entity.Id} not found for update in PostgreSQL.");

         await pgContext.SaveChangesAsync(cancel);

         // synchronize update with MongoDB (reading database)

         if (entity.Id.Equals(default(I))) throw new InvalidOperationException($"{INVALID_ID} {typeof(E).Name} entity.");

         var filter = Builders<E>.Filter.Eq(e => e.Id, entity.Id);
         if (filter == null) throw new ArgumentNullException(nameof(filter));

         var update = await mongoContext.GetCollection<E, I>()
            .ReplaceOneAsync(filter, entity, new ReplaceOptions { IsUpsert = true }, cancel);

         if (update.IsAcknowledged && update.ModifiedCount == 0)
            throw new InvalidOperationException($"Entity with Id {entity.Id} not found for update in MongoDB.");

         await transaction.CommitAsync();
      }
      catch (System.Exception)
      {
         await transaction.RollbackAsync();
         throw;
      }

      return entity;
   }

   /// <summary>
   /// Deletes a entity from the database
   /// </summary>
   /// <param name="id">The unique identifier of the entity to delete</param>
   /// <param name="cancel">Cancellation token</param>
   /// <returns>True if the entity was deleted, false if not found</returns>
   public async Task<E?> DeleteAsync(I id, CancellationToken cancel = default)
   {
      var entity = await GetAsync(id, cancel);
      if (entity == null) return entity;

      var result = dbSet.Remove(entity);

      if (result == null || result.Entity == null)
         throw new InvalidOperationException($"Entity with Id {id} not found for deletion in PostgreSQL.");

      // synchronize deletion with MongoDB (reading database)

      if (id.Equals(default(I))) throw new InvalidOperationException($"{INVALID_ID} {typeof(E).Name} entity.");

      var filter = Builders<E>.Filter.Eq(e => e.Id, id);
      var delete = await mongoContext.GetCollection<E, I>()
         .DeleteOneAsync(filter, cancel);

      if (!delete.IsAcknowledged || delete.DeletedCount == 0)
         throw new InvalidOperationException($"Entity with Id {id} not found for deletion in MongoDB.");

      await pgContext.SaveChangesAsync(cancel);
      return entity;
   }
}