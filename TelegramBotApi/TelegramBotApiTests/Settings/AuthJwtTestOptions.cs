using Logic.Settings;
using Microsoft.Extensions.Options;

namespace TelegramBotApiTests.Settings;

public class AuthJwtTestOptions : IOptions<AuthJwtSettings>
{
    public AuthJwtSettings Value { get; }

    public AuthJwtTestOptions(AuthJwtSettings value)
    {
        Value = value;
    }
}