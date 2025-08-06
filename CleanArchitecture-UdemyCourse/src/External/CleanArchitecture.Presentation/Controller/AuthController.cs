using CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controller;

public class AuthController: ApiController
{ 
    public AuthController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterCommand request, CancellationToken cancellation)
    {
        MessageResponse response = await _mediator.Send(request, cancellation);
        return Ok(response);
    }

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellation)
    {
        LoginCommandResponse response = await _mediator.Send(request, cancellation);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateTokenByRefreshToken(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellation)
    {
        LoginCommandResponse response = await _mediator.Send(request, cancellation);
        return Ok(response);
    }

}
