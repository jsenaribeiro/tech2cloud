using System.Linq.Expressions;
using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.Domain.Common;

/// <summary>
///  Shared repository interface
/// </summary>
/// <typeparam name="E">The entity type</typeparam>
/// <typeparam name="I">The identity type</typeparam>
public interface IRepository<E, I> : IReadRespository<E, I>, IWriteRepository<E, I>
   where E : Entity<I>
   where I : struct, IComparable
{

}