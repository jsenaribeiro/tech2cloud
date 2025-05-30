namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCart;

/// <summary>
/// Request model for deleting a cart
/// </summary>
public class DeleteCartRequest 
{
    /// <summary>
    /// The unique identifier of the cart to delete
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Initializes a new instance of DeleteCartCommand
    /// </summary>
    /// <param name="id">The ID of the cart to delete</param>
    public DeleteCartRequest(int id)
    {
        Id = id;
    }
}
