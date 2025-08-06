using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;

public sealed class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, MessageResponse>
{
    private readonly ICarService carService;

    public CreateCarCommandHandler(ICarService carService)
    {
        this.carService=carService;
    }
    public async Task<MessageResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        await carService.CreateAsync(request, cancellationToken);

        return new("Arac basariyla kaydedildi!");
    }
}
