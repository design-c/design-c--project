using Application.Requests.Urfu;
using Logic.Models;
using Logic.Services.Interfaces;
using MediatR;

namespace Application.Handlers.Urfu;

public class GetUserInfoCommandHandler : IRequestHandler<GetUserInfoRequestCommand, UserInfo>
{
    private readonly IUserDataService _userDataService;

    public GetUserInfoCommandHandler(IUserDataService userDataService)
    {
        this._userDataService = userDataService;
    }

    public async Task<UserInfo> Handle(GetUserInfoRequestCommand request, CancellationToken cancellationToken)
    {
        var userInfo = await _userDataService.GetUserInfo(request.UserKey);

        return userInfo;
    }
}