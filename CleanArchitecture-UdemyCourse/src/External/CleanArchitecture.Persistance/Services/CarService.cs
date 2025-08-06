using AutoMapper;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Services;

public class CarService : ICarService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CarService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }
    public async Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken)
    {
     
        Car car = _mapper.Map<Car>(request);
        
        await _context.Set<Car>().AddAsync(car, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);  

    }

    public async Task<List<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Car> query = _context.Set<Car>();

        // Eğer search varsa filtrele
        if (!string.IsNullOrEmpty(request.Search))
        {
            var searchLower = request.Search.ToLower();
            query = query.Where(p => p.Name.ToLower().Contains(searchLower));
        }

        // Pagination
        int skip = (request.PageNumber - 1) * request.PageSize;
        query = query.Skip(skip).Take(request.PageSize);

        // Sonucu getir
        return await query.ToListAsync(cancellationToken);
    }

}
