using System.Net;
using Dal.Contracts.Interfaces;
using Dal.Contracts.Models;
using FluentAssertions;
using Logic.Services;
using Logic.Settings;
using TelegramBotApiTests.Models;
using TelegramBotApiTests.Utils;

namespace TelegramBotApiTests.Tests;

public class AuthServiceTests
{
    private readonly AuthLoginTestSettings authLoginTestSettings;

    private readonly AuthJwtSettings authJwtTestSettings;

    private readonly AuthUrfuSettings authUrfuTestSettings;

    private AuthService authService;

    private const string UserKey = nameof(UserKey);

    private const string InvalidUserKey = nameof(InvalidUserKey);

    public AuthServiceTests()
    {
        authLoginTestSettings = SettingsReader.GetAuthLoginSettings();
        authJwtTestSettings = SettingsReader.GetAuthJwtSettings();
        authUrfuTestSettings = SettingsReader.GetAuthUrfuSettings();
    }

    [SetUp]
    public void Init()
    {
        authService = GetAuthService(new UserTestRepository());
    }

    [Test]
    public async Task IsPasswordAndLoginCorrect_ShouldWorkCorrectWithValidData()
    {
        var validData = authLoginTestSettings.ValidLoginData;

        var result = await authService.IsPasswordAndLoginCorrect(validData.Login, validData.Password);

        result.Should().BeTrue();
    }

    [Test]
    public async Task IsPasswordAndLoginCorrect_ShouldWorkCorrectWithInvalidData()
    {
        var invalidData = authLoginTestSettings.InvalidLoginData;

        var result = await authService.IsPasswordAndLoginCorrect(invalidData.Login, invalidData.Password);

        result.Should().BeFalse();
    }

    [Test]
    public async Task Login_ShouldWorkCorrectWithValidData()
    {
        var validData = authLoginTestSettings.ValidLoginData;

        var result = await authService.Login(validData.Login, validData.Password, UserKey);

        result.Should().NotBeNull();
    }

    [Test]
    public async Task Login_ShouldThrowErrorWithInvalidData()
    {
        var invalidData = authLoginTestSettings.InvalidLoginData;

        var resultTask = async () => await authService.Login(invalidData.Login, invalidData.Password, UserKey);

        await resultTask.Should().ThrowAsync<Exception>();
    }

    [Test]
    public async Task LoginByUserId_ShouldNotThrowErrorWithValidData()
    {
        var validData = authLoginTestSettings.ValidLoginData;
        var userRepository = await CreateTestRepositoryWithUser(validData, UserKey);

        authService = GetAuthService(userRepository);
        var resultTask = async () => await authService.LoginByUserId(UserKey);

        await resultTask.Should().NotThrowAsync<Exception>();
    }

    [Test]
    public async Task LoginByUserId_ShouldThrowErrorWithInvalidUserKey()
    {
        var validData = authLoginTestSettings.ValidLoginData;
        var userRepository = await CreateTestRepositoryWithUser(validData, UserKey);

        authService = GetAuthService(userRepository);
        var resultTask = async () => await authService.LoginByUserId(InvalidUserKey);

        await resultTask.Should().ThrowAsync<Exception>();
    }

    [Test]
    public async Task LoginByUserId_ShouldThrowErrorWithInvalidLoginData()
    {
        var invalidData = authLoginTestSettings.InvalidLoginData;
        var userRepository = await CreateTestRepositoryWithUser(invalidData, UserKey);

        authService = GetAuthService(userRepository);
        var resultTask = async () => await authService.LoginByUserId(UserKey);

        await resultTask.Should().ThrowAsync<Exception>();
    }

    [Test]
    public async Task Logout_ShouldDeleteUserWithValidKey()
    {
        var validData = authLoginTestSettings.ValidLoginData;
        var userRepository = await CreateTestRepositoryWithUser(validData, UserKey);

        authService = GetAuthService(userRepository);
        await authService.Logout(UserKey);
        var result = await userRepository.GetUserByKey(UserKey);

        result?.Should().BeNull();
    }

    [Test]
    public async Task Logout_ShouldThrowWithInvalidUserKey()
    {
        var validData = authLoginTestSettings.ValidLoginData;
        var userRepository = await CreateTestRepositoryWithUser(validData, UserKey);

        authService = GetAuthService(userRepository);
        var resultTask = async () => await authService.Logout(InvalidUserKey);

        await resultTask.Should().ThrowAsync<Exception>();
    }

    private async Task<IUserRepository> CreateTestRepositoryWithUser(LoginModel loginModel, string key)
    {
        var user = new UserModel { Login = loginModel.Login, Password = loginModel.Password, UserKey = key };
        var userRepository = new UserTestRepository();

        await userRepository.CreateAsync(user);

        return userRepository;
    }

    private AuthService GetAuthService(IUserRepository userTestRepository)
    {
        var clientHandler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (_, _, _, _) => true,
            UseDefaultCredentials = true,
            UseCookies = false,
            UseProxy = false,
            Credentials = new NetworkCredential()
        };
        
        return new AuthService(
            new AuthJwtTestOptions(authJwtTestSettings),
            new AuthUrfuTestOptions(authUrfuTestSettings),
            userTestRepository,
            new HttpClient(clientHandler)
        );
    }
}