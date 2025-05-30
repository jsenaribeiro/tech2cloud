using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;

public class ActiveUserSpecification : ISpecification<User>
{
   public bool IsSatisfiedBy(User user) => user.Status == UserStatus.Active;
}
