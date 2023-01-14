using System.Reflection;
using Api.DependencyRegistration;
using Api.Swagger;
using Logic.Settings;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(Assembly.Load("Application"));
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options => { options.SetDescriptions(); });
builder.Services.AddEndpointsApiExplorer();

#region Auth

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;

        var configurationSection = builder.Configuration
            .GetSection(AuthJwtSettings.JwtAuth)
            .Get(typeof(AuthJwtSettings));

        if (configurationSection is AuthJwtSettings authJwtSettings)
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateLifetime = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = authJwtSettings.SymmetricSecurityKey,
            };

            return;
        }

        throw new Exception("Invalid AuthJwt configuration");
    });

#endregion

builder.Services.AddAuthorization();

builder.Services.Configure<AuthUrfuSettings>(builder.Configuration.GetSection(AuthUrfuSettings.UrfuAuth));
builder.Services.Configure<AuthJwtSettings>(builder.Configuration.GetSection(AuthJwtSettings.JwtAuth));
builder.Services.AddLogicServices();
builder.Services.AddRepositories(builder.Configuration.GetConnectionString("DB"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();