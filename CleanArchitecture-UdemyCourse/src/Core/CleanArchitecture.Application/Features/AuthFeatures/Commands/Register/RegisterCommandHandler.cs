using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, MessageResponse>
{
    private readonly IAuthService authService;

    public RegisterCommandHandler(IAuthService authService)
    {
        this.authService = authService;
    }


    public async Task<MessageResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await authService.RegisterAsync(request);
        return new MessageResponse("kullanici kaydi basariyla tamamlandı");
    }
}
