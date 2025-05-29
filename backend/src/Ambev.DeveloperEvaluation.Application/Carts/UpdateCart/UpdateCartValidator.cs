using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

/// <summary>
/// Validator for UpdateCartCommand that defines validation rules for cart update command.
/// </summary>
public class UpdateCartCommandValidator : AbstractValidator<UpdateCartCommand>
{
   /// <summary>
   /// Initializes a new instance of the UpdateCartCommandValidator with defined validation rules.
   /// </summary>
   /// <remarks>
   /// Validation rules include:
   /// - Id: required
   /// - UserId: required
   /// - Date: required
   /// - Products: must contain at least one product
   /// </remarks>
   public UpdateCartCommandValidator()
   {
      RuleFor(cart => cart.Id).NotEmpty();
      RuleFor(cart => cart.UserId).NotEmpty();
      RuleFor(cart => cart.Date).NotEmpty();
      RuleFor(cart => cart.Products.Count).GreaterThan(0);
   }
}