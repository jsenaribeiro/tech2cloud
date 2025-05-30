using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Products.GetProductsByCategory;
using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductsByCategory;

/// <summary>
/// Profile for mapping between Product GetProductsByCategoryResult and GetProductsByCategoryResponse
/// </summary>
public class GetProductsByCategoryProfile : Profile
{
   /// <summary>
   /// Initializes the mappings for GetProductsByCategory operation
   /// </summary>
   public GetProductsByCategoryProfile()
   {
      CreateMap<GetProductsByCategoryRequest, GetProductsByCategoryQuery>();
      CreateMap<GetProductsByCategoryResult, GetProductsByCategoryResponse>();

      CreateMap<PageList<GetProductsByCategoryResult>, PageList<GetProductsByCategoryResponse>>()
         .ConstructUsing((src, ctx) =>
         {
            var list = src.Data.Select(x => ctx.Mapper.Map<GetProductsByCategoryResponse>(x)).ToList();
            return new PageList<GetProductsByCategoryResponse>(list, src.TotalCount, src.CurrentPage, src.PageSize);
         });
   }
}
