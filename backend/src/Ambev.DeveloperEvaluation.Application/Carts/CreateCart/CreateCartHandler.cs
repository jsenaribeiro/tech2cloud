using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Handler for processing CreateCartCommand requests
/// </summary>
public class CreateCartHandler : IRequestHandler<CreateCartCommand, CreateCartResult>
{
   private readonly ICartRepository _cartRepository;
   private readonly IMapper _mapper;

   /// <summary>
   /// Initializes a new instance of CreateCartHandler
   /// </summary>
   /// <param name="provider">The service locator for dependencies</param>
   public CreateCartHandler(IServiceProvider provider)
   {
      _cartRepository = provider.GetRequiredService<ICartRepository>();
      _mapper = provider.GetRequiredService<IMapper>();
   }

   /// <summary>
   /// Handles the CreateCartCommand request
   /// </summary>
   /// <param name="command">The CreateCart command</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The created cart details</returns>
   public async Task<CreateCartResult> Handle(CreateCartCommand command, CancellationToken cancellationToken)
   {
      var validationResult = await new CreateCartCommandValidator()
          .ValidateAsync(command, cancellationToken);

      if (!validationResult.IsValid)
         throw new ValidationException(validationResult.Errors);

      var cart = _mapper.Map<Cart>(command);
      var createdCart = await _cartRepository.CreateAsync(cart, cancellationToken);
      var result = _mapper.Map<CreateCartResult>(createdCart);

      return result;
   }
}
