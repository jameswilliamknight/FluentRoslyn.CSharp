namespace FluentRoslyn.CSharp.Extensions;

public static class StringExtensions
{
    public static string ToCamelCase(this string @string) => @string[..1].ToLower() + @string[1..];
}