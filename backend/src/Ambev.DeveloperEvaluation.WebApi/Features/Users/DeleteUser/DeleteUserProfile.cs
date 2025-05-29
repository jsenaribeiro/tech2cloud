using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.DeleteUser;

/// <summary>
/// Profile for mapping DeleteUser feature requests to commands
/// </summary>
public class DeleteUserProfile : Profile
{
   /// <summary>
   /// Initializes the mappings for DeleteUser feature
   /// </summary>
   public DeleteUserProfile()
   {
      CreateMap<int, DeleteUserCommand>()
          .ConstructUsing(id => new DeleteUserCommand(id));

      CreateMap<DeleteUserResult, DeleteUserResponse>()
         .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
         .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));
   }
}
