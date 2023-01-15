namespace TelegramBot.Settings;

public class BotSettings
{
    public const string Telegram = nameof(Telegram);

    public string Token { get; set; }

    public string ApiUrl { get; set; }
}