namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

/// <summary>
/// Request model for retrieving a product by their ID
/// </summary>
public record GetProductRequest
{
    /// <summary>
    /// The unique identifier of the product to retrieve
    /// </summary>
    public Guid Id { get; }

   /// <summary>
   /// Initializes a new instance of GetProductRequest
   /// </summary>
   /// <param name="id">The ID of the product to retrieve</param>
   public GetProductRequest(Guid id)
    {
        Id = id;
    }
}
