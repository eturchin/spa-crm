using MediatR;

namespace SpaCRM.Commands.Booking.GetMy;

public class GetMyAppointmentsQuery : IRequest<GetMyAppointmentsResponse>
{
    public Guid UserId { get; init; }
}