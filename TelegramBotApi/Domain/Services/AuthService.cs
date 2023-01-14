using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Dal.Contracts.Interfaces;
using Dal.Contracts.Models;
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

    private readonly IUserRepository userRepository;

    private readonly HttpClient client;

    public AuthService(
        IOptions<AuthJwtSettings> authJwtOptions,
        IOptions<AuthUrfuSettings> authUrfuOptions,
        IUserRepository userRepository,
        HttpClient httpClient
    )
    {
        authJwtSettings = authJwtOptions.Value;
        authUrfuSettings = authUrfuOptions.Value;
        this.userRepository = userRepository;
        client = httpClient;
    }

    public async Task<JwtSecurityToken> Login(string login, string password, string userKey)
    {
        var isPasswordAndLoginCorrect = await IsPasswordAndLoginCorrect(login, password);

        if (!isPasswordAndLoginCorrect)
            throw new Exception("Неверный логин или пароль от учётной записи УрФУ.");

        var user = await userRepository.GetUserByKey(userKey);

        if (user == null)
        {
            await userRepository.CreateAsync(new UserModel { Login = login, Password = password, UserKey = userKey });
        }
        else
        {
            user.Login = login;
            user.Password = password;
            user.UserKey = userKey;
            await userRepository.UpdateAsync(user);
        }

        return GetToken(login);
    }

    public async Task LoginByUserId(string userKey)
    {
        var user = await userRepository.GetUserByKey(userKey);

        if (user == null)
            throw new Exception("Пользователя с таким userKey в базе нет");

        var isPasswordAndLoginCorrect = await IsPasswordAndLoginCorrect(user.Login, user.Password);

        if (!isPasswordAndLoginCorrect)
            throw new Exception("Неправильный логин или пароль пользователя записан в базу данных");
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