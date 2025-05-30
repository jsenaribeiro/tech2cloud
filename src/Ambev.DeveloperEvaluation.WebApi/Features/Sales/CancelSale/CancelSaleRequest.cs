using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale;

/// <summary>
/// Represents a request to cancel a new sale in the system.
/// </summary>
public class CancelSaleRequest
{
   /// <summary>
   /// The unique identifier of the cart containing products to be sold
   /// </summary>
   public int CartId { get; set; }
}