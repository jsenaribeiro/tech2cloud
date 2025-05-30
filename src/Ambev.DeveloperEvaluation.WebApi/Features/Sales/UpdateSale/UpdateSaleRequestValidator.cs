using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Validator for UpdateSaleRequest that defines validation rules for sale creation.
/// </summary>
public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
{
   /// <summary>
   /// Initializes a new instance of the UpdateSaleCommandValidator with defined validation rules.
   /// </summary>
   /// <remarks>
   /// Validation rules include:
   /// - NewCartId: required
   /// - OldCartId: required
   /// </remarks>
   public UpdateSaleRequestValidator()
   {
      RuleFor(sale => sale.NewCartId).NotEmpty();
      RuleFor(sale => sale.OldCartId).NotEmpty();
   }
}