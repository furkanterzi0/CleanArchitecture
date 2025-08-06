using FluentValidation;

namespace CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;

public class CreateRoleValidator: AbstractValidator<CreateRoleCommand>
{
    public CreateRoleValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("name alani bos olamaz");
        RuleFor(p => p.Name).NotNull().WithMessage("name alani bos olamaz");
    }
}
