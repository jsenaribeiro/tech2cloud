using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

/// <summary>
/// Validator for UpdateProductCommand that defines validation rules for product update command.
/// </summary>
public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
   /// <summary>
   /// Initializes a new instance of the UpdateProductCommandValidator with defined validation rules.
   /// </summary>
   /// <remarks>
   /// Validation rules include:
   /// - Id: required
   /// - Title: required
   /// - Price: greater than zero
   /// - Description: required
   /// - Category: required
   /// - Image: valid URL for image
   /// </remarks>
   public UpdateProductCommandValidator()
   {
      RuleFor(product => product.Id).NotEmpty();
      RuleFor(product => product.Title).NotEmpty();
      RuleFor(product => product.Price).GreaterThan(0);
      RuleFor(product => product.Description).NotEmpty();
      RuleFor(product => product.Category).NotEmpty();
      RuleFor(product => product.Image).Matches(@"^https?:\/\/.+\.(png|jpe?g|gif|bmp|webp)$");
   }
}