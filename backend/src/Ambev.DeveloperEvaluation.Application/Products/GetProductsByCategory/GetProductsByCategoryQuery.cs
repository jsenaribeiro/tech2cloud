using Ambev.DeveloperEvaluation.Domain.Values;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductsByCategory;

/// <summary>
/// Query for retrieving a product category by filter
/// </summary>
public class GetProductsByCategoryQuery : QueryFilter, IRequest<PageList<GetProductsByCategoryResult>>
{
   /// <summary>
   /// The unique identifier of the product to retrieve
   /// </summary>
   public string CategoryName { get; }

   /// <summary>
   /// Initializes a new instance of GetProductsByCategoryQuery
   /// </summary>
   /// <param name="category">The product category name</param>
   public GetProductsByCategoryQuery(string category)
   {
      this.CategoryName = category;
   }
}
