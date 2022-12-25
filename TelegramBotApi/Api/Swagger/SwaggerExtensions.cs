using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Swagger;

public static class SwaggerExtensions
{
    public static void SetDescriptions(this SwaggerGenOptions options)
    {
        var authScheme = new OpenApiSecurityScheme
        {
            Description = "AccessToken от IdentityServer ВМЕСТЕ со словом Bearer, напр. 'Bearer kM1Q0EiLCJ0eXAiOiJK...'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        };
        options.AddSecurityDefinition(authScheme.Scheme, authScheme);
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                authScheme, Array.Empty<string>()
            }
        });
    }
}