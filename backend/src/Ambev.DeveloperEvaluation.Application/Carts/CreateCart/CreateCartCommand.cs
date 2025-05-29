using Ambev.DeveloperEvaluation.Domain.Values;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Command for creating a new cart.
/// </summary>
public class CreateCartCommand : IRequest<CreateCartResult>
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

