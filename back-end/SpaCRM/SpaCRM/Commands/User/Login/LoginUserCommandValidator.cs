using FluentValidation;

namespace SpaCRM.Commands.User.Login;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(x => x.PhoneNumber)
            .NotNull().WithMessage("PhoneNumber cannot be null")
            .NotEmpty().WithMessage("PhoneNumber cannot be empty");
        
        RuleFor(x => x.Password)
            .NotNull().WithMessage("Password cannot be null")
            .NotEmpty().WithMessage("Password cannot be empty");
    }
}