using Logic.Models;
using MediatR;

namespace Application.Requests.Urfu;

public class GetUserMarksRequestCommand : IRequest<IEnumerable<UserMark>>
{
    public string UserKey { get; set; }
}