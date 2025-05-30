namespace Ambev.DeveloperEvaluation.Domain.Entities;

using System;
using Ambev.DeveloperEvaluation.Domain.Common;

public class Sale : Entity<int>
{
   /// <summary>
   /// Represents the cart associated with the sale.
   /// </summary>
   public Cart? Cart { get; set; }

   /// <summary>
   /// Represents the identifier of the user who made the sale.
   /// </summary>
   public int CartId { get; set; }

   /// <summary>
   /// Represents the identifier of the cart associated with the sale.
   /// </summary>
   public DateTime Date { get; set; }

   /// <summary>
   /// Represents the total cost of the sale.
   /// </summary>
   public decimal Amount { get; set; }

   /// <summary>
   /// Represents the total discounts applied to the sale.
   /// </summary>
   public decimal Discounts { get; set; }

   /// <summary>
   /// Represents the final cost of the sale after discounts.
   /// </summary>
   public decimal FullPrice { get; set; }

   /// <summary>
   /// Represents whether the sale has been cancelled.
   /// </summary>
   public bool IsCancelled { get; set; }
}

