using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Profile for mapping between cart entity and CreateCartResponse
/// </summary>
public class CreateCartProfile : Profile
{
   /// <summary>
   /// Initializes the mappings for CreateCart operation
   /// </summary>
   public CreateCartProfile()
   {
      CreateMap<CreateCartCommand, Cart>()
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
               cartProduct.CreatedAt = DateTime.UtcNow;
               cartProduct.UpdatedAt = null;
               cart.Append(cartProduct);
            }

            return cart;
         });

      CreateMap<Cart, CreateCartResult>();
      CreateMap<CreateCartProductCommand, CartProduct>();
      CreateMap<CartProduct, CreateCartProductResult>();
   }
}
