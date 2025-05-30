using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Represents the response returned after successfully creating a new cart.
/// </summary>
public class CreateCartProductResult
{
   /// <summary>
   /// The product identifier.
   /// </summary>
   public int ProductId { get; set; }

   /// <summary>
   /// The quantity of the product.
   /// </summary>
   public int Quantity { get; set; }
}
