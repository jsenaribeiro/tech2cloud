using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// /// Represents a shopping cart for a user.
/// </summary> <summary>
public class Cart : Entity<int>, IAggregate<CartProduct>
{
   private readonly List<CartProduct> products = new();

   /// <summary>
   /// The unique identifier of the User
   /// </summary>
   public int UserId { get; set; }

   /// <summary>
   /// Cart date time inclusion.
   /// </summary>
   public DateTime Date { get; set; }

   /// <summary>
   /// List of products in the cart.
   /// </summary>
   public IReadOnlyCollection<CartProduct> Products => products.AsReadOnly();

   /// <summary>
   /// Adds a product to the cart.
   /// </summary>
   public void Append(CartProduct entity)
   {
      var uniqueItems = products.Select(x => x.ProductId).Distinct();

      foreach (var productId in uniqueItems)
      {
         var maxLimitSameProductError = $"Only allowed 20 units of same product id: {productId}";

         if (products.Count(x => x.ProductId == productId) >= 20)
            throw new InvalidOperationException(maxLimitSameProductError);
      }

      products.Add(entity);
   }

   /// <summary>
   /// Removes a product from the cart.
   /// </summary>
   public void Remove(CartProduct entity) => products.Remove(entity);
}