using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleModifiedEvent
{
   public int SaleId { get; set; }

   public DateTime Date { get; set; }

   public decimal Amount { get; set; }

   public SaleModifiedEvent(int saleId, decimal amount, DateTime date)
   {
      SaleId = saleId;
      Amount = amount;
      Date = date;
   }
}
