using Ambev.DeveloperEvaluation.Common.Pagination;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductsByCategory;

/// <summary>
/// Request model for retrieving a product categories by filter
/// </summary>
public class GetProductsByCategoryRequest : QueryFilter
{
   /// <summary>
   /// The unique identifier of the product to retrieve
   /// </summary>
   public string category { get; }

   /// <summary>
   /// Initializes a new instance of GetProductsByCategoryRequest
   /// </summary>
   /// <param name="category">The product category name</param>
   public GetProductsByCategoryRequest(string category, QueryFilter filter)
      : base(filter.Page, filter.Size, filter.Order)
   {
      this.category = category;
   }
}
