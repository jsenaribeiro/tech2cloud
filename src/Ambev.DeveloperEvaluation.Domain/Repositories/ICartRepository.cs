namespace Ambev.DeveloperEvaluation.Domain.Repositories;

using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

public interface ICartRepository : IRepository<Cart, int>
{
   Task<Cart?> GetAsync(int id, CancellationToken cancellationToken = default);
}