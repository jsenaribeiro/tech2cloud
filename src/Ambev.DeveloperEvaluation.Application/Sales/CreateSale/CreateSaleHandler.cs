using MediatR;
using AutoMapper;
using System.Text.Json;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Ambev.DeveloperEvaluation.Domain;
using Ambev.DeveloperEvaluation.Domain.Specifications;
using Ambev.DeveloperEvaluation.Domain.Common;
using Microsoft.Extensions.Caching.Distributed;
using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
   private readonly IMapper _mapper;
   private readonly IUnitOfWork _unitOfWork;
   private readonly IDistributedCache _distributedCache;

   public CreateSaleHandler(IServiceProvider provider)
   {
      _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
      _mapper = provider.GetRequiredService<IMapper>();
      _distributedCache = provider.GetRequiredService<IDistributedCache>();
   }

   public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
   {
      var cart = await _unitOfWork.Carts.GetAsync(request.CartId, cancellationToken);
      if (cart == null) throw new KeyNotFoundException($"Cart {request.CartId} not found");

      decimal fullPrice = 0, amount = 0;

      var discountSpecs = new List<ISpecification<CartProduct>>
      {
         new SalesTwentyPercentDiscountSpecification(),
         new SalesTenPercentDiscountSpecification(),
         new SalesNoDiscountSpecification()
      };

      var cartIsAlreadySold = $"Cart ID {request.CartId} is related to another sale.";
      var cartItemsCount = await _unitOfWork.Sales.CountAsync(x => x.CartId == request.CartId, cancellationToken);
      if (cartItemsCount > 0) throw new InvalidOperationException(cartIsAlreadySold);

      var cartProducts = cart.Products.Where(x => x.ProductId > 0 && x.Quantity > 0);
      var productIds = cartProducts.Select(x => x.ProductId).Distinct();
      var products = await _unitOfWork.Products.ListAsync(x => productIds.Contains(x.Id));

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

      var sale = new Sale
      {
         Cart = cart,
         Amount = fullPrice,
         FullPrice = fullPrice,
         Discounts = fullPrice - amount,
         Date = DateTime.UtcNow
      };

      await _unitOfWork.Sales.CreateAsync(sale, cancellationToken);

      var saleCreatedEvent = new SaleCreatedEvent(sale.Id, sale.Amount, sale.Date);
      var eventJson = JsonSerializer.Serialize(saleCreatedEvent);

      await _distributedCache.SetStringAsync($"event:SaleCreated:{sale.Id}", eventJson, cancellationToken);

      return new CreateSaleResult { Id = sale.Id, Amount = sale.Amount, Discounts = sale.Discounts };
   }
}
