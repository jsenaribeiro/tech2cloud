using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleRequest that defines validation rules for sale creation.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
   /// <summary>
   /// Initializes a new instance of the CreateSaleCommandValidator with defined validation rules.
   /// </summary>
   /// <remarks>
   /// Validation rules include:
   /// - CartId: required
   /// </remarks>
   public CreateSaleRequestValidator()
   {
      RuleFor(sale => sale.CartId).NotEmpty();
   }
}