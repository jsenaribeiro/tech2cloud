using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.Application.Users.GetUsers;

/// <summary>
/// Profile for mapping between User entity and GetUsersResponse
/// </summary>
public class GetUsersProfile : Profile
{
   /// <summary>
   /// Initializes the mappings for GetUsers operation
   /// </summary>
   public GetUsersProfile()
   {
      CreateMap<User, GetUsersResult>();
      CreateMap<PageList<User>, PageList<GetUsersResult>>()
          .ConstructUsing((src, ctx) =>
          {
             var list = src.Data.Select(x => ctx.Mapper.Map<GetUsersResult>(x)).ToList();
             return new PageList<GetUsersResult>(list, src.TotalCount, src.CurrentPage, src.PageSize);
          });
   }
}
