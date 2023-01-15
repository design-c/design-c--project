namespace Domain.Extensions;

public static class HeadersExtensions
{
    public static HttpRequestMessage WithBearerAuthorization(
        this HttpRequestMessage requestMessage, string jwt)
    {
        requestMessage.Headers.Add("Authorization", $"Bearer {jwt}");
        
        return requestMessage;
    }
}