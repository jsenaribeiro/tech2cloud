using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductsByCategory;

/// <summary>
/// Validator for GetProductsByCategoryRequest
/// </summary>
public class GetProductsByCategoryValidator : AbstractValidator<GetProductsByCategoryRequest>
{
   /// <summary>
   /// Initializes validation rules for GetProductsByCategoryRequest
   /// </summary>
   public GetProductsByCategoryValidator()
   {
   }
}
