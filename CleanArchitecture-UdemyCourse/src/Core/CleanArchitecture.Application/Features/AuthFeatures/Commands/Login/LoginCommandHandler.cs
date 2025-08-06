using CleanArchitecture.Application.Services;
using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
{
    private readonly IAuthService authService;

    public LoginCommandHandler(IAuthService authService)
    {
        this.authService = authService;
    }
    public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await authService.LoginAsync(request, cancellationToken);

        return response;
    }
}
