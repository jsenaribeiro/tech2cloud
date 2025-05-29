using System.Diagnostics;
using Ambev.DeveloperEvaluation.Common.Pagination;
using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;

/// <summary>
/// Request model for list of all products with optional query filters
/// </summary>
public class GetProductsRequest : QueryFilter
{
   /// <summary>
   /// Initializer for GetProductsRequest
   /// </summary>
   public GetProductsRequest() { }


   /// <summary>
   /// Initializer for GetProductsRequest
   /// </summary>
   public GetProductsRequest(QueryFilter filter)
   {
      this.Order = filter.Order;
      this.Page = filter.Page;
      this.Size = filter.Size;
   }
}
