namespace TelegramBotApiTests.Models;

public class AuthLoginTestSettings
{
    public const string AuthLoginSettings = nameof(AuthLoginSettings);

    public LoginModel ValidLoginData { get; set; }

    public LoginModel InvalidLoginData { get; set; }
}