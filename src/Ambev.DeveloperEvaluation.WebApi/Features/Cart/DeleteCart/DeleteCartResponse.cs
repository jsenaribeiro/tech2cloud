namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCart;

/// <summary>
/// Response model for DeleteCart operation
/// </summary>
public class DeleteCartResponse
{
   /// <summary>
   /// Indicates whether the deletion was successful
   /// </summary>
   public string Message { get; set; } = "The cart was deleted with success";
}
