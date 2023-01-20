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
        if (message.Text == null)
        {
            await TypeMessage("Можно выполнять только текстовые команды и кнопки", InlineKeyboards.MainKeyboard);
            return;
        }

        var commandOutput = CommandParser.ParseCommand(CommandLists.MainCommands, message.Text).Execute(userId);
        await TypeMessage(commandOutput, InlineKeyboards.MainKeyboard);
    }

    public override async Task HandleCallbackQuery(CallbackQuery callbackQuery)
    {
        var commandOutput = CommandParser.ParseCommand(CommandLists.MainCommands, callbackQuery.Data).Execute(userId);
        await TypeMessage(commandOutput, InlineKeyboards.MainKeyboard);
    }
}