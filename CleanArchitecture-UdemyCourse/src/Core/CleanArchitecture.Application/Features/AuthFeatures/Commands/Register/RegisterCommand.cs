using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;

public record RegisterCommand(
    string UserName,
    string Password,
    string Email,
    string FullName): IRequest<MessageResponse>;
