using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;

public record LoginCommand(
    string UserNameOrEmail,
    string Password) : IRequest<LoginCommandResponse>;
