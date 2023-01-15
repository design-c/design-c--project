using Application.Requests.Urfu;
using Logic.Models;
using Logic.Services.Interfaces;
using MediatR;

namespace Application.Handlers.Urfu;

public class GetUserInfoCommandHandler : IRequestHandler<GetUserInfoRequestCommand, UserInfo>
{
    private readonly IUserDataService userDataService;

    public GetUserInfoCommandHandler(IUserDataService userDataService)
    {
        this.userDataService = userDataService;
    }

    public async Task<UserInfo> Handle(GetUserInfoRequestCommand request, CancellationToken cancellationToken)
    {
        var userInfo = await userDataService.GetUserInfo(request.UserKey, request.NeedUpdate);

        return userInfo;
    }
}