using AngleSharp.Html.Parser;
using Logic.Services.Interfaces;

namespace Logic.Services;

public class UrfuHtmlParserService : IUrfuHtmlParserService
{
    private readonly HtmlParser htmlParser;

    public UrfuHtmlParserService(HtmlParser htmlParser)
    {
        this.htmlParser = htmlParser;
    }

    public async Task<object> ParseUserInfoHtml(string userInfoHtml)
    {
        var document = htmlParser.ParseDocument(userInfoHtml);

        var data = document
            .QuerySelectorAll("div.myself")
            .FirstOrDefault()
            ?.TextContent
            .Split('\n', '\t')
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .ToArray();

        var fio = data[0].Split();
        var academicGroup = data[4];
        var email = data.LastOrDefault().Split(':')[1].Trim();

        return null;
    }
}