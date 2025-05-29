using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;

/// <summary>
/// Profile for mapping between Cart GetCartResult and GetCartRequest
/// </summary>
public class GetCartProfile : Profile
{
   /// <summary>
   /// Initializes the mappings for GetCart operation
   /// </summary>
   public GetCartProfile()
   {
      CreateMap<int, GetCartQuery>()
          .ConstructUsing(id => new GetCartQuery(id));

      CreateMap<GetCartResult, GetCartResponse>();
   }
}
