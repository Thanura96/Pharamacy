using System;
using System.Text.RegularExpressions;

namespace PharmacySystem.Utilities
{
    public static class ValidationHelper
    {
        public static bool IsEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsDecimal(string value, out decimal result)
        {
            return decimal.TryParse(value, out result) && result >= 0;
        }

        public static bool IsInt(string value, out int result)
        {
            return int.TryParse(value, out result) && result >= 0;
        }

        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            // Matches formats like 555-1234, +1234567890, 1234567890
            return Regex.IsMatch(phone, @"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$");
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }
    }
}
