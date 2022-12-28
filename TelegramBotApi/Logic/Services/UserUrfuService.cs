using Logic.Extensions;
using Logic.Services.Interfaces;
using Logic.Settings;
using Microsoft.Extensions.Options;

namespace Logic.Services;

public class UserUrfuService : IUserUrfuService
{
    private readonly HttpClient httpClient;
    private readonly IUrfuHtmlParserService urfuHtmlParserService;
    private readonly UserUrfuSettings userUrfuSettings;

    public UserUrfuService(
        HttpClient httpClient,
        IUrfuHtmlParserService urfuHtmlParserService,
        IOptions<UserUrfuSettings> userUrfuSettings
    )
    {
        this.httpClient = httpClient;
        this.urfuHtmlParserService = urfuHtmlParserService;
        this.userUrfuSettings = userUrfuSettings.Value;
    }

    public async Task<object> GetUserInfo()
    {
        var userInfoHtmlString = await GetHtmlStringByUri(userUrfuSettings.UserInfoUri);
        var userInfo = await urfuHtmlParserService.ParseUserInfoHtml(userInfoHtmlString);

        return userInfo;
    }

    public async Task<object> GetUserSchedule()
    {
        var userScheduleHtmlString = await GetHtmlStringByUri(userUrfuSettings.UserScheduleUri);

        return null;
    }

    private async Task<string> GetHtmlStringByUri(string uri)
    {
        var request = uri.GenerateHttpRequestMessage(HttpMethod.Get);
        var httpResponseMessage = await httpClient.SendAsync(request).ConfigureAwait(false);

        return await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
    }
}