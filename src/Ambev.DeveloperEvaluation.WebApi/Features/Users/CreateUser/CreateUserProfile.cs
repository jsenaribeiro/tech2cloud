using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;

/// <summary>
/// Profile for mapping between Application and API CreateUser responses
/// </summary>
public class CreateUserProfile : Profile
{
   /// <summary>
   /// Initializes the mappings for CreateUser feature
   /// </summary>
   public CreateUserProfile()
   {
      CreateMap<CreateUserRequest, CreateUserCommand>()
         .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.For<UserStatus>()))
         .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.For<UserRole>()));

      CreateMap<CreateUserResult, CreateUserResponse>()
         .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
         .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));
   }
}


