using System.IdentityModel.Tokens.Jwt;

namespace Logic.Services.Interfaces;

public interface IAuthService
{
    Task<JwtSecurityToken> Login(string userKey, string login, string password);
}