using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Services;
using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;

public class CreateNewTokenByRefreshTokenCommandHandler : IRequestHandler<CreateNewTokenByRefreshTokenCommand, LoginCommandResponse>
{
    private readonly IAuthService authService;

    public CreateNewTokenByRefreshTokenCommandHandler(IAuthService authService)
    {
        this.authService = authService;
    }

    public async Task<LoginCommandResponse> Handle(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await authService.CreateTokenByRefreshTokenAsync(request, cancellationToken);
        return response;
    }
}
