using MediatR;
using AutoMapper;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Ambev.DeveloperEvaluation.Common.Pagination;
using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCarts;

/// <summary>
/// Handler for processing GetCartsQuery requests
/// </summary>
public class GetCartsHandler : IRequestHandler<GetCartsQuery, PageList<GetCartsResult>>
{
   private readonly ICartRepository _cartRepository;
   
   private readonly IMapper _mapper;

   /// <summary>
   /// Initializes a new instance of GetCartsHandler
   /// </summary>
   /// <param name="provider">The service locator for dependencies</param>
   public GetCartsHandler(IServiceProvider provider)
   {
      _cartRepository = provider.GetRequiredService<ICartRepository>();
      _mapper = provider.GetRequiredService<IMapper>();
   }

   /// <summary>
   /// Handles the GetCartsQuery request
   /// </summary>
   /// <param name="request">The GetCarts query</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The cart list if found</returns>
   public async Task<PageList<GetCartsResult>> Handle(GetCartsQuery request, CancellationToken cancellationToken)
   {
      var carts = await _cartRepository.ListAsync(request);
      if (carts is null) throw new KeyNotFoundException($"Carts not found");

      return _mapper.Map<PageList<GetCartsResult>>(carts);
   }
}
