using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

/// <summary>
/// Profile for mapping for UpdateProduct
/// </summary>
public class UpdateProductProfile : Profile
{
   /// <summary>
   /// Initializes the mappings for UpdateProduct operation
   /// </summary>
   public UpdateProductProfile()
   {
      CreateMap<UpdateProductRequest, UpdateProductCommand>();
      CreateMap<UpdateProductResult, UpdateProductResponse>();
   }
}
