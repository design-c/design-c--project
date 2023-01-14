using Application.Requests.Urfu;
using Dal.Contracts.Interfaces;
using Logic.Models;
using Logic.Services.Interfaces;
using MediatR;

namespace Application.Handlers.Urfu;

public class GetUserMarksCommandHandler : IRequestHandler<GetUserMarksRequestCommand, IEnumerable<UserMark>>
{
    private readonly IUrfuUserDataService userDataService;

    private readonly IUserMarksRepository userMarksRepository;

    public GetUserMarksCommandHandler(IUrfuUserDataService userDataService, IUserMarksRepository userMarksRepository)
    {
        this.userDataService = userDataService;
        this.userMarksRepository = userMarksRepository;
    }

    public async Task<IEnumerable<UserMark>> Handle(GetUserMarksRequestCommand request, CancellationToken cancellationToken)
    {
        // достаем данные о пользователе по id, если их нет, то получаем новые, записываем их по userid
        
        var userMarks = await userDataService.GetUserMarks(request.UserKey);

        return userMarks;
    }
}