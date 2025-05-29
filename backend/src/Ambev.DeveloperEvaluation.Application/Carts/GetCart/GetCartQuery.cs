using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Query for retrieving a cart by their ID
/// </summary>
public record GetCartQuery : IRequest<GetCartResult>
{
    /// <summary>
    /// The unique identifier of the cart to retrieve
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Initializes a new instance of GetCartQuery
    /// </summary>
    /// <param name="id">The ID of the cart to retrieve</param>
    public GetCartQuery(int id)
    {
        Id = id;
    }
}
