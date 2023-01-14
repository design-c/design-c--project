using Application.Requests.Urfu;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/urfu")]
// [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UrfuController : ControllerBase
{
    private readonly IMediator mediator;

    public UrfuController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("info/{userKey}")]
    public async Task<ActionResult> GetUserInfo(string userKey)
    {
        return Ok(await mediator.Send(new GetUserInfoRequestCommand { UserKey = userKey }));
    }

    [HttpGet("marks/{userKey}")]
    public async Task<ActionResult> GetUserMarks(string userKey)
    {
        return Ok(await mediator.Send(new GetUserMarksRequestCommand { UserKey = userKey }));
    }
}