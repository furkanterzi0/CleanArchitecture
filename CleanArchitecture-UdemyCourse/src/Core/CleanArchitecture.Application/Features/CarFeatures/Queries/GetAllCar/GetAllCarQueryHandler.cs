using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;

public class GetAllCarQueryHandler : IRequestHandler<GetAllCarQuery, List<Car>>
{
    private readonly ICarService carService;

    public GetAllCarQueryHandler(ICarService carService)
    {
        this.carService = carService;
    }
    public async Task<List<Car>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        List<Car> cars = await carService.GetAllAsync(request, cancellationToken);
        return cars;
    }
}
