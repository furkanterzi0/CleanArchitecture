namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;

public record LoginCommandResponse(
    string Token,
    string RefreshToken,
    DateTime? RefreshTokenExpires,
    string UserId);

