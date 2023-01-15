using Application.Requests.Urfu;
using Dal.Contracts.Interfaces;
using Logic.Models;
using Logic.Services.Interfaces;
using MediatR;

namespace Application.Handlers.Urfu;

public class GetUserMarksCommandHandler : IRequestHandler<GetUserMarksRequestCommand, IEnumerable<UserMark>>
{
    private readonly IUserDataService userDataService;
    
    public GetUserMarksCommandHandler(IUserDataService userDataService)
    {
        this.userDataService = userDataService;
    }

    public async Task<IEnumerable<UserMark>> Handle(GetUserMarksRequestCommand request, CancellationToken cancellationToken)
    {
        var userMarks = await userDataService.GetUserMarks(request.UserKey, request.NeedUpdate);

        return userMarks;
    }
}