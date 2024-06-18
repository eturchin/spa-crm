using FluentValidation;

namespace SpaCRM.Commands.User.GetMe;

public class GetMeQueryValidator : AbstractValidator<GetMeQuery>
{
    public GetMeQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id cannot be null")
            .NotEmpty().WithMessage("Id cannot be empty")
            .NotEqual(Guid.Empty).WithMessage("Id cannot be Guid.Empty.");
    }   
}