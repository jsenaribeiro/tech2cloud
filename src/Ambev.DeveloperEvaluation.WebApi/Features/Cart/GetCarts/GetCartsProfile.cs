using Ambev.DeveloperEvaluation.Application.Carts.GetCarts;
using Ambev.DeveloperEvaluation.Domain.Values;
using Ambev.DeveloperEvaluation.WebApi.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCarts;

/// <summary>
/// Profile for mapping GetCarts feature requests to commands
/// </summary>
public class GetCartsProfile : Profile
{
   /// <summary>
   /// Initializes the mappings for GetCarts feature
   /// </summary>
   public GetCartsProfile()
   {
      CreateMap<GetCartsRequest, GetCartsQuery>();
      CreateMap<GetCartsResult, GetCartsResponse>();

      CreateMap<PageList<GetCartsResult>, PageList<GetCartsResponse>>()
         .ConstructUsing((src, ctx) =>
         {
            var list = src.Data.Select(x => ctx.Mapper.Map<GetCartsResponse>(x)).ToList();
            return new PageList<GetCartsResponse>(list, src.TotalCount, src.CurrentPage, src.PageSize);
         });

   }
}
