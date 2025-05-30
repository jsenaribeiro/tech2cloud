using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Ambev.DeveloperEvaluation.Domain;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;

/// <summary>
/// Handler for processing DeleteProductCommand requests
/// </summary>
public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductResult>
{
   private readonly IUnitOfWork _unitOfWork;

   /// <summary>
   /// Initializes a new instance of DeleteProductHandler
   /// </summary>
   /// <param name="provider">Service locator for DI</param>
   public DeleteProductHandler(IServiceProvider provider) =>
      _unitOfWork = provider.GetRequiredService<IUnitOfWork>();

   /// <summary>
   /// Handles the DeleteProductCommand request
   /// </summary>
   /// <param name="request">The DeleteProduct command</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The result of the delete operation</returns>
   public async Task<DeleteProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
   {
      var validationResult = await new DeleteProductValidator()
         .ValidateAsync(request, cancellationToken);

      if (!validationResult.IsValid)
         throw new ValidationException(validationResult.Errors);

      var deleted = await _unitOfWork.Products.DeleteAsync(request.Id, cancellationToken);
      if (deleted is null) throw new KeyNotFoundException($"Product with ID {request.Id} not found");

      return new DeleteProductResult { Success = true };
   }
}
