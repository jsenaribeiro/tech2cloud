using System.Diagnostics;
using Ambev.DeveloperEvaluation.Domain.Values;
using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUsers;

/// <summary>
/// Request model for list of all users with optional query filters
/// </summary>
public class GetUsersRequest : QueryFilter
{
   /// <summary>
   /// Initializer for GetUsersRequest
   /// </summary>
   public GetUsersRequest() { }


   /// <summary>
   /// Initializer for GetUsersRequest
   /// </summary>
   public GetUsersRequest(QueryFilter filter)
   {
      this.Order = filter.Order;
      this.Page = filter.Page;
      this.Size = filter.Size;
   }
}
