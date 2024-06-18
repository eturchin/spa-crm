using System.Text.Json.Serialization;
using MediatR;

namespace SpaCRM.Commands.Booking.Create;

public class CreateBookingCommand : IRequest<CreateBookingResponse>
{
    [JsonIgnore]
    public Guid UserId { get; set; }
    
    public Guid ServiceId { get; init; }
    
    public Guid? SpecialistId { get; init; }
    
    public DateTime Date { get; init; }
    
    public string ClientName { get; init; }
    
    public string PhoneNumber { get; init; }
}