using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;

/// <summary>
/// Handler for processing DeleteProductCommand requests
/// </summary>
public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductResult>
{
   private readonly IProductRepository _productRepository;

   /// <summary>
   /// Initializes a new instance of DeleteProductHandler
   /// </summary>
   /// <param name="productRepository">The product repository</param>
   /// <param name="validator">The validator for DeleteProductCommand</param>
   public DeleteProductHandler(IServiceProvider provider) =>
      _productRepository = provider.GetRequiredService<IProductRepository>();

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

      var success = await _productRepository.DeleteAsync(request.Id, cancellationToken);
      if (!success)
         throw new KeyNotFoundException($"Product with ID {request.Id} not found");

      return new DeleteProductResult { Success = true };
   }
}
