using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

/// <summary>
/// Handler for processing DeleteCartCommand requests
/// </summary>
public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, DeleteCartResult>
{
   private readonly ICartRepository _cartRepository;

   /// <summary>
   /// Initializes a new instance of DeleteCartHandler
   /// </summary>
   /// <param name="cartRepository">The cart repository</param>
   /// <param name="validator">The validator for DeleteCartCommand</param>
   public DeleteCartHandler(IServiceProvider provider) =>
      _cartRepository = provider.GetRequiredService<ICartRepository>();

   /// <summary>
   /// Handles the DeleteCartCommand request
   /// </summary>
   /// <param name="request">The DeleteCart command</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The result of the delete operation</returns>
   public async Task<DeleteCartResult> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
   {
      var validationResult = await new DeleteCartValidator()
         .ValidateAsync(request, cancellationToken);

      if (!validationResult.IsValid)
         throw new ValidationException(validationResult.Errors);

      var success = await _cartRepository.DeleteAsync(request.Id, cancellationToken);
      if (!success) throw new KeyNotFoundException($"Cart with ID {request.Id} not found");

      return new DeleteCartResult { Success = true };
   }
}
