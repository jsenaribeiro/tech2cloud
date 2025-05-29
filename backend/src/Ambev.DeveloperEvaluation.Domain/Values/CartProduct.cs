namespace Ambev.DeveloperEvaluation.Domain.Values;

/// <summary>
/// Represents a product in the shopping cart.
/// </summary>
public class CartProduct
{
   /// <summary>
   /// Initializes a new instance of the <see cref="CartProduct"/> class.
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
   /// Unique identifier of the cart product.
   /// </summary>
   /// <value></value>
   public int Id { get; set; }

   /// <summary>
   /// Gets or sets the product identifier.
   /// </summary>
   public int ProductId { get; set; }

   /// <summary>
   /// Gets or sets the quantity of the product.
   /// </summary>
   public int Quantity { get; set; }
}