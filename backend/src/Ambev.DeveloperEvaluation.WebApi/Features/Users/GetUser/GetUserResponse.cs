using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;

/// <summary>
/// API response model for GetUser operation
/// </summary>
public class GetUserResponse
{
   /// <summary>
   /// The unique identifier of the user
   /// </summary>
   public int Id { get; set; }

   /// <summary>
   /// Gets or sets the username of the user to be created.
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
   public string Status { get; set; } = string.Empty;

   /// <summary>
   /// Gets or sets the role of the user.
   /// </summary>
   public string Role { get; set; } = string.Empty;

   /// <summary>
   /// First and last names of the user.
   /// </summary>
   public Name? Name { get; set; }

   /// <summary>
   /// Address details of the user.
   /// </summary>
   public Address? Address { get; set; }
}
