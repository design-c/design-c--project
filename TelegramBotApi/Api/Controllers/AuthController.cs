using Application.Requests.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.controllers;

[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator mediator;

    public AuthController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("/login")]
    public async Task<ActionResult> Login(LoginRequestCommand requestCommand)
    {
        return await SendToMediator(requestCommand);
    }

    [Authorize, HttpGet("/logout")]
    public async Task<ActionResult> Logout()
    {
        return await SendToMediator(new LogoutRequestCommand{ UserKey = User.Identity!.Name! });
    }
    
    private async Task<ActionResult> SendToMediator(IBaseRequest command)
    {
        try
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}