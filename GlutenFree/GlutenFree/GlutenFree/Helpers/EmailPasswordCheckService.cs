using System.Linq;
using System.Text.RegularExpressions;

namespace GlutenFree.Helpers
{
    public static class EmailPasswordCheckService
    {
        public static string SanitizeEmail(string email)
        {
            return Regex.Replace(email.ToLower(), @"\s+", "");
        }

        public static bool CheckPassword(string password)
        {
            if ((password.Contains("?") || password.Contains("!") || password.Contains("&") ||
                password.Contains("$") || password.Contains("=") || password.Contains("_") ||
                password.Contains("^") || password.Contains("@") || password.Contains("%") ||
                password.Contains("'") || password.Contains("(") || password.Contains(")") ||
                password.Contains("*") || password.Contains("+") || password.Contains(",") ||
                password.Contains(".") || password.Contains("/") || password.Contains(":") ||
                password.Contains(";") || password.Contains("<") || password.Contains(">") ||
                password.Contains("[") || password.Contains("]")) && password.Any(char.IsDigit)
                && password.Any(char.IsUpper) ) 
            {
                return true;
            }
            return false;
        }

    }
}
