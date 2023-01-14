using System.IdentityModel.Tokens.Jwt;
using Application.Requests.Auth;
using Application.Responses.Auth;
using Logic.Services.Interfaces;
using MediatR;

namespace Application.Handlers.Auth;

public class LoginRequestCommandHandler : IRequestHandler<LoginRequestCommand, LoginResponse>
{
    private readonly IAuthService authService;

    public LoginRequestCommandHandler(IAuthService authService)
    {
        this.authService = authService;
    }

    public async Task<LoginResponse> Handle(LoginRequestCommand request, CancellationToken cancellationToken)
    {
        var token = await authService.Login(request.Login, request.Password);

        return new LoginResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = token.ValidTo
        };
    }
}