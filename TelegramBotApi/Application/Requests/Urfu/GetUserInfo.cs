using Logic.Models;
using MediatR;

namespace Application.Requests.Urfu;

public class GetUserInfoRequestCommand : IRequest<UserInfo>
{
    public string UserKey { get; set; }
}