using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services;

public interface ICarService
{
    Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken);
    Task<List<Car>> GetAllAsync(GetAllCarQuery requst, CancellationToken cancellationToken);
}
