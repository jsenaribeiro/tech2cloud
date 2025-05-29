using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Query for retrieving a product by their ID
/// </summary>
public record GetProductQuery : IRequest<GetProductResult>
{
    /// <summary>
    /// The unique identifier of the product to retrieve
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Initializes a new instance of GetProductQuery
    /// </summary>
    /// <param name="id">The ID of the product to retrieve</param>
    public GetProductQuery(int id)
    {
        Id = id;
    }
}
