using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

/// <summary>
/// Profile for mapping between Product GetProductResult and GetProductRequest
/// </summary>
public class GetProductProfile : Profile
{
   /// <summary>
   /// Initializes the mappings for GetProduct operation
   /// </summary>
   public GetProductProfile()
   {
      CreateMap<Guid, GetProductQuery>()
          .ConstructUsing(id => new GetProductQuery(id));

      CreateMap<GetProductResult, GetProductResponse>();
   }
}
