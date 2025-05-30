using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using System.Globalization;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

/// <summary>
/// Profile for mapping between Application and API CreateCart responses
/// </summary>
public class CreateCartProfile : Profile
{
   /// <summary>
   /// Initializes the mappings for CreateCart feature
   /// </summary>
   public CreateCartProfile()
   {
      CreateMap<CreateCartRequest, CreateCartCommand>()
         .ForMember(dest => dest.Date, opt => opt.MapFrom(src => ParseDate(src.Date)));

      CreateMap<CreateCartResult, CreateCartResponse>();
      CreateMap<CreateCartProductRequest, CreateCartProductCommand>();
      CreateMap<CreateCartProductResult, CreateCartProductResponse>();
   }

   private DateTime ParseDate(string dateString)
   {
      dateString = dateString.Trim();

      var dateStyle = DateTimeStyles.RoundtripKind;
      var culture = CultureInfo.InvariantCulture;

      string[] formats = {
         "yyyy-MM-dd",
         "yyyy-MM-ddTHH:mm:ss",
         "yyyy-MM-ddTHH:mm:ssZ",
         "yyyy-MM-dd HH:mm:ss",
         "dd/MM/yyyy",
         "dd/MM/yyyy HH:mm:ss",
         "MM/dd/yyyy",
         "MM/dd/yyyy HH:mm:ss",
         "yyyy-MM-ddTHH:mm:ss.fffZ",
         "o", // ISO 8601
         "s"  // Sortable
      };

      if (DateTime.TryParseExact(dateString, formats, culture, dateStyle, out var date)) return date;
      else throw new ArgumentException("Invalid date format", nameof(dateString));
   }
}
