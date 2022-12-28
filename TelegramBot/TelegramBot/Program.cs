using Telegram.Bot;

using System;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using TelegramBot.Commands;

//using Services.Bot;

namespace TelegramBot;

static class Program
{
    private static string token = "5887050935:AAGlzQPcrF923D7FKpWphX5yNck8erdPFhI";
    private static readonly TelegramBotClient client = new(token);
        
    //private static Bot bot;
    private static void Main()
    {
        //bot = new Bot();
        client.StartReceiving();
        client.OnMessage += OnMessageHandler;
        Console.ReadKey();
        client.StopReceiving();
    }

    private static async void OnMessageHandler(object? sender, MessageEventArgs e)
    {
        var msg = e.Message;
        if (msg.Text != null)
        {
            Console.WriteLine($"{msg.Date} - {msg.Chat.Username} - {msg.Text}");
            
            if (!msg.Text.StartsWith("/"))
                await client.SendTextMessageAsync(msg.Chat.Id, "заткнись и напиши команду");
            else
            {
                var command = CommandParser.ParseCommand(msg.Text);
                await command.Execute(client, msg);
            }
        }
    }
}