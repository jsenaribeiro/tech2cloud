using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Values;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;

/// <summary>
/// Represents a request to create a new user in the system.
/// </summary>
public class CreateUserRequest
{
   /// <summary>
   /// The username of the user.
   /// </summary>
   public string Username { get; set; } = string.Empty;

   /// <summary>
   /// The password for the user.
   /// </summary>
   public string Password { get; set; } = string.Empty;

   /// <summary>
   /// The phone number for the user.
   /// </summary>
   public string Phone { get; set; } = string.Empty;

   /// <summary>
   /// The email address for the user.
   /// </summary>
   public string Email { get; set; } = string.Empty;

   /// <summary>
   /// The status of the user.
   /// </summary>
   public string Status { get; set; } = "";

   /// <summary>
   /// The role of the user.
   /// </summary>
   public string Role { get; set; } = "";

   /// <summary>
   /// First and last names of the user.
   /// </summary>
   public Name Name { get; set; } = null!;

   /// <summary>
   /// Address details of the user.
   /// </summary>
   public Address Address { get; set; } = null!;
}