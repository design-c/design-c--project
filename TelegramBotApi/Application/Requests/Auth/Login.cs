﻿using Application.Responses.Auth;
using MediatR;

namespace Application.Requests.Auth;

public class LoginRequestCommand : IRequest<LoginResponse>
{
    public string UserKey { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }
}