using MediatR;
using AutoMapper;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductCategories;

/// <summary>
/// Handler for processing GetProductCategoriesQuery requests
/// </summary>
public class GetProductCategoriesHandler : IRequestHandler<GetProductCategoriesQuery, string[]>
{
   private readonly IProductRepository _productRepository;

   /// <summary>
   /// Initializes a new instance of GetProductCategoriesHandler
   /// </summary>
   /// <param name="provider">The service locator for dependencies</param>
   public GetProductCategoriesHandler(IServiceProvider provider) =>
      _productRepository = provider.GetRequiredService<IProductRepository>();

   /// <summary>
   /// Handles the GetProductCategoriesQuery request
   /// </summary>
   /// <param name="request">The GetProductCategories query</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The categories if found</returns>
   public async Task<string[]> Handle(GetProductCategoriesQuery request, CancellationToken cancellationToken)
   {
      var categories = await _productRepository.ListAllCategoriesAsync();
      if (categories is null)
         throw new KeyNotFoundException($"Categories not found");

      return categories.ToArray();
   }
}
