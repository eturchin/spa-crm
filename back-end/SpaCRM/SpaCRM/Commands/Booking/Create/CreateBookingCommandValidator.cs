using FluentValidation;

namespace SpaCRM.Commands.Booking.Create;

public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
{
    public CreateBookingCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotNull().WithMessage("UserId cannot be null")
            .NotEmpty().WithMessage("UserId cannot be empty")
            .NotEqual(Guid.Empty).WithMessage("UserId cannot be Guid.Empty.");
        
        RuleFor(x => x.ServiceId)
            .NotNull().WithMessage("ServiceId cannot be null")
            .NotEmpty().WithMessage("ServiceId cannot be empty")
            .NotEqual(Guid.Empty).WithMessage("ServiceId cannot be Guid.Empty.");
        
        RuleFor(x => x.Date)
            .NotNull().WithMessage("Date cannot be null")
            .NotEmpty().WithMessage("Date cannot be empty");
    }
}