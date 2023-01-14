using Application.Requests.Urfu;
using Dal.Contracts.Interfaces;
using Logic.Models;
using Logic.Services.Interfaces;
using MediatR;

namespace Application.Handlers.Urfu;

public class GetUserInfoCommandHandler : IRequestHandler<GetUserInfoRequestCommand, UserInfo>
{
    private readonly IUrfuUserDataService userDataService;

    private readonly IUserInfoRepository userInfoRepository;

    public GetUserInfoCommandHandler(IUrfuUserDataService userDataService, IUserInfoRepository userInfoRepository)
    {
        this.userDataService = userDataService;
        this.userInfoRepository = userInfoRepository;
    }

    public async Task<UserInfo> Handle(GetUserInfoRequestCommand request, CancellationToken cancellationToken)
    {
        // достаем данные о пользователе по id, если их нет, то получаем новые, записываем их по userid

        var userInfo = await userDataService.GetUserInfo(request.UserKey);

        return userInfo;
    }
}