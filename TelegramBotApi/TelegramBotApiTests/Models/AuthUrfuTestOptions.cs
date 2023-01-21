using Logic.Settings;
using Microsoft.Extensions.Options;

namespace TelegramBotApiTests.Models;

public class AuthUrfuTestOptions : IOptions<AuthUrfuSettings>
{
    public AuthUrfuSettings Value { get; }

    public AuthUrfuTestOptions(AuthUrfuSettings value)
    {
        Value = value;
    }
}