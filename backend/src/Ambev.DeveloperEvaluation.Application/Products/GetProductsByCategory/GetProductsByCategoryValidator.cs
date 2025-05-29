using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductsByCategory;

/// <summary>
/// Validator for GetProductsByCategoryQuery
/// </summary>
public class GetProductsByCategoryValidator : AbstractValidator<GetProductsByCategoryQuery>
{
   /// <summary>
   /// Initializes validation rules for GetProductsByCategoryQuery
   /// </summary>
   public GetProductsByCategoryValidator()
   {
   }
}
