using Ambev.DeveloperEvaluation.Domain.Values;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts;

/// <summary>
/// Query for retrieving a product by filter
/// </summary>
public class GetProductsQuery : QueryFilter, IRequest<PageList<GetProductsResult>>
{
   /// <summary>
   ///  Initializes a new instance of GetProductCategoriesQuery
   /// </summary>
   public GetProductsQuery() { }

   /// <summary>
   ///  Initializes a new instance of GetProductsQuery
   /// </summary>
   /// <param name="filter">Filter object</param>
   public GetProductsQuery(QueryFilter filter)
   {
      this.Order = filter.Order;
      this.Page = filter.Page;
      this.Size = filter.Size;
   }
   
   /// <summary>
   ///  Initializes a new instance of GetProductsQuery
   /// </summary>
   /// <param name="filter">Filter object</param>
   public GetProductsQuery(int page)
   {
      this.Page = page;
   }

   /// <summary>
   ///  Initializes a new instance of GetProductsQuery
   /// </summary>
   /// <param name="page">Page number for pagination</param>
   /// <param name="size">Number of items per page</param>
   public GetProductsQuery(int page, int size)
   {
      this.Page = page;
      this.Size = size;
   }

   /// <summary>
   ///  Initializes a new instance of GetProductsQuery
   /// </summary>
   /// <param name="page">Page number for pagination</param>
   /// <param name="size">Number of items per page</param>
   /// <param name="order">Ordering of results (e.g., "price desc, title asc")</param>
   public GetProductsQuery(int page, int size, string order)
   {
      this.Page = page;
      this.Size = size;
      this.Order = order;
   }

   /// <summary>
   ///  Initializes a new instance of GetProductsQuery
   /// </summary>
   /// <param name="filter">Filter object</param>
   /// <param name="order">Ordering of results (e.g., "price desc, title asc")</param>
   public GetProductsQuery(string order)
   {
      this.Order = order;
   }
}
