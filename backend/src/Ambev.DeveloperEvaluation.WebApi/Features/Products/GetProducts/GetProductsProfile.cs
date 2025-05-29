using Ambev.DeveloperEvaluation.Application.Products.GetProducts;
using Ambev.DeveloperEvaluation.Common.Pagination;
using Ambev.DeveloperEvaluation.Domain.Values;
using Ambev.DeveloperEvaluation.WebApi.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;

/// <summary>
/// Profile for mapping GetProducts feature requests to commands
/// </summary>
public class GetProductsProfile : Profile
{
   /// <summary>
   /// Initializes the mappings for GetProducts feature
   /// </summary>
   public GetProductsProfile()
   {
      CreateMap<GetProductsRequest, GetProductsQuery>();
      CreateMap<GetProductsResult, GetProductsResponse>();

      CreateMap<PageList<GetProductsResult>, PageList<GetProductsResponse>>()
         .ConstructUsing((src, ctx) =>
         {
            var list = src.Data.Select(x => ctx.Mapper.Map<GetProductsResponse>(x)).ToList();
            return new PageList<GetProductsResponse>(list, src.TotalCount, src.CurrentPage, src.PageSize);
         });

   }
}
