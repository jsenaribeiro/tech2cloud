using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// /// Represents a shopping cart for a user.
/// </summary> <summary>
public class Cart : BaseEntity<int>, IAggregate<CartProduct>
{
   public List<CartProduct> products { get; } = new();

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
   /// Appends a product to the cart.
   /// </summary>
   public void Append(CartProduct entity)
   {
      products.Add(entity);
   }

   /// <summary>
   /// Removes a product from the cart.
   /// </summary>
   public void Remove(CartProduct entity)
   {
      products.Remove(entity);
   }
}