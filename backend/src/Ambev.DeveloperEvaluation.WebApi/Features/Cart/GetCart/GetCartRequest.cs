namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;

/// <summary>
/// Request model for retrieving a cart by their ID
/// </summary>
public record GetCartRequest
{
    /// <summary>
    /// The unique identifier of the cart to retrieve
    /// </summary>
    public int Id { get; }

   /// <summary>
   /// Initializes a new instance of GetCartRequest
   /// </summary>
   /// <param name="id">The ID of the cart to retrieve</param>
   public GetCartRequest(int id)
    {
        Id = id;
    }
}
