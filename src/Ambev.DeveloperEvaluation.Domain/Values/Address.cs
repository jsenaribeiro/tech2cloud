namespace Ambev.DeveloperEvaluation.Domain.Values;

public class Address
{
   /// <summary>
   /// City.
   /// </summary>
   public string City { get; set; } = string.Empty;

   /// <summary>
   /// Street address.
   /// </summary>
   public string Street { get; set; } = string.Empty;

   /// <summary> 
   /// House number.
   /// </summary>
   public int Number { get; set; }

   /// <summary>
   /// State.
   /// </summary>
   public string State { get; set; } = string.Empty;

   /// <summary>
   /// Zip code.
   /// </summary>
   public string ZipCode { get; set; } = string.Empty;

   /// <summary>
   /// Country.
   /// </summary>
   public string Country { get; set; } = string.Empty;

   /// <summary>
   /// Geographical location represented by latitude and longitude.
   /// </summary>
   public Geolocation Geolocation { get; set; } = new Geolocation();
}