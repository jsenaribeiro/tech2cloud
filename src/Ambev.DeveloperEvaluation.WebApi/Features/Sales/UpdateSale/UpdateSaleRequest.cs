using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Represents a request to update a new sale in the system.
/// </summary>
public class UpdateSaleRequest
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