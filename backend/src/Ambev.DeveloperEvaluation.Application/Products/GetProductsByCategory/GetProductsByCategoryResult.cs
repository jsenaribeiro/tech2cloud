using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductsByCategory;

/// <summary>
/// Response model for GetProductsByCategory operation
/// </summary>
public class GetProductsByCategoryResult
{
   /// <summary>
   /// The unique identifier of the product to retrieve
   /// </summary>
   public int Id { get; set; }

   /// <summary>
   /// Title or name of the product.
   /// </summary>
   public string Title { get; set; } = string.Empty;

   /// <summary>
   /// Price of the product.
   /// </summary>
   public decimal Price { get; set; }

   /// <summary>
   /// Detailed description of the product.
   /// </summary>
   public string Description { get; set; } = string.Empty;

   /// <summary>
   /// Category to which the product belongs.
   /// </summary>
   public string Category { get; set; } = string.Empty;

   /// <summary>
   /// URL of the product's image.
   /// </summary>
   public string Image { get; set; } = string.Empty;

   /// <summary>
   /// Rating information for the product.
   /// It is ValueObject ORM mapping
   /// </summary>
   public Rating? Rating { get; set; }
}
