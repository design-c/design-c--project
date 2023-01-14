namespace Application.Responses.Auth;

public class LoginResponse
{
    public string Token { get; set; }

    public DateTime Expiration { get; set; }
}