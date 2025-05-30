using Ambev.DeveloperEvaluation.Domain;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository Users { get; }
        public ICartRepository Carts { get; }
        public IProductRepository Products { get; }
        public ISaleRepository Sales { get; }

        public UnitOfWork(IServiceProvider provider)
        {
            Users = new UserRepository(provider);
            Carts = new CartRepository(provider);
            Sales = new SaleRepository(provider);
            Products = new ProductRepository(provider);
        }
    }
}
