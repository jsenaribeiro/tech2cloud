using Ambev.DeveloperEvaluation.Domain.Values;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCarts;

/// <summary>
/// Query for retrieving a cart by filter
/// </summary>
public class GetCartsQuery : QueryFilter, IRequest<PageList<GetCartsResult>>
{
   /// <summary>
   ///  Initializes a new instance of GetCartCategoriesQuery
   /// </summary>
   public GetCartsQuery() { }

   /// <summary>
   ///  Initializes a new instance of GetCartsQuery
   /// </summary>
   /// <param name="filter">Filter object</param>
   public GetCartsQuery(QueryFilter filter)
   {
      this.Order = filter.Order;
      this.Page = filter.Page;
      this.Size = filter.Size;
   }
   
   /// <summary>
   ///  Initializes a new instance of GetCartsQuery
   /// </summary>
   /// <param name="filter">Filter object</param>
   public GetCartsQuery(int page)
   {
      this.Page = page;
   }

   /// <summary>
   ///  Initializes a new instance of GetCartsQuery
   /// </summary>
   /// <param name="page">Page number for pagination</param>
   /// <param name="size">Number of items per page</param>
   public GetCartsQuery(int page, int size)
   {
      this.Page = page;
      this.Size = size;
   }

   /// <summary>
   ///  Initializes a new instance of GetCartsQuery
   /// </summary>
   /// <param name="page">Page number for pagination</param>
   /// <param name="size">Number of items per page</param>
   /// <param name="order">Ordering of results (e.g., "price desc, title asc")</param>
   public GetCartsQuery(int page, int size, string order)
   {
      this.Page = page;
      this.Size = size;
      this.Order = order;
   }

   /// <summary>
   ///  Initializes a new instance of GetCartsQuery
   /// </summary>
   /// <param name="filter">Filter object</param>
   /// <param name="order">Ordering of results (e.g., "price desc, title asc")</param>
   public GetCartsQuery(string order)
   {
      this.Order = order;
   }
}
