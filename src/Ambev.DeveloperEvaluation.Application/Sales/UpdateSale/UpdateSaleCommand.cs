using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Represents a command to update a new sale
/// </summary>
public class UpdateSaleCommand : IRequest<UpdateSaleResult>
{
   /// <summary>
   /// The previous unique identifier of the cart containing products to be sold
   /// </summary>
   public int OldCartId { get; set; }

   /// <summary>
   /// The new unique identifier of the cart containing products to be sold
   /// </summary>
   public int NewCartId { get; set; }
}