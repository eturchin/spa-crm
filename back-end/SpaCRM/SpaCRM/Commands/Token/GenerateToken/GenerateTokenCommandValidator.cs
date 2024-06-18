using FluentValidation;

namespace SpaCRM.Commands.Token.GenerateToken;

public class GenerateTokenCommandValidator : AbstractValidator<GenerateTokenCommand>
{
    public GenerateTokenCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id cannot be null")
            .NotEmpty().WithMessage("Id cannot be empty");
        
        RuleFor(x => x.RoleId)
            .NotNull().WithMessage("RoleId cannot be null")
            .NotEmpty().WithMessage("RoleId cannot be empty");
        
        RuleFor(x => x.PhoneNumber)
            .NotNull().WithMessage("PhoneNumber cannot be null")
            .NotEmpty().WithMessage("PhoneNumber cannot be empty");
    }
}