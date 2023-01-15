using Application.Commands;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.InputMethods.InlineKeyboards;
using TelegramBot.StateMachine.States.Interfaces;

namespace TelegramBot.StateMachine.States;

public class LoginState : BotState
{
    public LoginState(long userId, ITelegramBotClient botClient, CancellationToken cancellationToken, StateMachine stateMachine) 
        : base(userId, botClient, cancellationToken, stateMachine) { }
    
    public override async Task HandleMessage(Message message)
    {
        var loginInfo = message.Text.Split(StartLoginCommand.LoginInfoSeparator);
        var userId = message.Chat.Id;
        
        if (loginInfo.Length != 2)
        {
            await TypeMessage($"Неправильный формат логина и пароля.\nВведите в формате {StartLoginCommand.LoginFormat}", 
                InlineKeyboards.LoginKeyboard);
            return;
        }

        await TypeMessage(new LoginCommand(loginInfo).Execute(userId), InlineKeyboards.LoginKeyboard);
        stateMachine.ChangeState(new MainState(userId, botClient, cancellationToken, stateMachine));
    }

    public override async Task HandleCallbackQuery(CallbackQuery callbackQuery)
    {
        return;
    }
}