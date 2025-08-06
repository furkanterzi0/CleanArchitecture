using FluentValidation;

namespace CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;

public class CreateUserRoleCommandValidator: AbstractValidator<CreateUserRoleCommand>
{
    public CreateUserRoleCommandValidator()
    {
        RuleFor(p => p.UserId).NotEmpty().WithMessage("UserId alani bos olamaz");
        RuleFor(p => p.UserId).NotNull().WithMessage("UserId alani bos olamaz");

        RuleFor(p => p.RoleId).NotEmpty().WithMessage("RoleId alani bos olamaz");
        RuleFor(p => p.RoleId).NotNull().WithMessage("RoleId alani bos olamaz");
    }
}
