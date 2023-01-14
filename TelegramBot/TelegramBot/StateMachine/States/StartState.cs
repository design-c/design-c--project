using Application.Commands;
using Application.Commands.Utils;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.InputMethods.InlineKeyboards;
using TelegramBot.StateMachine.States.Interfaces;

namespace TelegramBot.StateMachine.States;

public class StartState : BotState
{
    public StartState(ITelegramBotClient botClient, CancellationToken cancellationToken, StateMachine stateMachine) 
        : base(botClient, cancellationToken, stateMachine) { }
    
    public override async Task HandleMessage(Message message)
    {
        var commandOutput = CommandParser
            .ParseCommand(CommandLists.StartCommands, message.Text)
            .Execute(message.Chat.Id);
        
        switch (message.Text)
        {
            case "/start":
                CommandLists.StartCommands = CommandLists.StartCommands.Where(cmd => cmd is not StartCommand);
                await TypeMessage(message, commandOutput, InlineKeyboards.StartKeyboard);
                return;
            
            case "/login":
                stateMachine.ChangeState(new LoginState(botClient, cancellationToken, stateMachine));
                await TypeMessage(message, commandOutput, InlineKeyboards.LoginKeyboard);
                return;
            
            default:
                await TypeMessage(message, commandOutput, InlineKeyboards.StartKeyboard);
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
                await TypeMessage(message, commandOutput, InlineKeyboards.LoginKeyboard);
                stateMachine.ChangeState(new LoginState(botClient, cancellationToken, stateMachine));
                return;
            
            default:
                await TypeMessage(message, commandOutput, InlineKeyboards.StartKeyboard);
                return;
        }
    }
}