using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Validator for GetCartQuery
/// </summary>
public class GetCartValidator : AbstractValidator<GetCartQuery>
{
    /// <summary>
    /// Initializes validation rules for GetCartQuery
    /// </summary>
    public GetCartValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Cart ID is required");
    }
}
