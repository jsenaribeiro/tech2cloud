using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// /// Represents a shopping cart for a user.
/// </summary> <summary>
public class Cart : BaseEntity<int>
{
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
   public List<CartProduct> Products { get; set; } = new();
}