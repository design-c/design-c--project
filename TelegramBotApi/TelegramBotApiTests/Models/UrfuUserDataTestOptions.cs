using Logic.Settings;
using Microsoft.Extensions.Options;

namespace TelegramBotApiTests.Models;

public class UrfuUserDataTestOptions : IOptions<UrfuUserDataSettings>
{
    public UrfuUserDataSettings Value { get; }

    public UrfuUserDataTestOptions(UrfuUserDataSettings value)
    {
        Value = value;
    }
}