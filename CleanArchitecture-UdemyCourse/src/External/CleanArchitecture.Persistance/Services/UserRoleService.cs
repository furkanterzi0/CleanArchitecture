using CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Services;

public class UserRoleService : IUserRoleService
{
    private readonly AppDbContext appDbContext;

    public UserRoleService(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        UserRole userRole = new UserRole
        {
            RoleId = request.RoleId,
            UserId = request.UserId,
        };

        await appDbContext.Set<UserRole>().AddAsync(userRole, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> GetRoleByUserId(string userId, string role)
    {
        return await appDbContext.Set<UserRole>()
            .Where(p => p.UserId == userId)
            .Include(p => p.Role)
            .AnyAsync(p => p.Role.Name == role);
    }


}
