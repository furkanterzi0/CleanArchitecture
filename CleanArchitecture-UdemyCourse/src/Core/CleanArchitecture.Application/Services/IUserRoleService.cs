using CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;

namespace CleanArchitecture.Application.Services;

public interface IUserRoleService
{
    Task CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken);
    Task<bool> GetRoleByUserId(string UserId, string role);
}
