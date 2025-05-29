namespace Ambev.DeveloperEvaluation.Domain.Values;

public class Name
{
   /// <summary>
   /// First name.
   /// </summary>
   public string FirstName { get; set; } = string.Empty;

   /// <summary>
   /// Last name.
   /// </summary>
   public string LastName { get; set; } = string.Empty;

   /// <summary>
   /// Full name by concatenating first and last names.
   /// </summary>
   public string FullName => $"{FirstName} {LastName}";
}