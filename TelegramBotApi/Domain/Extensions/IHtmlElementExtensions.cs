using AngleSharp.Dom;

namespace Logic.Extensions;

public static class HtmlElementExtensions
{
    public static IEnumerable<string> GetClearElementData(this IElement element) =>
        element.InnerHtml
            .Split('\n', '\t')
            .Where(s => !string.IsNullOrWhiteSpace(s));
}