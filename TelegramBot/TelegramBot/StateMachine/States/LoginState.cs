using Application.Commands;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.InputMethods.InlineKeyboards;
using TelegramBot.StateMachine.States.Interfaces;

namespace TelegramBot.StateMachine.States;

public class LoginState : BotState
{
    public LoginState(ITelegramBotClient botClient, CancellationToken cancellationToken, StateMachine stateMachine) 
        : base(botClient, cancellationToken, stateMachine) { }
    
    public override async Task HandleMessage(Message message)
    {
        var loginInfo = message.Text.Split(StartLoginCommand.LoginInfoSeparator);

        if (loginInfo.Length != 2)
        {
            await TypeMessage(message, $"Неправильный формат логина и пароля.\nВведите в формате {StartLoginCommand.LoginFormat}", 
                InlineKeyboards.LoginKeyboard);
            return;
        }

        await TypeMessage(message,new LoginCommand(loginInfo, message.Chat.Id).Execute(), InlineKeyboards.LoginKeyboard);
        stateMachine.ChangeState(new MainState(botClient, cancellationToken, stateMachine));
    }

    public override async Task HandleCallbackQuery(CallbackQuery callbackQuery)
    {
        return;
    }
}