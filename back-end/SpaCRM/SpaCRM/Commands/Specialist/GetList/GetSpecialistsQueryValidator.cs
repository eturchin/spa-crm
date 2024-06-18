using FluentValidation;

namespace SpaCRM.Commands.Specialist.GetList;

public class GetSpecialistsQueryValidator : AbstractValidator<GetSpecialistsQuery>
{
    public GetSpecialistsQueryValidator()
    {
        RuleFor(x => x.ServiceId)
            .NotNull().WithMessage("ServiceId cannot be null")
            .NotEmpty().WithMessage("ServiceId cannot be empty")
            .NotEqual(Guid.Empty).WithMessage("ServiceId cannot be Guid.Empty.");
    }
}