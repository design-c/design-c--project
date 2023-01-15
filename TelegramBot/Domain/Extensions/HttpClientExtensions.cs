namespace Domain.Extensions;

public static class HttpClientExtensions
{
    public static HttpRequestMessage GenerateHttpRequestMessage(this string uri, HttpMethod httpMethod)
        => new(httpMethod, uri);
}