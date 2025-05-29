using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Response model for GetCartResult operation
/// </summary>
public class GetCartResult
{
   /// <summary>
   /// The unique identifier of the cart to retrieve
   /// </summary>
   public int Id { get; set; }

   /// <summary>
   /// The unique identifier of the user who owns the cart
   /// </summary>
   public int UserId { get; set; }

   /// <summary>
   /// The date when the cart was created or last updated
   /// </summary>
   public DateTime Date { get; set; }

   /// <summary>
   /// The list of products in the cart
   /// </summary>
   public List<CartProduct> Products { get; set; } = new();
}
