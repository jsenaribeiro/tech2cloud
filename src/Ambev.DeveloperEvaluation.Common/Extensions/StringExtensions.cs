public static class StringExtensions
{
   public static TEnum For<TEnum>(this string value) where TEnum : struct, Enum
   {
      if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
         throw new ArgumentException($"Invalid enum value: {value}");

      var capitalized = char.ToUpper(value[0]) + value.Substring(1).ToLower();
      if (Enum.TryParse<TEnum>(capitalized, true, out var result))
         return result;

      throw new ArgumentException($"Invalid enum value: {value}");
   }
}