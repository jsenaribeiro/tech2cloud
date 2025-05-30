using Ambev.DeveloperEvaluation.Domain.Values;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.GetUsers;

/// <summary>
/// Query for retrieving a user by filter
/// </summary>
public class GetUsersQuery : QueryFilter, IRequest<PageList<GetUsersResult>>
{
   /// <summary>
   ///  Initializes a new instance of GetUserCategoriesQuery
   /// </summary>
   public GetUsersQuery() { }

   /// <summary>
   ///  Initializes a new instance of GetUsersQuery
   /// </summary>
   /// <param name="filter">Filter object</param>
   public GetUsersQuery(QueryFilter filter)
   {
      this.Order = filter.Order;
      this.Page = filter.Page;
      this.Size = filter.Size;
   }
   
   /// <summary>
   ///  Initializes a new instance of GetUsersQuery
   /// </summary>
   /// <param name="filter">Filter object</param>
   public GetUsersQuery(int page)
   {
      this.Page = page;
   }

   /// <summary>
   ///  Initializes a new instance of GetUsersQuery
   /// </summary>
   /// <param name="page">Page number for pagination</param>
   /// <param name="size">Number of items per page</param>
   public GetUsersQuery(int page, int size)
   {
      this.Page = page;
      this.Size = size;
   }

   /// <summary>
   ///  Initializes a new instance of GetUsersQuery
   /// </summary>
   /// <param name="page">Page number for pagination</param>
   /// <param name="size">Number of items per page</param>
   /// <param name="order">Ordering of results (e.g., "price desc, title asc")</param>
   public GetUsersQuery(int page, int size, string order)
   {
      this.Page = page;
      this.Size = size;
      this.Order = order;
   }

   /// <summary>
   ///  Initializes a new instance of GetUsersQuery
   /// </summary>
   /// <param name="filter">Filter object</param>
   /// <param name="order">Ordering of results (e.g., "price desc, title asc")</param>
   public GetUsersQuery(string order)
   {
      this.Order = order;
   }
}
