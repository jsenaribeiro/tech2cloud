using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

/// <summary>
/// Represents the command to update a new cart product.
/// </summary>
public class UpdateCartProductCommand
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