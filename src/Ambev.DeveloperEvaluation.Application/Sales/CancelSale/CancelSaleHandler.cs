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

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, CancelSaleResult>
{
   private readonly IMapper _mapper;
   private readonly IUnitOfWork _unitOfWork;
   private readonly IDistributedCache _eventBroker;

   public CancelSaleHandler(IServiceProvider provider)
   {
      _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
      _mapper = provider.GetRequiredService<IMapper>();
      _eventBroker = provider.GetRequiredService<IDistributedCache>();
   }

   public async Task<CancelSaleResult> Handle(CancelSaleCommand command, CancellationToken cancellationToken)
   {
      var cart = await _unitOfWork.Carts.GetAsync(command.CartId, cancellationToken);
      if (cart == null) throw new KeyNotFoundException($"Cart {command.CartId} not found");

      var sale = await SaleDiscounter.Apply(cart, _unitOfWork, cancellationToken);

      sale.IsCancelled = true;

      await _unitOfWork.Sales.UpdateAsync(sale, cancellationToken);

      var saleCancelledEvent = new SaleCancelledEvent(sale.Id);
      var eventJson = JsonSerializer.Serialize(saleCancelledEvent);

      await _eventBroker.SetStringAsync($"event:SaleCancelled:{sale.Id}", eventJson, cancellationToken);

      return new CancelSaleResult { Id = sale.Id, Amount = sale.Amount, Discounts = sale.Discounts };
   }
}
