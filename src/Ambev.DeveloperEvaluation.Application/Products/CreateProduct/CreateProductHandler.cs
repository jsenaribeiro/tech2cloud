using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;
using Microsoft.Extensions.DependencyInjection;
using Ambev.DeveloperEvaluation.Domain;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Handler for processing CreateProductCommand requests
/// </summary>
public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
{
   private readonly IUnitOfWork _unitOfWork;
   private readonly IMapper _mapper;

   /// <summary>
   /// Initializes a new instance of CreateProductHandler
   /// </summary>
   /// <param name="provider">Service locator for DI</param>
   public CreateProductHandler(IServiceProvider provider)
   {
      _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
      _mapper = provider.GetRequiredService<IMapper>();
   }

   /// <summary>
   /// Handles the CreateProductCommand request
   /// </summary>
   /// <param name="command">The CreateProduct command</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The created product details</returns>
   public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
   {
      var validationResult = await new CreateProductCommandValidator()
          .ValidateAsync(command, cancellationToken);

      if (!validationResult.IsValid)
         throw new ValidationException(validationResult.Errors);

      var product = _mapper.Map<Product>(command);
      var createdProduct = await _unitOfWork.Products.CreateAsync(product, cancellationToken);
      var result = _mapper.Map<CreateProductResult>(createdProduct);

      return result;
   }
}
