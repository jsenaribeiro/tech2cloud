namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;

/// <summary>
/// Response model for DeleteProduct operation
/// </summary>
public class DeleteProductResponse
{
   /// <summary>
   /// Indicates whether the deletion was successful
   /// </summary>
   public string Message { get; set; } = "The product was deleted with success";
}
