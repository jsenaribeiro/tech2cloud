namespace Ambev.DeveloperEvaluation.ORM.Repositories;

using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Common; // Add this if IRepository<,> or Entity<> are here

public class SaleRepository : Repository<Sale, int>, ISaleRepository
{
   public SaleRepository(IServiceProvider provider) : base(provider) { }
}

