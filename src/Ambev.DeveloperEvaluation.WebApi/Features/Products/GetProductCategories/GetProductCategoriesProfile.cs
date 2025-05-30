using Ambev.DeveloperEvaluation.Application.Products.GetProductCategories;
using Ambev.DeveloperEvaluation.Application.Products.GetProducts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductCategories;

/// <summary>
/// Profile for mapping GetProducts feature requests to commands
/// </summary>
public class GetProductCategoriesProfile : Profile
{
   /// <summary>
   /// Initializes the mappings for GetProducts feature
   /// </summary>
   public GetProductCategoriesProfile()
   {
      CreateMap<GetProductCategoriesRequest, GetProductCategoriesQuery>();
   }
}
