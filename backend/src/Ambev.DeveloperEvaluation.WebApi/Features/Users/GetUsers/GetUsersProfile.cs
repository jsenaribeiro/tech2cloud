using Ambev.DeveloperEvaluation.Application.Users.GetUsers;
using Ambev.DeveloperEvaluation.Domain.Values;
using Ambev.DeveloperEvaluation.WebApi.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUsers;

/// <summary>
/// Profile for mapping GetUsers feature requests to commands
/// </summary>
public class GetUsersProfile : Profile
{
   /// <summary>
   /// Initializes the mappings for GetUsers feature
   /// </summary>
   public GetUsersProfile()
   {
      CreateMap<GetUsersRequest, GetUsersQuery>();
      CreateMap<GetUsersResult, GetUsersResponse>()
         .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
         .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));

      CreateMap<PageList<GetUsersResult>, PageList<GetUsersResponse>>()
         .ConstructUsing((src, ctx) =>
         {
            var list = src.Data.Select(x => ctx.Mapper.Map<GetUsersResponse>(x)).ToList();
            return new PageList<GetUsersResponse>(list, src.TotalCount, src.CurrentPage, src.PageSize);
         });
   }

   private string ConvertToDMS(double decimalDegree, bool isLatitude)
   {
      var direction = isLatitude
         ? decimalDegree >= 0 ? "N" : "S"
         : decimalDegree >= 0 ? "E" : "W";

      var absValue = Math.Abs(decimalDegree);
      var degrees = (int)Math.Floor(absValue);
      var minutesDecimal = (absValue - degrees) * 60;
      var minutes = (int)Math.Floor(minutesDecimal);
      var seconds = (minutesDecimal - minutes) * 60;

      return $"{degrees}°{minutes}'{seconds:0.##}\" {direction}";
   }
}
