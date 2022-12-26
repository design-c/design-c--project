using AngleSharp.Html.Parser;
using Logic.Services.Interfaces;
using Logic.Settings;
using Microsoft.Extensions.Options;

namespace Logic.Services;

public class UserUrfuService : IUserUrfuService
{
    private readonly HttpClient httpClient;
    private readonly HtmlParser htmlParser;
    private readonly UserUrfuSettings userUrfuSettings;

    public UserUrfuService(
        HttpClient httpClient,
        HtmlParser htmlParser,
        IOptions<UserUrfuSettings> userUrfuSettings
    )
    {
        this.httpClient = httpClient;
        this.htmlParser = htmlParser;
        this.userUrfuSettings = userUrfuSettings.Value;
    }

    public async Task GetUserInfo()
    {
        throw new NotImplementedException();
    }

    public async Task GetUserSchedule()
    {
        throw new NotImplementedException();
    }
}