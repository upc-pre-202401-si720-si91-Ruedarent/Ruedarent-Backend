using System.Text.RegularExpressions;
namespace RuedarentApi.Shared.Infraestructure.Interfaces.ASP.Configuratin.Extensions;

public static partial class StringExtentions
{
    public static string ToKebabCase(this string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }

        return KebabCaseRegex().Replace(text, "-$1").Trim().ToLower();
    }

    [GeneratedRegex("(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", RegexOptions.Compiled)]

    private static partial Regex KebabCaseRegex();
}