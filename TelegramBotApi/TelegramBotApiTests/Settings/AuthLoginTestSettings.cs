using TelegramBotApiTests.Models;

namespace TelegramBotApiTests.Settings;

public class AuthLoginTestSettings
{
    public const string AuthLoginSettings = nameof(AuthLoginSettings);

    public LoginModel ValidLoginData { get; set; }

    public LoginModel InvalidLoginData { get; set; }
}