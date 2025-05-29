using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.Domain.Values;

public class Geolocation
{
   /// <summary>
   /// Latitude of the geographical location.
   /// </summary>
   [JsonPropertyName("lat")]
   public string Latitude { get; set; } = string.Empty;

   /// <summary>
   /// Longitude of the geographical location.
   /// </summary>
   [JsonPropertyName("long")]
   public string Longitude { get; set; } = string.Empty;

   /// <summary>
   /// Initializes a new instance of Geo class
   /// </summary>
   public Geolocation() { }

   /// <summary>
   /// Initializes a new instance of Geo class
   /// </summary>
   public Geolocation(string latitude, string longitude)
   {
      Latitude = latitude;
      Longitude = longitude;
   }
}