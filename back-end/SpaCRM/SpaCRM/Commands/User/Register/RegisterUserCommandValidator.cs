using FluentValidation;

namespace SpaCRM.Commands.User.Register;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotNull().WithMessage("FirstName cannot be null")
            .NotEmpty().WithMessage("FirstName cannot be empty");
        
        RuleFor(x => x.LastName)
            .NotNull().WithMessage("LastName cannot be null")
            .NotEmpty().WithMessage("LastName cannot be empty");
        
        RuleFor(x => x.PhoneNumber)
            .NotNull().WithMessage("FirstName cannot be null")
            .NotEmpty().WithMessage("FirstName cannot be empty");
        
        RuleFor(x => x.Email)
            .NotNull().WithMessage("Email cannot be null")
            .NotEmpty().WithMessage("Email cannot be empty");
        
        RuleFor(x => x.Password)
            .NotNull().WithMessage("Password cannot be null")
            .NotEmpty().WithMessage("Password cannot be empty");
        
        RuleFor(x => x.ConfirmPassword)
            .NotNull().WithMessage("ConfirmPassword cannot be null")
            .NotEmpty().WithMessage("ConfirmPassword cannot be empty");
    }
}