using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new sale in the system.
/// </summary>
public class CreateSaleRequest
{
   /// <summary>
   /// The unique identifier of the product to retrieve
   /// </summary>
   public int CartId { get; }

   /// <summary>
   /// Initializes a new instance of CreateSaleRequest
   /// </summary>
   /// <param name="cartId">The Cart ID with products to retrieve</param>
   public CreateSaleRequest(int cartId)
   {
      CartId = cartId;
   }
}