using System.Text;
using Logic.Services.Interfaces;

namespace Logic.Services;

public class UrfuUtilsService : IUrfuUtilsService
{
    private const string symbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    public string GenerateUrfuUserId()
    {
        var random = new Random();

        return Enumerable
            .Range(0, 16)
            .Aggregate("", (res, _) =>
            {
                res += symbols[random.Next(0, symbols.Length)];

                return res;
            });
    }
}