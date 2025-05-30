using MediatR;
using AutoMapper;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Ambev.DeveloperEvaluation.Domain.Values;
using Ambev.DeveloperEvaluation.Domain;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts;

/// <summary>
/// Handler for processing GetProductsQuery requests
/// </summary>
public class GetProductsHandler : IRequestHandler<GetProductsQuery, PageList<GetProductsResult>>
{
   private readonly IUnitOfWork _unitOfWork;
   private readonly IMapper _mapper;

   /// <summary>
   /// Initializes a new instance of GetProductsHandler
   /// </summary>
   /// <param name="provider">Service locator for DI</param>
   public GetProductsHandler(IServiceProvider provider)
   {
      _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
      _mapper = provider.GetRequiredService<IMapper>();
   }

   /// <summary>
   /// Handles the GetProductsQuery request
   /// </summary>
   /// <param name="request">The GetProducts query</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The product list if found</returns>
   public async Task<PageList<GetProductsResult>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
   {
      var products = await _unitOfWork.Products.ListAsync(request);
      if (products is null) throw new KeyNotFoundException($"Products not found");

      return _mapper.Map<PageList<GetProductsResult>>(products);
   }
}
