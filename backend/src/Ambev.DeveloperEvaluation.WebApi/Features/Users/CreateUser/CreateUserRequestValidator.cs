using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;

/// <summary>
/// Validator for CreateUserRequest that defines validation rules for user creation.
/// </summary>
public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
   /// <summary>
   /// Initializes a new instance of the CreateUserRequestValidator with defined validation rules.
   /// </summary>
   /// <remarks>
   /// Validation rules include:
   /// - Name: Must be in valid format (using NameValidator)
   /// - Address: Must be in valid format (using AddressValidator)
   /// - Email: Must be in valid format (using EmailValidator)
   /// - Username: Required, must be between 3 and 50 characters
   /// - Password: Must meet security requirements (using PasswordValidator)
   /// - Phone: Must match international format (+X XXXXXXXXXX)
   /// - Status: Cannot be set to Unknown
   /// - Role: Cannot be set to None
   /// </remarks>
   public CreateUserRequestValidator()
   {
      RuleFor(user => user.Name).SetValidator(new NameValidator());
      RuleFor(user => user.Address).SetValidator(new AddressValidator());
      RuleFor(user => user.Email).SetValidator(new EmailValidator());
      RuleFor(user => user.Username).NotEmpty().Length(3, 50);
      RuleFor(user => user.Password).SetValidator(new PasswordValidator());
      RuleFor(user => user.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
      RuleFor(user => user.Status).Must(x => ValidateEnum<UserStatus>(x))
          .WithMessage("Invalid user status. Valid values are: Active, Inactive, Suspended.");
      RuleFor(user => user.Role).Must(x => ValidateEnum<UserRole>(x))
          .WithMessage("Invalid user role. Valid values are: Admin, User, Customer.");
   }

   private bool ValidateEnum<TEnum>(string value) where TEnum : struct, Enum
   {
      if (string.IsNullOrWhiteSpace(value) && value.Length < 2) return false;
      var capitalized = value[0].ToString().ToUpper() + value.Substring(1).ToLower();
      return Enum.TryParse<TEnum>(capitalized, true, out _);
   }
}