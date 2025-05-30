using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

/// <summary>
/// Profile for mapping between cart entity and UpdateCartResponse
/// </summary>
public class UpdateCartProfile : Profile
{
   /// <summary>
   /// Initializes the mappings for UpdateCart operation
   /// </summary>
   public UpdateCartProfile()
   {
      CreateMap<UpdateCartCommand, Cart>()
         .ForMember(x => x.Id, opt => opt.Ignore())
         .ForMember(x => x.Products, opt => opt.Ignore())
         .ConstructUsing((src, ctx) =>
         {
            var cart = new Cart
            {
               UserId = src.UserId,
               Date = DateTime.SpecifyKind(src.Date, DateTimeKind.Utc)
            };

            foreach (var product in src.Products)
            {
               var cartProduct = ctx.Mapper.Map<CartProduct>(product);
               cart.Append(cartProduct);
            }            

            return cart;
         });

      CreateMap<Cart, UpdateCartResult>();
      CreateMap<UpdateCartProductCommand, CartProduct>();
      CreateMap<CartProduct, UpdateCartProductResult>();
   }
}
