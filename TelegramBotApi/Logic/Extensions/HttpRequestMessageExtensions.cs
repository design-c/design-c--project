using Logic.enums;

namespace Logic.Extensions;

public static class HttpRequestMessageExtensions
{
    public static HttpRequestMessage GenerateHttpRequestMessage(this string uri, HttpMethod httpMethod)
        => new(httpMethod, uri);

    public static HttpRequestMessage AddLoginContent(
        this HttpRequestMessage requestMessage, string login, string password
    )
    {
        const string formsAuthentication = "FormsAuthentication";
        requestMessage.Content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>(nameof(LoginRequestKey.UserName), login),
            new KeyValuePair<string, string>(nameof(LoginRequestKey.Password), password),
            new KeyValuePair<string, string>(nameof(LoginRequestKey.AuthMethod), formsAuthentication)
        });

        return requestMessage;
    }
}