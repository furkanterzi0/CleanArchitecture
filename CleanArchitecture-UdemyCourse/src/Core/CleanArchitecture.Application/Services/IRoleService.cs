using CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;
using CleanArchitecture.Domain.Dtos;

namespace CleanArchitecture.Application.Services;

public interface IRoleService
{
    Task CreateAsync(CreateRoleCommand command);
}
