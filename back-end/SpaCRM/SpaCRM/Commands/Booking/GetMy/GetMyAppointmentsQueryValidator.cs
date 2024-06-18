using FluentValidation;

namespace SpaCRM.Commands.Booking.GetMy;

public class GetMyAppointmentsQueryValidator : AbstractValidator<GetMyAppointmentsQuery>
{
    public GetMyAppointmentsQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotNull().WithMessage("UserId cannot be null")
            .NotEmpty().WithMessage("UserId cannot be empty")
            .NotEqual(Guid.Empty).WithMessage("UserId cannot be Guid.Empty.");
    }
}