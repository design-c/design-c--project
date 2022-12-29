using Telegram.Bot;
using Telegram.Bot.Types;

namespace Services.Commands.Interfaces
{
    public interface ICommand
    {
        string Description { get; }
        Task Execute(TelegramBotClient client, Message message);
    }
}