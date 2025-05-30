using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Represents the command to create a new cart product.
/// </summary>
public class CreateCartProductCommand
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