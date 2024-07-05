using StringConverter.Exceptions;
using System.Text.RegularExpressions;

namespace StringConverter;

public static class Convert
{

    public static string RemoveExtraSpaces(this string input)
    {
        if (input == null || string.IsNullOrWhiteSpace(input))
            throw new EmptyStringException(nameof(input));

        var normalize = input.Replace("&nbsp;", " ");
        return Regex.Replace(normalize, @"\s+", " ").Trim();
    }
}