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
        CreateMap<UpdateCartCommand, Cart>();
        CreateMap<Cart, UpdateCartResult>();
    }
}
