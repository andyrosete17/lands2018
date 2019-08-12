namespace Lands.Helpers
{
    using System;
    using System.Text.RegularExpressions;

    public static class RegexUtilities
    {
        public static bool IsValidEmail(string email)
        {
            var expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            var result = false;
            if (Regex.IsMatch(email, expresion))
            {
                result = Regex.Replace(email, expresion, String.Empty).Length == 0 ? true : false;
            }
            return result;
        }
    }
}