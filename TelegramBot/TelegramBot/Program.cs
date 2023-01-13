using UserInterface.Bot;

namespace TelegramBot;

static class Program
{
    private static Bot bot;
    
    private static void Main()
    {
        bot = new Bot();
        Console.ReadKey();
        bot.StopBot();
    }
}