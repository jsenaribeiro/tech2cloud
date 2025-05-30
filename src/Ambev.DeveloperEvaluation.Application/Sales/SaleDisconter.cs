using Ambev.DeveloperEvaluation.Domain;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Specifications;

namespace Ambev.DeveloperEvaluation.Application.Sales;

public static class SaleDiscounter
{
   public static async Task<Sale> Apply(Cart cart, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
   {
      decimal fullPrice = 0, amount = 0;

      var discountSpecs = new List<ISpecification<CartProduct>>
      {
         new SalesTwentyPercentDiscountSpecification(),
         new SalesTenPercentDiscountSpecification(),
         new SalesNoDiscountSpecification()
      };

      var cartIsAlreadySold = $"Cart ID {cart.Id} is related to another sale.";
      var cartItemsCount = await unitOfWork.Sales.CountAsync(x => x.CartId == cart.Id, cancellationToken);
      if (cartItemsCount > 0) throw new InvalidOperationException(cartIsAlreadySold);

      var cartProducts = cart.Products.Where(x => x.ProductId > 0 && x.Quantity > 0);
      var productIds = cartProducts.Select(x => x.ProductId).Distinct();
      var products = await unitOfWork.Products.ListAsync(x => productIds.Contains(x.Id));

      foreach (var cartProduct in cartProducts)
      {
         decimal unitPrice = products.First(x => x.Id == cartProduct.Id).Price;
         decimal discountedPrice = unitPrice;

         var specification = discountSpecs.First(s => s.IsSatisfiedBy(cartProduct));

         if (specification is SalesTwentyPercentDiscountSpecification)
            discountedPrice = unitPrice - (unitPrice * 0.2m);

         else if (specification is SalesTenPercentDiscountSpecification)
            discountedPrice = unitPrice - (unitPrice * 0.1m);

         fullPrice = fullPrice + (unitPrice * cartProduct.Quantity);

         amount += discountedPrice * cartProduct.Quantity;
      }

      return new Sale
      {
         Cart = cart,
         Amount = fullPrice,
         FullPrice = fullPrice,
         Discounts = fullPrice - amount,
         Date = DateTime.UtcNow
      };
   }
}
