namespace ValidationLibrary;
public static class StringExtensions
{
    /// <summary>
    /// Used for validating a class string property is valid via FluentValidation
    /// </summary>
    /// <param name="text">Text to validate</param>
    /// <returns>True if valid and false if invalid</returns>
    /// <remarks>
    /// What it considers if there are foreign characters in the string, allows spaces and numbers
    /// </remarks>
    public static bool IsOnlyAsciiLetters(this string text)
    {
        foreach (var item in text.Where(item => !char.IsNumber(item)))
        {
            switch (item)
            {
                case >= 'A' and <= 'Z':
                case >= 'a' and <= 'z':
                case ' ':
                case '.':
                case ',':
                case '/':
                case '\'':
                case '&':
                    continue;
                default:
                    return false;
            }
        }

        return true;
    }
}
