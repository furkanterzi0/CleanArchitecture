using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;

public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, MessageResponse>
{
    private readonly IUserRoleService userRolesService;

    public CreateUserRoleCommandHandler(IUserRoleService userRolesService)
    {
        this.userRolesService = userRolesService;
    }
    public async Task<MessageResponse> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        await userRolesService.CreateAsync(request, cancellationToken);
        return new("kullaniciya rol basariyla atandı");
    }
}
