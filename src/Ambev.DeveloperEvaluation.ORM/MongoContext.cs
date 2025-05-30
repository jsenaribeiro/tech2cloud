using MongoDB.Driver;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Common;
using MongoDB.Bson;

namespace Ambev.DeveloperEvaluation.ORM
{
   public class MongoContext
   {
      private readonly IMongoDatabase db;

      public MongoContext(string connectionString, string database)
      {
         var client = new MongoClient(connectionString);
         db = client.GetDatabase(database);

         var pong = PingAsync(db).GetAwaiter().GetResult();

         Console.WriteLine(pong ? "ping-pong" : "MongoDB connection failed");
      }

      public IMongoCollection<E> GetCollection<E, I>()
         where E : Entity<I> where I : struct, IComparable =>
            db.GetCollection<E>(typeof(E).Name + "s");

      public IMongoCollection<User> Users => GetCollection<User, int>();

      public IMongoCollection<Cart> Carts => GetCollection<Cart, int>();

      public IMongoCollection<Product> Products => GetCollection<Product, int>();

      public static async Task<bool> PingAsync(IMongoDatabase db)
      {
         try
         {
            var command = new BsonDocument("ping", 1);
            await db.RunCommandAsync<BsonDocument>(command);
            return true;
         }
         catch
         {
            return false;
         }
      }
   }
}
