using CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controller;

public class RolesController : ApiController
{
    public RolesController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<ActionResult> Create(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

}
