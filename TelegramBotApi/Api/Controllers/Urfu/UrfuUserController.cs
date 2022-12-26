using Logic.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Urfu;

[ApiController]
[Route("/urfu")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UrfuUserController : ControllerBase
{
    private readonly IUserUrfuService userUrfuService;

    public UrfuUserController(IUserUrfuService userUrfuService)
    {
        this.userUrfuService = userUrfuService;
    }

    [HttpGet("/info")]
    public async Task<OkResult> GetUserInfo()
    {
        await userUrfuService.GetUserInfo();

        return Ok();
    }
    
    [HttpGet("/schedule")]
    public async Task<OkResult> GetUserSchedule()
    {
        await userUrfuService.GetUserSchedule();

        return Ok();
    }
}