using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Represents the response returned after successfully creating a new product.
/// </summary>
public class CreateProductResult
{
   /// <summary>
   /// Unique identifier of the newly created product.
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
   /// </summary>
   public Rating? Rating { get; set; }
}
