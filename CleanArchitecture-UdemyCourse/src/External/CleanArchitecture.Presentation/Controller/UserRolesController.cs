using CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controller;

public class UserRolesController : ApiController
{
    public UserRolesController(IMediator mediator) : base(mediator){}

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateUserRoleCommand request, CancellationToken cancellation)
    {
        MessageResponse response = await _mediator.Send(request, cancellation);
        return Ok(response);
    }
}
