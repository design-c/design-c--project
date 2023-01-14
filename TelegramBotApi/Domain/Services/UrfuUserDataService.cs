using System.Globalization;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Logic.Extensions;
using Logic.Models;
using Logic.Services.Interfaces;
using Logic.Settings;
using Microsoft.Extensions.Options;

namespace Logic.Services;

public class UrfuUserDataService : IUrfuUserDataService
{
    private readonly UrfuUserDataSettings urfuUserDataSettings;

    private readonly IAuthService authService;

    private readonly HttpClient httpClient;

    private readonly HtmlParser htmlParser;

    public UrfuUserDataService(
        IOptions<UrfuUserDataSettings> urfuUserDataOptions,
        IAuthService authService,
        HttpClient httpClient,
        HtmlParser htmlParser
    )
    {
        urfuUserDataSettings = urfuUserDataOptions.Value;
        this.authService = authService;
        this.httpClient = httpClient;
        this.htmlParser = htmlParser;
    }

    public async Task<UserInfo> GetUserInfo(string userKey)
    {
        await authService.LoginByUserId(userKey);

        var document = await GetDocumentByUri(urfuUserDataSettings.UserInfoUri);
        const string userInfoClassName = "div.myself";

        var data = document.QuerySelector(userInfoClassName)!
            .GetClearElementData()
            .ToArray();

        var name = data[0];
        var studentCardNumber = data[2];
        var group = data[4];
        var email = data.LastOrDefault()?.Split(':')[1].Trim() ?? "email отсутствует";

        return new UserInfo(name, group, studentCardNumber, email);
    }

    public async Task<IEnumerable<UserMark>> GetUserMarks(string userKey)
    {
        await authService.LoginByUserId(userKey);

        var document = await GetDocumentByUri(urfuUserDataSettings.UserMarksUri);
        const string userMarksBlockClass = "div.table-study-in-subject table tbody tr";
        const string nameClass = "td.td-0";
        const string pointClass = "td.td-1";
        const string markClass = "td.td-2";

        return document.QuerySelectorAll(userMarksBlockClass)
            .Select(x =>
            {
                var name = x.QuerySelector(nameClass)!.GetClearElementData().First();
                var point = x.QuerySelector(pointClass)!.GetClearElementData().First();
                var mark = x.QuerySelector(markClass)!.GetClearElementData().First();

                return new UserMark(name, double.Parse(point, CultureInfo.InvariantCulture), mark);
            });
    }

    private async Task<IHtmlDocument> GetDocumentByUri(string uri)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        var httpResponseMessage = await httpClient.SendAsync(requestMessage).ConfigureAwait(false);
        var htmlWithUserDataAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

        return htmlParser.ParseDocument(htmlWithUserDataAsString);
    }
}