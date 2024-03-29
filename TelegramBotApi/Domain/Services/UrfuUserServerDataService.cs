﻿using System.Globalization;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Logic.Extensions;
using Logic.Models;
using Logic.Services.Interfaces;
using Logic.Settings;
using Microsoft.Extensions.Options;

namespace Logic.Services;

public class UrfuUserServerDataService : IUrfuUserServerDataService
{
    private readonly UrfuUserDataSettings urfuUserDataSettings;

    private readonly IAuthService authService;

    private readonly HttpClient httpClient;

    private readonly HtmlParser htmlParser;

    public UrfuUserServerDataService(
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
        const string userInfoClassName = "div.student-data";

        var data = document.QuerySelector(userInfoClassName)!
            .GetClearContentElementData()
            .ToArray();

        var name = data[0];
        var studentCardNumber = data[1].Split(':')[1].Trim();
        var group = data[3];
        var email = data[4].Split(':')[1].Trim();

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
                var name = x.QuerySelector(nameClass)!.GetClearHtmlElementData().First();
                var point = x.QuerySelector(pointClass)!.GetClearHtmlElementData().First();
                var mark = x.QuerySelector(markClass)!.GetClearHtmlElementData().First();

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