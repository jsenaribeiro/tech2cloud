using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;

/// <summary>
/// 10% discount for 4-9 identical items
/// </summary>
public class SalesTenPercentDiscountSpecification : ISpecification<CartProduct>
{
    public bool IsSatisfiedBy(CartProduct item) => item.Quantity >= 4 && item.Quantity < 10;
}
