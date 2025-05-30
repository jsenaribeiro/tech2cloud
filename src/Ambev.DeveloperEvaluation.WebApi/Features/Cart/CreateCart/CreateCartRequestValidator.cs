using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

/// <summary>
/// Validator for CreateCartRequest that defines validation rules for cart creation.
/// </summary>
public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
{
   /// <summary>
   /// Initializes a new instance of the CreateCartCommandValidator with defined validation rules.
   /// </summary>
   /// <remarks>
   /// Validation rules include:
   /// - Date: required
   /// - Products: must contain at least one product
   /// </remarks>
   public CreateCartRequestValidator()
   {
      RuleFor(cart => cart.Date).NotEmpty();
      RuleFor(cart => cart.Products.Count).GreaterThan(0);
   }
}