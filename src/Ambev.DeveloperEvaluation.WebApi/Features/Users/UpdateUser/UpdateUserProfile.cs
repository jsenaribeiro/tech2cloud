using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Users.UpdateUser;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.UpdateUser;

/// <summary>
/// Profile for mapping between Application and API UpdateUser responses
/// </summary>
public class UpdateUserProfile : Profile
{
   /// <summary>
   /// Initializes the mappings for UpdateUser feature
   /// </summary>
   public UpdateUserProfile()
   {
      CreateMap<UpdateUserResult, UpdateUserResponse>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));
            
      CreateMap<UpdateUserRequest, UpdateUserCommand>()
         .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.For<UserStatus>()))
         .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.For<UserRole>()));
   }
}
