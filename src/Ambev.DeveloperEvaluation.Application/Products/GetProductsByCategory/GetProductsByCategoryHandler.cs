using MediatR;
using AutoMapper;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Ambev.DeveloperEvaluation.Domain.Values;
using Ambev.DeveloperEvaluation.Domain;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductsByCategory;

/// <summary>
/// Handler for processing GetProductsByCategoryQuery requests
/// </summary>
public class GetProductsByCategoryHandler : IRequestHandler<GetProductsByCategoryQuery, PageList<GetProductsByCategoryResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

   /// <summary>
   /// Initializes a new instance of GetProductsByCategoryHandler
   /// </summary>
   /// <param name="provider">Service locator for DI</param>
   public GetProductsByCategoryHandler(IServiceProvider provider)
    {
        _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
        _mapper = provider.GetRequiredService<IMapper>();
    }

   /// <summary>
   /// Handles the GetProductsByCategoryQuery request
   /// </summary>
   /// <param name="request">The GetProductsByCategory query</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The products if found</returns>
   public async Task<PageList<GetProductsByCategoryResult>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
   {
      var validationResult = await new GetProductsByCategoryValidator()
         .ValidateAsync(request, cancellationToken);

      if (!validationResult.IsValid)
         throw new ValidationException(validationResult.Errors);

      var category = request.CategoryName;

      var filter = new QueryFilter(request.Page, request.Size, request.Order);

      var products = await _unitOfWork.Products.ListByCategoryAsync(filter, category);
      if (products is null) throw new KeyNotFoundException($"Products not found");

      return _mapper.Map<PageList<GetProductsByCategoryResult>>(products);
   }
}
