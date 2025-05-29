using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

/// <summary>
/// Handler for processing UpdateCartCommand requests
/// </summary>
public class UpdateCartHandler : IRequestHandler<UpdateCartCommand, UpdateCartResult>
{
   private readonly ICartRepository _cartRepository;
   private readonly IMapper _mapper;

   /// <summary>
   /// Initializes a new instance of UpdateCartHandler
   /// </summary>
   /// <param name="provider">The service locator for dependencies</param>
   public UpdateCartHandler(IServiceProvider provider)
   {
      _cartRepository = provider.GetRequiredService<ICartRepository>();
      _mapper = provider.GetRequiredService<IMapper>();
   }

   /// <summary>
   /// Handles the UpdateCartCommand request
   /// </summary>
   /// <param name="command">The UpdateCart command</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The updated cart details</returns>
   public async Task<UpdateCartResult> Handle(UpdateCartCommand command, CancellationToken cancellationToken)
   {
      var validationResult = await new UpdateCartCommandValidator()
          .ValidateAsync(command, cancellationToken);

      if (!validationResult.IsValid)
         throw new ValidationException(validationResult.Errors);

      var cart = _mapper.Map<Cart>(command);
      var updatedCart = await _cartRepository.UpdateAsync(cart, cancellationToken);
      var result = _mapper.Map<UpdateCartResult>(updatedCart);

      return result;
   }
}
