using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

/// <summary>
/// Represents a result to cancel a new sale
/// </summary>
public class CancelSaleResult
{
   /// <summary>
   /// The unique identifier of the canceld sale
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
