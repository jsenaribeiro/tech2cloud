using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Validator for CreateCartCommand that defines validation rules for cart creation command.
/// </summary>
public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
{
   /// <summary>
   /// Initializes a new instance of the CreateCartCommandValidator with defined validation rules.
   /// </summary>
   /// <remarks>
   /// Validation rules include:
   /// - UserId: required
   /// - Date: required
   /// - Products: must contain at least one product
   /// </remarks>
   public CreateCartCommandValidator()
   {
      RuleFor(cart => cart.UserId).NotEmpty();
      RuleFor(cart => cart.Date).NotEmpty();
      RuleFor(cart => cart.Products.Count).GreaterThan(0);
   }
}