using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Pagination;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts;

/// <summary>
/// Profile for mapping between Product entity and GetProductsResponse
/// </summary>
public class GetProductsProfile : Profile
{
   /// <summary>
   /// Initializes the mappings for GetProducts operation
   /// </summary>
   public GetProductsProfile()
   {
      CreateMap<Product, GetProductsResult>();
      CreateMap<PageList<Product>, PageList<GetProductsResult>>()
          .ConstructUsing((src, ctx) =>
          {
             var list = src.Data.Select(x => ctx.Mapper.Map<GetProductsResult>(x)).ToList();
             return new PageList<GetProductsResult>(list, src.TotalCount, src.CurrentPage, src.PageSize);
          });

   }
}
