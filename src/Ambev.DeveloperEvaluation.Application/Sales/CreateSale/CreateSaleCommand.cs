using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Represents a command to create a new sale
/// </summary>
public class CreateSaleCommand : IRequest<CreateSaleResult>
{
   /// <summary>
   /// The unique identifier of the cart containing products to be sold
   /// </summary>
   public int CartId { get; set; }
}