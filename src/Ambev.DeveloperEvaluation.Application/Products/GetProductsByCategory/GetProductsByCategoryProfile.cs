using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductsByCategory;

/// <summary>
/// Profile for mapping between Product entity and GetProductsByCategoryResult
/// </summary>
public class GetProductsByCategoryProfile : Profile
{
   /// <summary>
   /// Initializes the mappings for GetProductsByCategory operation
   /// </summary>
   public GetProductsByCategoryProfile()
   {
      CreateMap<Product, GetProductsByCategoryResult>();
      CreateMap<PageList<Product>, PageList<GetProductsByCategoryResult>>()
         .ConstructUsing((src, ctx) =>
         {
            var list = src.Data.Select(x => ctx.Mapper.Map<GetProductsByCategoryResult>(x)).ToList();
            return new PageList<GetProductsByCategoryResult>(list, src.TotalCount, src.CurrentPage, src.PageSize);
         });
   }
}
