using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale;

/// <summary>
/// Validator for CancelSaleRequest that defines validation rules for sale creation.
/// </summary>
public class CancelSaleRequestValidator : AbstractValidator<CancelSaleRequest>
{
   /// <summary>
   /// Initializes a new instance of the CancelSaleCommandValidator with defined validation rules.
   /// </summary>
   /// <remarks>
   /// Validation rules include:
   /// - CartId: required
   /// </remarks>
   public CancelSaleRequestValidator()
   {
      RuleFor(sale => sale.CartId).NotEmpty();
   }
}