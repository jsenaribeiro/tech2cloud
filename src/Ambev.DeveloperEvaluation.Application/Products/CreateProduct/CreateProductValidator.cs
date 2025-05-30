using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductCommand that defines validation rules for product creation command.
/// </summary>
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
   /// <summary>
   /// Initializes a new instance of the CreateProductCommandValidator with defined validation rules.
   /// </summary>
   /// <remarks>
   /// Validation rules include:
   /// - Title: required
   /// - Price: greater than zero
   /// - Description: required
   /// - Category: required
   /// - Image: valid URL for image
   /// </remarks>
   public CreateProductCommandValidator()
   {
      RuleFor(product => product.Title).NotEmpty();
      RuleFor(product => product.Price).GreaterThan(0);
      RuleFor(product => product.Description).NotEmpty();
      RuleFor(product => product.Category).NotEmpty();
      RuleFor(product => product.Image).Matches(@"^https?:\/\/.+\.(png|jpe?g|gif|bmp|webp)$");
   }
}