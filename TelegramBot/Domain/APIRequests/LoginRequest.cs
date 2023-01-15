using System.Net.Http.Json;
using Domain.Extensions;
using Infrastructure.Repositories;
using Newtonsoft.Json.Linq;

namespace Domain;

public static class LoginRequest
{
    private const string apiLoginUri = "https://localhost:7217/login";
    private static readonly HttpClient client;

    static LoginRequest()
    {
        client = new HttpClient();
    }

    public static async void LoginUser(string[] loginInfo, long userId)
    {
        var login = loginInfo[0];
        var password = loginInfo[1];
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, apiLoginUri);
        requestMessage.Content = JsonContent
            .Create(new { userKey = userId.ToString(), login, password });
        var responseMessage = await client.SendAsync(requestMessage).ConfigureAwait(false);
        var responseAsString = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
        
        var jObject = JObject.Parse(responseAsString);

        // API get token from login info
        UserRepository.AddUser(userId, "token");

        UserRepository.GetUserToken(userId);
    }
}