using Application.Requests.Urfu;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/urfu")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UrfuController : ControllerBase
{
    private readonly IMediator mediator;

    public UrfuController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [Authorize, HttpGet("info")]
    public async Task<ActionResult> GetUserInfo()
    {
        return Ok(await mediator.Send(new GetUserInfoRequestCommand { UserKey = User.Identity?.Name ?? "" }));
    }

    [Authorize, HttpGet("marks")]
    public async Task<ActionResult> GetUserMarks()
    {
        return Ok(await mediator.Send(new GetUserMarksRequestCommand { UserKey = User.Identity?.Name ?? "" }));
    }
}