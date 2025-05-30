using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Represents a response to create a new sale
/// </summary>
public class CreateSaleResponse
{
   /// <summary>
   /// The unique identifier of the created sale
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
