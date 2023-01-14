using TelegramBot.Bot;

namespace DI;

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