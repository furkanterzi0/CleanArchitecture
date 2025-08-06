using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Authorization;
using CleanArchitecture.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controller;

public sealed class CarsController : ApiController
{
    public CarsController(IMediator mediator) : base(mediator){}

    [RoleFilter("Admin")]
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateCarCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response =  await _mediator.Send(request, cancellationToken);  
        return Ok(response);
    }

    [RoleFilter("Admin")]
    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        List<Car> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
