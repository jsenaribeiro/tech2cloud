using Ambev.DeveloperEvaluation.Common.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Common;

public abstract class BaseEntity : IComparable<BaseEntity>
{
    public Guid Id { get; set; }

   /// <summary>
   /// Gets the date and time creation.
   /// </summary>
   public DateTime CreatedAt { get; set; }

   /// <summary>
   /// Gets the date and time of the last update.
   /// </summary>
   public DateTime? UpdatedAt { get; set; }

   public Task<IEnumerable<ValidationErrorDetail>> ValidateAsync()
   {
      return Validator.ValidateAsync(this);
   }

    public int CompareTo(BaseEntity? other)
    {
        if (other == null)
        {
            return 1;
        }

        return other!.Id.CompareTo(Id);
    }
}
