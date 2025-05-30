using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Ambev.DeveloperEvaluation.Domain;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

/// <summary>
/// Handler for processing DeleteCartCommand requests
/// </summary>
public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, DeleteCartResult>
{
   private readonly IUnitOfWork _unitOfWork;

   /// <summary>
   /// Initializes a new instance of DeleteCartHandler
   /// </summary>
   /// <param name="provider">Service locator for DI</param>
   public DeleteCartHandler(IServiceProvider provider) =>
      _unitOfWork = provider.GetRequiredService<IUnitOfWork>();

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

      var deletedCart = await _unitOfWork.Carts.DeleteAsync(request.Id, cancellationToken);
      if (deletedCart is null) throw new KeyNotFoundException($"Cart with ID {request.Id} not found");

      return new DeleteCartResult { Success = true };
   }
}
