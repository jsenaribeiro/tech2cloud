namespace Ambev.DeveloperEvaluation.WebApi.Common;

/// <summary>
/// Retrieve a T list with query parameters
/// </summary>
public class PaginatedRequest<T>
{
   /// <summary>
   /// Page number for pagination (default: 1)
   /// </summary>
   public int _page { get; set; } = 1;

   /// <summary>
   /// Number of items per page (default: 10)
   /// </summary>
   public int _size { get; set; } = 10;

   /// <summary>
   /// Ordering of results (e.g., "price desc, title asc")
   /// </summary>
   public string _order { get; set; } = string.Empty;
}