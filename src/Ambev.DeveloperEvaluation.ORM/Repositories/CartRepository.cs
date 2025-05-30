using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SharpCompress.Common;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ICartRepository using Entity Framework Core
/// </summary>
public class CartRepository : Repository<Cart, int>, ICartRepository
{
   /// <summary>
   /// Initializes a new instance of CartRepository
   /// </summary>
   /// <param name="context">The database context</param>
   public CartRepository(IServiceProvider provider) : base(provider) { }

   public override async Task<Cart?> GetAsync(int id, CancellationToken cancellationToken = default)
   {
      var cart = await this.collection.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

      if (cart is null) return null;

      var cartProducts = await this
         .GetCollection<CartProduct, int>()
         .ToListAsync(cp => cp.CartId == id);

      foreach (var item in cartProducts) cart.Append(item);

      return cart;
   }

   public override async Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default)
   {
      if (cart.Products is null || !cart.Products.Any())
         throw new InvalidOperationException("Cart must have at least one product.");

      using var transaction = await pgContext.Database.BeginTransactionAsync();

      try
      {
         pgContext.Entry(cart).State = EntityState.Added;

         await this.pgContext.Carts.AddAsync(cart);
         await pgContext.SaveChangesAsync();

         foreach (var item in cart.Products)
         {
            item.CartId = cart.Id;

            pgContext.Entry(item).State = EntityState.Added;
            await this.pgContext.CartProducts.AddAsync(item);
         }

         await pgContext.SaveChangesAsync();

         await mongoContext.GetCollection<Cart, int>()
            .InsertOneAsync(cart, options: null, cancellationToken);

         foreach (var item in cart.Products)
            await mongoContext.GetCollection<CartProduct, int>()
               .InsertOneAsync(item, options: null, cancellationToken);

         await transaction.CommitAsync();
      }
      catch (System.Exception)
      {
         await transaction.RollbackAsync();
         throw;
      }

      return cart;
   }

   public override async Task<Cart> UpdateAsync(Cart cart, CancellationToken cancellationToken = default)
   {
      if (cart.Products is null || !cart.Products.Any())
         throw new InvalidOperationException("Cart must have at least one product.");

      using var transaction = await pgContext.Database.BeginTransactionAsync();

      try
      {
         this.pgContext.Carts.Update(cart);
         await pgContext.SaveChangesAsync();

         foreach (var item in cart.Products)
            this.pgContext.CartProducts.Update(item);

         await pgContext.SaveChangesAsync();

         await mongoContext.GetCollection<Cart, int>()
            .InsertOneAsync(cart, options: null, cancellationToken);

         foreach (var item in cart.Products)
            await mongoContext.GetCollection<CartProduct, int>()
               .InsertOneAsync(item, options: null, cancellationToken);

         await transaction.CommitAsync();
      }
      catch (System.Exception)
      {
         await transaction.RollbackAsync();
         throw;
      }

      return cart;
   }
}
