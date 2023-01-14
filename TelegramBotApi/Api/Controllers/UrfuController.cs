using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.controllers.Internal.Modeus;

[ApiController]
[Route("/modeus")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ModeusController : ControllerBase
{
    [HttpGet]
    public async Task<OkResult> GetTest()
    {
        return Ok();
    }
}