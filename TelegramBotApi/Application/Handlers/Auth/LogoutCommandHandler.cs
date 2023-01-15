using Application.Requests.Auth;
using Logic.Services.Interfaces;
using MediatR;

namespace Application.Handlers.Auth;

public class LogoutRequestCommandHandler: IRequestHandler<LogoutRequestCommand>
{
    
    private readonly IAuthService authService;

    public LogoutRequestCommandHandler(IAuthService authService)
    {
        this.authService = authService;
    }
    
    public async Task<Unit> Handle(LogoutRequestCommand request, CancellationToken cancellationToken)
    {
        await authService.Logout(request.UserKey);
        
        return Unit.Value;
    }
}