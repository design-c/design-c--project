using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Logic.Extensions;
using Logic.Services.Interfaces;
using Logic.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Logic.Services;

public class AuthService : IAuthService
{
    private readonly AuthJwtSettings authJwtSettings;

    private readonly AuthUrfuSettings authUrfuSettings;

    private readonly HttpClient client;

    public AuthService(
        IOptions<AuthJwtSettings> authJwtOptions,
        IOptions<AuthUrfuSettings> authUrfuOptions,
        HttpClient httpClient
    )
    {
        authJwtSettings = authJwtOptions.Value;
        authUrfuSettings = authUrfuOptions.Value;
        client = httpClient;
    }

    public async Task<JwtSecurityToken> Login(string login, string password)
    {
        var isPasswordAndLoginCorrect = await IsPasswordAndLoginCorrect(login, password);

        if (!isPasswordAndLoginCorrect)
            throw new Exception("Неверный логин или пароль от учётной записи УрФУ.");

        return GetToken(login);
    }

    private JwtSecurityToken GetToken(string login)
    {
        var tokenClaims = new List<Claim>
        {
            new(ClaimTypes.Name, login),
        };

        return new JwtSecurityToken(
            claims: tokenClaims,
            expires: DateTime.Now.AddMinutes(authJwtSettings.TokenExpireMinute),
            signingCredentials: new SigningCredentials(authJwtSettings.SymmetricSecurityKey, SecurityAlgorithms.HmacSha256)
        );
    }

    private async Task<bool> IsPasswordAndLoginCorrect(string login, string password)
    {
        var request = authUrfuSettings.AuthUri
            .GenerateHttpRequestMessage(HttpMethod.Post)
            .AddLoginContent(login, password);
        var authResponse = await client.SendAsync(request).ConfigureAwait(false);
        authResponse.EnsureSuccessStatusCode();

        return authResponse.RequestMessage?.RequestUri?.Query.Contains("ok") ?? false;
    }
}