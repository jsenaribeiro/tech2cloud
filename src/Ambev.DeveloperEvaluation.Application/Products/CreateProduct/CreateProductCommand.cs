using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Values;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Command for creating a new product.
/// </summary>
public class CreateProductCommand : IRequest<CreateProductResult>, IValidate
{
   /// <summary>
   /// Title or name of the product.
   /// </summary>
   public string Title { get; set; } = string.Empty;

   /// <summary>
   /// Price of the product.
   /// </summary>
   public decimal Price { get; set; }

   /// <summary>
   /// Detailed description of the product.
   /// </summary>
   public string Description { get; set; } = string.Empty;

   /// <summary>
   /// Category to which the product belongs.
   /// </summary>
   public string Category { get; set; } = string.Empty;

   /// <summary>
   /// URL of the product's image.
   /// </summary>
   public string Image { get; set; } = string.Empty;

   /// <summary>
   /// Rating information for the product.
   /// </summary>
   public Rating? Rating { get; set; }

   public ValidationResultDetail Validate()
   {
      var validator = new CreateProductCommandValidator();
      var result = validator.Validate(this);
      return new ValidationResultDetail
      {
         IsValid = result.IsValid,
         Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
      };
   }
}