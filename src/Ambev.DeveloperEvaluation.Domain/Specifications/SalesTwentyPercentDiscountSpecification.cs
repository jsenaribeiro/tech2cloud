using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;

/// <summary>
/// 20% discount for 10-20 identical items
/// </summary>
public class SalesTwentyPercentDiscountSpecification : ISpecification<CartProduct>
{
    public bool IsSatisfiedBy(CartProduct item) => item.Quantity >= 10 && item.Quantity <= 20;
}
