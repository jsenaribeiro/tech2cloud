using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

/// <summary>
/// Validator for UpdateCartRequest that defines validation rules for cart update Request.
/// </summary>
public class UpdateCartRequestValidator : AbstractValidator<UpdateCartRequest>
{
   /// <summary>
   /// Initializes a new instance of the UpdateCartRequestValidator with defined validation rules.
   /// </summary>
   /// Validation rules include:
   /// - UserId: required
   /// - Date: required
   /// - Products: must contain at least one product
   /// </remarks>
   public UpdateCartRequestValidator()
   {
      RuleFor(cart => cart.UserId).NotEmpty();
      RuleFor(cart => cart.Date).NotEmpty();
      RuleFor(cart => cart.Products.Count).GreaterThan(0);
   }
}