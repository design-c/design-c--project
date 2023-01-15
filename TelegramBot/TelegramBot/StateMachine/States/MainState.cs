using Application.Commands;
using Application.Commands.Utils;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.InputMethods.InlineKeyboards;
using TelegramBot.StateMachine.States.Interfaces;

namespace TelegramBot.StateMachine.States;

public class MainState : BotState
{
    public MainState(long userId, ITelegramBotClient botClient, CancellationToken cancellationToken, StateMachine stateMachine) 
        : base(userId, botClient, cancellationToken, stateMachine) { }

    public override async Task HandleMessage(Message message)
    {
        var text = message.Text;
        
        if (text == null)
        {
            await TypeMessage("пиши текстом мужик", InlineKeyboards.MainKeyboard);
            return;
        }

        //Console.WriteLine($"{message.Date} - {message.Chat.Username} - {text}");
        var commandOutput = CommandParser.ParseCommand(CommandLists.MainCommands, text).Execute(message.Chat.Id);
        await TypeMessage(commandOutput, InlineKeyboards.MainKeyboard);
    }

    public override async Task HandleCallbackQuery(CallbackQuery callbackQuery)
    {
        var message = callbackQuery.Message;
        //Console.WriteLine($"{msg.Date} - {msg.Chat.Username} - Кнопка - {callbackQuery.Data}");
        var commandOutput = CommandParser.ParseCommand(CommandLists.MainCommands, callbackQuery.Data).Execute(message.Chat.Id);
        await TypeMessage(commandOutput, InlineKeyboards.MainKeyboard);
    }
}