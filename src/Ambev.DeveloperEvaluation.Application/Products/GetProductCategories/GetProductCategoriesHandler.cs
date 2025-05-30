using MediatR;
using AutoMapper;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Ambev.DeveloperEvaluation.Domain;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductCategories;

/// <summary>
/// Handler for processing GetProductCategoriesQuery requests
/// </summary>
public class GetProductCategoriesHandler : IRequestHandler<GetProductCategoriesQuery, string[]>
{
   private readonly IUnitOfWork _unitOfWork;

   /// <summary>
   /// Initializes a new instance of GetProductCategoriesHandler
   /// </summary>
   /// <param name="provider">Service locator for DI</param>
   public GetProductCategoriesHandler(IServiceProvider provider) =>
      _unitOfWork = provider.GetRequiredService<IUnitOfWork>();

   /// <summary>
   /// Handles the GetProductCategoriesQuery request
   /// </summary>
   /// <param name="request">The GetProductCategories query</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The categories if found</returns>
   public async Task<string[]> Handle(GetProductCategoriesQuery request, CancellationToken cancellationToken)
   {
      var categories = await _unitOfWork.Products.ListAllCategoriesAsync();
      if (categories is null) throw new KeyNotFoundException($"Categories not found");

      return categories.ToArray();
   }
}
