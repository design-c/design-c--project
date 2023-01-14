using Application.Commands;
using Application.Commands.Utils;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.InputMethods.InlineKeyboards;
using TelegramBot.StateMachine.States.Interfaces;

namespace TelegramBot.StateMachine.States;

public class MainState : BotState
{
    public MainState(ITelegramBotClient botClient, CancellationToken cancellationToken, StateMachine stateMachine) 
        : base(botClient, cancellationToken, stateMachine) { }

    public override async Task HandleMessage(Message message)
    {
        var text = message.Text;

        if (text == null)
        {
            await TypeMessage(message, "пиши текстом мужик", InlineKeyboards.MainKeyboard);
            return;
        }

        //Console.WriteLine($"{message.Date} - {message.Chat.Username} - {text}");
        var commandOutput = CommandParser.ParseCommand(CommandLists.MainCommands, text).Execute();
        await TypeMessage(message, commandOutput, InlineKeyboards.MainKeyboard);
    }

    public override async Task HandleCallbackQuery(CallbackQuery callbackQuery)
    {
        var msg = callbackQuery.Message;
        //Console.WriteLine($"{msg.Date} - {msg.Chat.Username} - Кнопка - {callbackQuery.Data}");
        var commandOutput = CommandParser.ParseCommand(CommandLists.MainCommands, callbackQuery.Data).Execute();
        await TypeMessage(msg, commandOutput, InlineKeyboards.MainKeyboard);
    }
}