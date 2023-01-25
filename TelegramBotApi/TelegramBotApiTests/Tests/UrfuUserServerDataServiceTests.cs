using AngleSharp.Html.Parser;
using Dal.Contracts.Models;
using FluentAssertions;
using Logic.Services;
using Logic.Settings;
using TelegramBotApiTests.Models;
using TelegramBotApiTests.Utils;

namespace TelegramBotApiTests.Tests;

public class UrfuUserServerDataServiceTests
{
    private readonly AuthLoginTestSettings authLoginTestSettings;

    private readonly AuthJwtSettings authJwtTestSettings;

    private readonly AuthUrfuSettings authUrfuTestSettings;

    private readonly UrfuUserDataSettings urfuUserDataSettings;

    private const string UserKey = nameof(UserKey);

    private const string InvalidUserKey = nameof(InvalidUserKey);

    public UrfuUserServerDataServiceTests()
    {
        authLoginTestSettings = SettingsReader.GetAuthLoginSettings();
        authJwtTestSettings = SettingsReader.GetAuthJwtSettings();
        authUrfuTestSettings = SettingsReader.GetAuthUrfuSettings();
        urfuUserDataSettings = SettingsReader.GetUrfuUserDataSettings();
    }

    [Test]
    public async Task GetUserInfo_ShouldNotBeNullWithValidUserKey()
    {
        var urfuUserServerDataService = await GetUrfuUserDataService();

        var userInfo = await urfuUserServerDataService.GetUserInfo(UserKey);

        userInfo.Should().NotBeNull();
    }

    [Test]
    public async Task GetUserInfo_ShouldThrowErrorWithInvalidUserKey()
    {
        var urfuUserServerDataService = await GetUrfuUserDataService();

        var resultTask = async () => await urfuUserServerDataService.GetUserInfo(InvalidUserKey);

        await resultTask.Should().ThrowAsync<Exception>();
    }
    
    [Test]
    public async Task GetUserMarks_ShouldNotBeNullWithValidUserKey()
    {
        var urfuUserServerDataService = await GetUrfuUserDataService();

        var userMarks = await urfuUserServerDataService.GetUserMarks(UserKey);

        userMarks.Should().NotBeNull();
    }
    
    [Test]
    public async Task GetUserMarks_ShouldThrowErrorWithInvalidUserKey()
    {
        var urfuUserServerDataService = await GetUrfuUserDataService();

        var resultTask = async () => await urfuUserServerDataService.GetUserMarks(InvalidUserKey);

        await resultTask.Should().ThrowAsync<Exception>();
    }

    private async Task<UrfuUserServerDataService> GetUrfuUserDataService()
    {
        var userTestRepository = new UserTestRepository();
        await userTestRepository.CreateAsync(new UserModel
        {
            Login = authLoginTestSettings.ValidLoginData.Login,
            Password = authLoginTestSettings.ValidLoginData.Password,
            UserKey = UserKey
        });
        var clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) => true;
        var httpClient = new HttpClient(clientHandler);
        var authService = new AuthService(
            new AuthJwtTestOptions(authJwtTestSettings),
            new AuthUrfuTestOptions(authUrfuTestSettings),
            userTestRepository,
            httpClient
        );

        return new UrfuUserServerDataService(
            new UrfuUserDataTestOptions(urfuUserDataSettings),
            authService,
            httpClient,
            new HtmlParser()
        );
    }
}