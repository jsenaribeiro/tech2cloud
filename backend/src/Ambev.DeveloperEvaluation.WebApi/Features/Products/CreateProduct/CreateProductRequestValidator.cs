using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductRequest that defines validation rules for product creation.
/// </summary>
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
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
   /// - Image: valid url for image
   /// </remarks>
   public CreateProductRequestValidator()
   {
      RuleFor(product => product.Title).NotEmpty();
      RuleFor(product => product.Price).GreaterThan(0);
      RuleFor(product => product.Description).NotEmpty();
      RuleFor(product => product.Category).NotEmpty();
      RuleFor(product => product.Image).Matches(@"^https?:\/\/.+\.(png|jpe?g|gif|bmp|webp)$");
   }
}