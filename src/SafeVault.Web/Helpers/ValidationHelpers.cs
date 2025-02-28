using System.Linq;
using System.Collections.Generic;

namespace SafeVault.Web.Helpers
{
    public static class ValidationHelpers
    {
        // Validates that input is not null or empty and contains only letters, digits, or allowed special characters
        public static bool IsValidInput(string input, string allowedSpecialCharacters = "")
        {
            if (string.IsNullOrEmpty(input))
                return false;

            var validSpecialChars = new HashSet<char>(allowedSpecialCharacters);
            return input.All(c => char.IsLetterOrDigit(c) || validSpecialChars.Contains(c));
        }
    }
}
