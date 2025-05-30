using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a product in the shopping cart.
/// </summary>
public class CartProduct : BaseEntity<int>
{
   /// <summary>
   /// Initializes a new instance of CarProduct
   /// </summary>
   public CartProduct() { }

   /// <summary>
   /// Initializes a new instance of Cart Product
   /// </summary>
   public CartProduct(int productId, int quantity)
   {
      ProductId = productId;
      Quantity = quantity;
   }

   /// <summary>
   /// Gets or sets the product identifier.
   /// </summary>
   public int ProductId { get; set; }

   /// <summary>
   /// Gets or sets the quantity of the product.
   /// </summary>
   public int Quantity { get; set; }
}