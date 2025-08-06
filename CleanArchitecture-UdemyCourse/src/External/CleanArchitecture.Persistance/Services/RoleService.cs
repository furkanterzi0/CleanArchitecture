using CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Persistance.Services;

public class RoleService : IRoleService
{
    private readonly RoleManager<Domain.Entities.Role> roleManager;

    public RoleService(RoleManager<Role> roleManager)
    {
        this.roleManager = roleManager;
    }

    public async Task CreateAsync(CreateRoleCommand request)
    {
        Role role = new Role { Name = request.Name };
        await roleManager.CreateAsync(role);    
    }
}
