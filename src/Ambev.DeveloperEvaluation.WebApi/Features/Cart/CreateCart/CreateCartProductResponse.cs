using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

/// <summary>
/// Represents a response to create a new product in the cart.
/// </summary>
public class CreateCartProductResponse
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