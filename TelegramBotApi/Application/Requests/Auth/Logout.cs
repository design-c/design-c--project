using Application.Responses.Auth;
using MediatR;

namespace Application.Requests.Auth;

public class LogoutRequestCommand: IRequest, IRequest<LoginResponse>
{
    public string UserKey { get; set; }
}