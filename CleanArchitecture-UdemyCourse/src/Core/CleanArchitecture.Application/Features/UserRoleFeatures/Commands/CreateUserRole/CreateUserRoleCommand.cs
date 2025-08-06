using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;

public record CreateUserRoleCommand(
    string RoleId,
    string UserId): IRequest<MessageResponse>;