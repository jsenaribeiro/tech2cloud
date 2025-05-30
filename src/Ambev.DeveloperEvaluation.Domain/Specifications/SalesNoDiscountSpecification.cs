using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;


/// <summary>
/// No discount for less than 4 items
/// </summary>
public class SalesNoDiscountSpecification : ISpecification<CartProduct>
{
   public bool IsSatisfiedBy(CartProduct item) => item.Quantity < 4;
}
