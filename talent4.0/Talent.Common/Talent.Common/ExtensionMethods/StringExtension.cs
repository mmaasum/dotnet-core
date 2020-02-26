namespace Talent.Common.ExtensionMethods
{
    public static class StringExtension
    {
        public static string ReturnEmptyStringForNull(this string source)
        {
            return source == null ? "" : source;
        }
    }
}
