using Application.Commands;
using Application.Commands.Utils;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.InputMethods.InlineKeyboards;
using TelegramBot.StateMachine.States.Interfaces;

namespace TelegramBot.StateMachine.States;

public class StartState : BotState
{
    public StartState(long userId, ITelegramBotClient botClient, CancellationToken cancellationToken, StateMachine stateMachine) 
        : base(userId, botClient, cancellationToken, stateMachine) { }
    
    public override async Task HandleMessage(Message message)
    {
        var commandOutput = CommandParser
            .ParseCommand(CommandLists.StartCommands, message.Text)
            .Execute(message.Chat.Id);
        
        switch (message.Text)
        {
            case "/start":
                await TypeMessage(commandOutput, InlineKeyboards.StartKeyboard);
                return;
            
            case "/login":
                stateMachine.ChangeState(new LoginState(userId, botClient, cancellationToken, stateMachine));
                await TypeMessage(commandOutput, InlineKeyboards.LoginKeyboard);
                return;
            
            default:
                await TypeMessage(commandOutput, InlineKeyboards.StartKeyboard);
                return;
        }
    }

    public override async Task HandleCallbackQuery(CallbackQuery callbackQuery)
    {
        var message = callbackQuery.Message;
        var commandOutput = CommandParser
            .ParseCommand(CommandLists.StartCommands, callbackQuery.Data)
            .Execute(message.Chat.Id);
        
        switch (callbackQuery.Data)
        {
            case "/login":
                await TypeMessage(commandOutput, InlineKeyboards.LoginKeyboard);
                stateMachine.ChangeState(new LoginState(userId, botClient, cancellationToken, stateMachine));
                return;
            
            default:
                await TypeMessage(commandOutput, InlineKeyboards.StartKeyboard);
                return;
        }
    }
}