using System.Text.RegularExpressions;

namespace Saykor.Providers
{
    static class Extensions
    {
        public static bool IsEmail(this string inputEmail)
        {
            Regex re = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$",
                          RegexOptions.IgnoreCase);
            return re.IsMatch(inputEmail);
        }
    }
}
