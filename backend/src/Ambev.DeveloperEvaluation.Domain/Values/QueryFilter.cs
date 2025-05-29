using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.Domain.Values;

/// <summary>
/// Filter contract for pagination and ordering
/// </summary>
public class QueryFilter
{
   public QueryFilter() { }


   /// <summary>
   /// Initializes a new instance of the QueryFilter class with specified page, size, and order.
   /// </summary>
   /// <param name="page">The page number</param>
   /// <param name="size">The page size</param>
   /// <param name="order">The ordering page</param>
   public QueryFilter(int page, int size, string? order)
   {
      Page = page;
      Size = size;
      Order = order ?? string.Empty;
   }

   /// <summary>
   /// Page number for pagination (default: 1)
   /// </summary>
   [DefaultValue(1)]
   [JsonPropertyName("_page")]
   public int Page { get; set; } = 1;

   /// <summary>
   /// Number of items per page (default: 10)
   /// </summary>
   [DefaultValue(10)]
   [JsonPropertyName("_size")]
   public int Size { get; set; } = 10;

   /// <summary>
   /// Ordering of results (e.g., "price desc, title asc")
   /// </summary>
   [JsonPropertyName("_order")]
   public string Order { get; set; } = string.Empty;
}