using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;

public class CreateNewTokenByRefreshTokenValidator: AbstractValidator<CreateNewTokenByRefreshTokenCommand>
{
    public CreateNewTokenByRefreshTokenValidator()
    {
        RuleFor(p => p.UserId).NotEmpty().WithMessage("User id bilgisi boş olamaz");
        RuleFor(p => p.UserId).NotNull().WithMessage("User id bilgisi boş olamaz");
        RuleFor(p => p.RefreshToken).NotEmpty().WithMessage("RefreshToken boş olamaz");
        RuleFor(p => p.RefreshToken).NotEmpty().WithMessage("RefreshToken boş olamaz");
    }
}
