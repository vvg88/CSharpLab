namespace CSharpLab;

internal static class Extentions
{
    public static string AsString<T>(this IEnumerable<T> items) =>
        $"{{ {string.Join(", ", items)} }}";
}
