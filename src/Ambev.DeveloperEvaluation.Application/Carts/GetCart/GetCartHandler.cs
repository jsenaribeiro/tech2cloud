using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Ambev.DeveloperEvaluation.Domain;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Handler for processing GetCartQuery requests
/// </summary>
public class GetCartHandler : IRequestHandler<GetCartQuery, GetCartResult>
{
   private readonly IUnitOfWork _unitOfWork;
   private readonly IMapper _mapper;

   /// <summary>
   /// Initializes a new instance of GetCartHandler
   /// </summary>
   /// <param name="provider">Service locator for DI</param>
   public GetCartHandler(IServiceProvider provider)
   {
      _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
      _mapper = provider.GetRequiredService<IMapper>();
   }

   /// <summary>
   /// Handles the GetCartQuery request
   /// </summary>
   /// <param name="request">The GetCart query</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The cart details if found</returns>
   public async Task<GetCartResult> Handle(GetCartQuery request, CancellationToken cancellationToken)
   {
      var validator = new GetCartValidator();
      var validationResult = await validator.ValidateAsync(request, cancellationToken);

      if (!validationResult.IsValid)
         throw new ValidationException(validationResult.Errors);

      var cart = await _unitOfWork.Carts.GetAsync(request.Id, cancellationToken);
      if (cart == null) throw new KeyNotFoundException($"Cart with ID {request.Id} not found");

      return _mapper.Map<GetCartResult>(cart);
   }
}
