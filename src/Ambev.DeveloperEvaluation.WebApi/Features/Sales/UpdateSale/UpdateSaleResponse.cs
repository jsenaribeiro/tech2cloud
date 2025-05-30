using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Represents a response to update a new sale
/// </summary>
public class UpdateSaleResponse
{
   /// <summary>
   /// The unique identifier of the updated sale
   /// </summary>
   public int Id { get; set; }

   /// <summary>
   /// The total amount of the sale
   /// </summary>
   public decimal Amount { get; set; }

   /// <summary>
   /// The total discounts applied to the sale
   /// </summary>
   public decimal Discounts { get; set; }
}
