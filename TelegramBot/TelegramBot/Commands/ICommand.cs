using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Commands
{
    public interface ICommand
    {
        string Description { get; }
        Task Execute(TelegramBotClient client, Message message);
    }
}