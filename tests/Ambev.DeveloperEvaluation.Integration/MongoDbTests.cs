namespace Ambev.DeveloperEvaluation.Integration;

using MongoDB.Driver;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Common;
using Xunit;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.Domain.Values;

public class MongoDbTests
{
   private const string ConnectionString = "mongodb://developer:ev%40luAt10n@localhost:27017";

   private const string DatabaseName = "developer_evaluation";

   public static MongoContext CreateMongoContext()
   {
      return new MongoContext(ConnectionString, DatabaseName);
   }

   public static IMongoCollection<T> GetCollection<T, U>()
      where T : Entity<U>
      where U : struct, IComparable
   {
      var context = CreateMongoContext();
      return context.GetCollection<T, U>();
   }

   [Fact]
   public void TestAddUser()
   {
      var userId = 1;

      var collection = GetCollection<User, int>();

      var exists = collection.Find(u => u.Id == userId).FirstOrDefault();

      if (exists != null) collection.DeleteOne(u => u.Id == userId);

      var user = new User
      {
         Id = userId,
         Name = new Name("User", "Test"),
         Email = "testuser@example.com"
      };

      collection.InsertOne(user);

      var foundUser = collection.Find(u => u.Id == user.Id).FirstOrDefault();

      Assert.NotNull(foundUser);
      Assert.Equal(user.Name.FullName, foundUser.Name.FullName);
      Assert.Equal(user.Email, foundUser.Email);
      Assert.Equal(user.Id, foundUser.Id);
   }
}
