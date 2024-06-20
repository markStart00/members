namespace members.Application.Extensions
{
    public static class StringExtensions
    {
        public static string? NormalizeToLowerCase(this string? value)
        {
            return value?.ToLower();
        }

    }
}
