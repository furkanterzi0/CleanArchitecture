using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, MessageResponse>
{
    private readonly IRoleService roleService;

    public CreateRoleCommandHandler(IRoleService roleService)
    {
        this.roleService = roleService;
    }
    public async Task<MessageResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        await roleService.CreateAsync(request);
        return new("rol basariyla olusturuldu");
    }
}
