namespace Api.controllers.Dto.Responses;

public class LoginResponseDto
{
    public string Token { get; set; }

    public DateTime Expiration { get; set; }
}