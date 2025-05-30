using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

/// <summary>
/// Validator for UpdateProductRequest that defines validation rules for product update Request.
/// </summary>
public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
   /// <summary>
   /// Initializes a new instance of the UpdateProductRequestValidator with defined validation rules.
   /// </summary>
   /// <remarks>
   /// Validation rules include:
   /// - Title: required
   /// - Price: greater than zero
   /// - Description: required
   /// - Category: required
   /// - Image: valid URL for image
   /// </remarks>
   public UpdateProductRequestValidator()
   {
      RuleFor(product => product.Title).NotEmpty();
      RuleFor(product => product.Price).GreaterThan(0);
      RuleFor(product => product.Description).NotEmpty();
      RuleFor(product => product.Category).NotEmpty();
      RuleFor(product => product.Image).Matches(@"^https?:\/\/.+\.(png|jpe?g|gif|bmp|webp)$");
   }
}