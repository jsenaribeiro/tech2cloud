using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

/// <summary>
/// Profile for mapping for UpdateCart
/// </summary>
public class UpdateCartProfile : Profile
{
   /// <summary>
   /// Initializes the mappings for UpdateCart operation
   /// </summary>
   public UpdateCartProfile()
   {
      CreateMap<UpdateCartRequest, UpdateCartCommand>();
      CreateMap<UpdateCartResult, UpdateCartResponse>();
   }
}
