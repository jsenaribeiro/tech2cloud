using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Pagination;
using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCarts;

/// <summary>
/// Profile for mapping between Cart entity and GetCartsResponse
/// </summary>
public class GetCartsProfile : Profile
{
   /// <summary>
   /// Initializes the mappings for GetCarts operation
   /// </summary>
   public GetCartsProfile()
   {
      CreateMap<Cart, GetCartsResult>();
      CreateMap<PageList<Cart>, PageList<GetCartsResult>>()
          .ConstructUsing((src, ctx) =>
          {
             var list = src.Data.Select(x => ctx.Mapper.Map<GetCartsResult>(x)).ToList();
             return new PageList<GetCartsResult>(list, src.TotalCount, src.CurrentPage, src.PageSize);
          });

   }
}
