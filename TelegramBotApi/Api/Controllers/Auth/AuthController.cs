using System.IdentityModel.Tokens.Jwt;
using Api.controllers.Dto.Requests;
using Api.controllers.Dto.Responses;
using Logic.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.controllers;

[ApiController]
[Route("/auth")]
public class  AuthController : ControllerBase
{
    private readonly IAuthService authService;

    public AuthController(IAuthService authService)
    {
        this.authService = authService;
    }

    [HttpPost("/login")]
    public async Task<ActionResult> Login(LoginRequestDto loginRequestDto)
    {
        try
        {
            var token = await authService.Login(loginRequestDto.UserKey, loginRequestDto.Login, loginRequestDto.Password);

            return Ok(new LoginResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("/logout")]
    public async Task<ActionResult> Logout()
    {
        return Ok();
    }

    [HttpGet("/check")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult> Check()
    {
        return Ok();
    }
}