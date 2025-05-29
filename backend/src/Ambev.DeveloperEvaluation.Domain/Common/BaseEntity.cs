using Ambev.DeveloperEvaluation.Common.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Common;

public abstract class BaseEntity<I> : IComparable<BaseEntity<I>> where I : struct, IComparable
{
   /// <summary>
   /// The unique identifier of the entity
   /// </summary>
   public I Id { get; set; }

   /// <summary>
   /// Gets the date and time creation.
   /// </summary>
   public DateTime CreatedAt { get; set; }

   /// <summary>
   /// Gets the date and time of the last update.
   /// </summary>
   public DateTime? UpdatedAt { get; set; }

   public Task<IEnumerable<ValidationErrorDetail>> ValidateAsync() =>
       Validator.ValidateAsync(this);

   public int CompareTo(BaseEntity<I>? other)
   {
      if (other == null) return 1;
      return Id.CompareTo(other.Id);
   }
}
