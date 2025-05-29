using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser;

/// <summary>
/// Represents the response returned after successfully creating a new user.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly updated user,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class UpdateUserResult
{
   /// <summary>
   /// Gets or sets the unique identifier of the newly updated user.
   /// </summary>
   /// <value>A GUID that uniquely identifies the updated user in the system.</value>
   public int Id { get; set; }

   /// <summary>
   /// Gets or sets the username of the user to be updated.
   /// </summary>
   public string Username { get; set; } = string.Empty;

   /// <summary>
   /// Gets or sets the password for the user.
   /// </summary>
   public string Password { get; set; } = string.Empty;

   /// <summary>
   /// Gets or sets the phone number for the user.
   /// </summary>
   public string Phone { get; set; } = string.Empty;

   /// <summary>
   /// Gets or sets the email address for the user.
   /// </summary>
   public string Email { get; set; } = string.Empty;

   /// <summary>
   /// Gets or sets the status of the user.
   /// </summary>
   public UserStatus Status { get; set; }

   /// <summary>
   /// Gets or sets the role of the user.
   /// </summary>
   public UserRole Role { get; set; }

   /// <summary>
   /// First and last names of the user.
   /// </summary>
   public Name? Name { get; set; }

   /// <summary>
   /// Address details of the user.
   /// </summary>
   public Address? Address { get; set; }
}
