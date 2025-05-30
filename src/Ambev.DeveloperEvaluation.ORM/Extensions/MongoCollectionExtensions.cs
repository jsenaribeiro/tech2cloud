using System.Linq.Expressions;
using MongoDB.Driver;

public static class MongoCollectionExtensions
{
   public static async Task<T?> FirstOrDefaultAsync<T>(this IMongoCollection<T> collection,
      Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
         await collection.Find(filter).FirstOrDefaultAsync(cancellationToken);

   public static async Task<List<T>> ToListAsync<T>(this IMongoCollection<T> collection,
       Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
         await collection.Find(filter).ToListAsync(cancellationToken);

   public static async Task<bool> ExistsAsync<T>(this IMongoCollection<T> collection,
       Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
         await collection.Find(filter).AnyAsync(cancellationToken);
         
   public static async Task<long> CountAsync<T>(this IMongoCollection<T> collection,
      Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
         await collection.CountDocumentsAsync(filter, cancellationToken: cancellationToken);

   public static IFindFluent<T, T> Where<T>(this IMongoCollection<T> collection,
      Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
         collection.Find(filter);

   public static IFindFluent<T, TResult> Select<T, TResult>(this IMongoCollection<T> collection,
      Expression<Func<T, TResult>> selector, CancellationToken cancellationToken = default) =>
         collection.Find(Builders<T>.Filter.Empty).Project(selector);
         
   public static IFindFluent<T, T> OrderBy<T>(this IFindFluent<T, T> query, string order)
   {
      order ??= string.Empty;
      order = order.Trim().ToLower();

      SortDefinition<T>? sort = null;

      var fields = order.Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(f => f.Trim());

      foreach (var field in fields)
      {
         var parts = field.Split(' ', StringSplitOptions.RemoveEmptyEntries);
         if (parts.Length != 2) continue;

         var fieldName = parts[0];
         var direction = parts[1].ToLower();

         var sortPart = direction == "desc"
             ? Builders<T>.Sort.Descending(fieldName)
             : Builders<T>.Sort.Ascending(fieldName);

         sort = sort == null ? sortPart : Builders<T>.Sort.Combine(sort, sortPart);
      }

      sort = sort ?? Builders<T>.Sort.Ascending("_id"); // fallback

      return query.Sort(sort);
   }
}
