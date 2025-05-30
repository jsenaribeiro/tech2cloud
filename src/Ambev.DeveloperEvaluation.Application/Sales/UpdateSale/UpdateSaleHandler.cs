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

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
   private readonly IMapper _mapper;
   private readonly IUnitOfWork _unitOfWork;
   private readonly IDistributedCache _eventBroker;

   public UpdateSaleHandler(IServiceProvider provider)
   {
      _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
      _mapper = provider.GetRequiredService<IMapper>();
      _eventBroker = provider.GetRequiredService<IDistributedCache>();
   }

   public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
   {
      var oldCard = await _unitOfWork.Carts.GetAsync(command.OldCartId, cancellationToken);
      if (oldCard == null) throw new KeyNotFoundException($"Previous cart {command.OldCartId} not found");

      var newCard = await _unitOfWork.Carts.GetAsync(command.NewCartId, cancellationToken);
      if (newCard == null) throw new KeyNotFoundException($"New cart {command.NewCartId} not found");

      var sale = await SaleDiscounter.Apply(newCard, _unitOfWork, cancellationToken);

      await _unitOfWork.Sales.UpdateAsync(sale, cancellationToken);

      var saleUpdatedEvent = new SaleModifiedEvent(sale.Id, sale.Amount, sale.Date);
      var eventJson = JsonSerializer.Serialize(saleUpdatedEvent);

      await _eventBroker.SetStringAsync($"event:SaleUpdated:{sale.Id}", eventJson, cancellationToken);

      return new UpdateSaleResult { Id = sale.Id, Amount = sale.Amount, Discounts = sale.Discounts };
   }
}
