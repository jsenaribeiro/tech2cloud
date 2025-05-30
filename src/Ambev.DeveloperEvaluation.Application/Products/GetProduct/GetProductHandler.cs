using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Ambev.DeveloperEvaluation.Domain;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Handler for processing GetProductQuery requests
/// </summary>
public class GetProductHandler : IRequestHandler<GetProductQuery, GetProductResult>
{
   private readonly IUnitOfWork _unitOfWork;
   private readonly IMapper _mapper;

   /// <summary>
   /// Initializes a new instance of GetProductHandler
   /// </summary>
   /// <param name="provider">Service locator for DI</param>
   public GetProductHandler(IServiceProvider provider)
   {
      _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
      _mapper = provider.GetRequiredService<IMapper>();
   }

   /// <summary>
   /// Handles the GetProductQuery request
   /// </summary>
   /// <param name="request">The GetProduct query</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The product details if found</returns>
   public async Task<GetProductResult> Handle(GetProductQuery request, CancellationToken cancellationToken)
   {
      var validator = new GetProductValidator();
      var validationResult = await validator.ValidateAsync(request, cancellationToken);

      if (!validationResult.IsValid)
         throw new ValidationException(validationResult.Errors);

      var product = await _unitOfWork.Products.GetAsync(request.Id, cancellationToken);
      if (product == null)
         throw new KeyNotFoundException($"Product with ID {request.Id} not found");

      return _mapper.Map<GetProductResult>(product);
   }
}
