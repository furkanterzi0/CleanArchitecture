using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;

public record GetAllCarQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string? Search = null): IRequest<List<Car>>;

