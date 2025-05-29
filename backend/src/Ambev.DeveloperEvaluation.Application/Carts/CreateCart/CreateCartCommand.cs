using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Command for creating a new cart.
/// </summary>
public class CreateCartCommand : IRequest<CreateCartResult>, IValidate
{
   /// <summary>
   /// The unique identifier of the user who owns the cart
   /// </summary>
   public int UserId { get; set; }

   /// <summary>
   /// The date when the cart was created or last updated
   /// </summary>
   public DateTime Date { get; set; }

   /// <summary>
   /// The list of products in the cart
   /// </summary>
   public List<CartProduct> Products { get; set; } = new();

   public ValidationResultDetail Validate()
   {
      var validator = new CreateCartCommandValidator();
      var result = validator.Validate(this);
      return new ValidationResultDetail
      {
         IsValid = result.IsValid,
         Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
      };
   }
}

