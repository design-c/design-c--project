using AngleSharp.Dom;

namespace Logic.Extensions;

public static class HtmlElementExtensions
{
    public static IEnumerable<string> GetClearHtmlElementData(this IElement element)
        => GetClearContentData(element.InnerHtml);

    public static IEnumerable<string> GetClearContentElementData(this IElement element) 
        => GetClearContentData(element.TextContent);

    private static IEnumerable<string> GetClearContentData(string text) 
        => text
            .Split('\n', '\t')
            .Where(s => !string.IsNullOrWhiteSpace(s));
}