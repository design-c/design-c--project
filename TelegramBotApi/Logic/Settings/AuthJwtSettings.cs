using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Logic.Settings;

public class AuthJwtSettings
{
    public const string JwtAuth = nameof(JwtAuth);

    public string SecretKey { get; set; }

    public int TokenExpireMinute { get; set; }
    
    public SymmetricSecurityKey SymmetricSecurityKey => new(Encoding.UTF8.GetBytes(SecretKey));
}