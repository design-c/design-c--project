using Application.Requests.Auth;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        try
        {
            var response = await mediator.Send(requestCommand);

            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("/logout")]
    public async Task<ActionResult> Logout()
    {
        throw new NotImplementedException();
    }

    [HttpGet("/check")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult> Check()
    {
        throw new NotImplementedException();
    }
}