using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Validator for GetProductQuery
/// </summary>
public class GetProductValidator : AbstractValidator<GetProductQuery>
{
    /// <summary>
    /// Initializes validation rules for GetProductQuery
    /// </summary>
    public GetProductValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Product ID is required");
    }
}
