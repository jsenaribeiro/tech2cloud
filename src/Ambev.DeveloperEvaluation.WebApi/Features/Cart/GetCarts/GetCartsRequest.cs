using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCarts;

/// <summary>
/// Request model for list of all carts with optional query filters
/// </summary>
public class GetCartsRequest : QueryFilter
{
   /// <summary>
   /// Initializer for GetCartsRequest
   /// </summary>
   public GetCartsRequest() { }


   /// <summary>
   /// Initializer for GetCartsRequest
   /// </summary>
   public GetCartsRequest(QueryFilter filter)
   {
      this.Order = filter.Order;
      this.Page = filter.Page;
      this.Size = filter.Size;
   }
}
