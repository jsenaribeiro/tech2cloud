using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

/// <summary>
/// Represents a command to cancel a new sale
/// </summary>
public class CancelSaleCommand : IRequest<CancelSaleResult>
{
   /// <summary>
   /// The unique identifier of the cart containing products to be sold
   /// </summary>
   public int CartId { get; set; }
}