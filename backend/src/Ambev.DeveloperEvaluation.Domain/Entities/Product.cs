using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Request model for getting a user by ID
/// </summary>
public class Product : BaseEntity<int>
{
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

