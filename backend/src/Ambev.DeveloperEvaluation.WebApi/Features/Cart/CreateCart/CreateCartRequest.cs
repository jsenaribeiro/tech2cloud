using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

/// <summary>
/// Represents a request to create a new cart in the system.
/// </summary>
public class CreateCartRequest
{
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