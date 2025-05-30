using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;
using Microsoft.Extensions.DependencyInjection;
using Ambev.DeveloperEvaluation.Domain;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

/// <summary>
/// Handler for processing UpdateProductCommand requests
/// </summary>
public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResult>
{
   private readonly IUnitOfWork _unitOfWork;
   private readonly IMapper _mapper;

   /// <summary>
   /// Initializes a new instance of UpdateProductHandler
   /// </summary>
   /// <param name="provider">The service locator for dependencies</param>
   public UpdateProductHandler(IServiceProvider provider)
   {
      _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
      _mapper = provider.GetRequiredService<IMapper>();
   }

   /// <summary>
   /// Handles the UpdateProductCommand request
   /// </summary>
   /// <param name="command">The UpdateProduct command</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The updated product details</returns>
   public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
   {
      var validationResult = await new UpdateProductCommandValidator()
          .ValidateAsync(command, cancellationToken);

      if (!validationResult.IsValid)
         throw new ValidationException(validationResult.Errors);

      var product = _mapper.Map<Product>(command);
      var updatedProduct = await _unitOfWork.Products.UpdateAsync(product, cancellationToken);
      var result = _mapper.Map<UpdateProductResult>(updatedProduct);

      return result;
   }
}
